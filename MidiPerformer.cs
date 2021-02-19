//!CompilerOption:AddRef:Melanchall.DryWetMidi.dll
//!CompilerOption:Optimize:On
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.AClasses;
using ff14bot.Behavior;
using ff14bot.Helpers;
using ff14bot.Managers;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using TreeSharp;

namespace MidiPerformer
{
	internal class MidiPerformer : AsyncBotBase
	{
		public static MidiFile currentFile;
		public static int noteOffset;
		public static bool pausing;
		public static bool looping;
		private static Task currentPlaying;
		private Form1 form;


		private bool started;
		public override string Name => nameof(MidiPerformer);
		public override PulseFlags PulseFlags => PulseFlags.Windows;
		public override bool RequiresProfile => false;
		public override Composite Root => null;
		public override bool WantButton => true;

		public override void OnButtonPress()
		{
			try
			{
				var fileDialog = new OpenFileDialog { Title = "Select a midi file", Filter = "midi files (*.mid)|*.mid" };
				fileDialog.ShowDialog();
				if (!string.IsNullOrEmpty(fileDialog.FileName))
					MidiPlayerSettings.Instance.midifilepath = fileDialog.FileName;
			}
			catch (Exception e)
			{
				Log.Write(e);
				Log.Write("please select a mid file.");
			}

			if (form == null || form.IsDisposed || !form.Visible)
			{
				form = new Form1();
				form.Show();
			}

			form.Focus();
		}

		public override void Start()
		{
			try
			{
				using (var f = new FileStream(MidiPlayerSettings.Instance.midifilepath, FileMode.Open))
				{
					currentFile = MidiFile.Read(f);
					Log.Write(f.Name);
					Log.Write(currentFile.TimeDivision);
					Log.Write(currentFile.OriginalFormat);
					Log.Write(currentFile.GetDuration<MetricTimeSpan>());
					foreach (var track in currentFile.Chunks) Log.Write(track);
				}
			}
			catch (Exception e)
			{
				Log.Write(e);
				TreeRoot.Stop();
				return;
			}

			TreeRoot.TicksPerSecond = 255;
			pausing = false;
			started = true;
		}

		public override async Task AsyncRoot()
		{
			if (currentFile == null)
			{
				TreeRoot.Stop("No midi file selected!".ToUpper());
				return;
			}

			await Perform(currentFile);
		}

		public async Task Perform(MidiFile file)
		{
			var tempoMap = file.GetTempoMap();
			var notes = file.GetNotes().ToList();
			var tracks = file.GetTrackChunks().ToList();

			loop:
			for (var i = 0; i < notes.Count; i++)
			{
				if (started)
				{
					//Log.Write("clearing");
					started = false;
					return;
				}

				if (RaptureAtkUnitManager.GetWindowByName("PerformanceModeWide") == null)
				{
					if (RaptureAtkUnitManager.GetWindowByName("PerformanceMode") != null)
						Log.Write("Please enable \"Assign all notes to keyboard.\" in Performance Settings.");
					TreeRoot.Stop();
					return;
				}

				while (pausing) await Coroutine.Yield();

				var current = notes[i];
				var number = current.NoteNumber - 48 + noteOffset;

				if (MidiPlayerSettings.Instance.lognotes)
					Log.Write(
						$@"{GetTime(current).Minutes:00}:{GetTime(current).Seconds:00}.{GetTime(current).Milliseconds:000} {current}({number:00})");

				playNote(number);

				try
				{
					var sleepdura = GetTime(notes[i + 1]) - GetTime(current);
					var length = GetLength(current);
					if (sleepdura.TotalMicroseconds == 0)
					{
						releaseNote(number);
					}
					else
					{
						if (length > sleepdura)
						{
							await Coroutine.Sleep(new TimeSpan((long)(sleepdura.TotalMicroseconds * 10 /
																	   MidiPlayerSettings.Instance.speed)));
							releaseNote(number);
						}
						else
						{
							await Coroutine.Sleep(new TimeSpan((long)(length.TotalMicroseconds * 10 /
																	   MidiPlayerSettings.Instance.speed)));
							releaseNote(number);
							await Coroutine.Sleep(new TimeSpan((long)((sleepdura - length).TotalMicroseconds * 10 /
																	   MidiPlayerSettings.Instance.speed)));
						}
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					if (looping)
					{
						Log.Write("Looping.");
						goto loop;
					}

					TreeRoot.Stop("fin");
				}
			}

			MetricTimeSpan GetTime(Note current)
			{
				return current.TimeAs<MetricTimeSpan>(tempoMap);
			}

			MetricTimeSpan GetLength(Note current)
			{
				return current.LengthAs<MetricTimeSpan>(tempoMap);
			}
		}

		private void playNote(int noteNum)
		{
			if (noteNum < 0 || noteNum > 36) return;
			RaptureAtkUnitManager.GetWindowByName("PerformanceModeWide")?.SendAction(2, 3, 1, 4, (ulong)noteNum);
		}

		private void releaseNote(int noteNum)
		{
			if (noteNum < 0 || noteNum > 36) return;
			RaptureAtkUnitManager.GetWindowByName("PerformanceModeWide")?.SendAction(2, 3, 2, 4, (ulong)noteNum);
		}
	}

	internal class MidiPlayerSettings : JsonSettings
	{
		private static MidiPlayerSettings _settings;

		private bool _lognotes;
		
		private string _midifilepath;

		private double _speed;

		public MidiPlayerSettings() : base(Path.Combine(CharacterSettingsDirectory, "MidiPlayerSettings.json"))
		{
		}

		public static MidiPlayerSettings Instance => _settings ?? (_settings = new MidiPlayerSettings());

		public string midifilepath
		{
			get => _midifilepath;
			set
			{
				_midifilepath = value;
				Save();
			}
		}

		[DefaultValue(1d)]
		public double speed
		{
			get => _speed;
			set
			{
				_speed = value;
				Save();
			}
		}

		public bool lognotes
		{
			get => _lognotes;
			set
			{
				_lognotes = value;
				Save();
			}
		}
	}

	internal static class Log
	{
		public static void Write(object obj)
		{
			Logging.Write(Colors.PaleGreen, $"[MidiPerformer] {obj}");
		}
	}
}