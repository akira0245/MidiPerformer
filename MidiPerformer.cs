//!CompilerOption:AddRef:Melanchall.DryWetMidi.dll
//!CompilerOption:Optimize:On
using System;
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
				{
					using (var f = new FileStream(fileDialog.FileName, FileMode.Open))
					{
						var loaded = MidiFile.Read(f);
						Log.Write(f.Name);
						Log.Write($"{loaded.OriginalFormat}, {loaded.TimeDivision}, Duration: {loaded.GetDuration<MetricTimeSpan>().Hours:00}:{loaded.GetDuration<MetricTimeSpan>().Minutes:00}:{loaded.GetDuration<MetricTimeSpan>().Seconds:00}:{loaded.GetDuration<MetricTimeSpan>().Milliseconds:000}");
						foreach (var track in loaded.Chunks) Log.Write(track);
					}

					MidiPlayerSettings.Instance.midifilepath = fileDialog.FileName;
				}
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
				using (var f = new FileStream(MidiPlayerSettings.Instance.midifilepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					currentFile = MidiFile.Read(f);
					Log.Write(f.Name);
					//Log.Write(currentFile.TimeDivision);
					//Log.Write(currentFile.OriginalFormat);
					//Log.Write(currentFile.GetDuration<MetricTimeSpan>());
					//foreach (var track in currentFile.Chunks) Log.Write(track);
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

		public override void Stop()
		{
			pausing = false;
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

				while (pausing) await Coroutine.Yield();

				if (RaptureAtkUnitManager.GetWindowByName("PerformanceMode") != null)
				{
					Log.Write("Please enable \"Assign all notes to keyboard.\" in Performance Settings.");
					TreeRoot.Stop();
					return;
				}

				while (RaptureAtkUnitManager.GetWindowByName("PerformanceModeWide") == null)
				{
					if (MidiPlayerSettings.Instance.pauseWhenNotInPerformanceMode)
					{
						await Coroutine.Yield();
					}
					else
					{
						TreeRoot.Stop();
						return;
					}
				}




				var current = notes[i];
				var length = GetLength(current);
				var number = current.NoteNumber - 48 + noteOffset;
				var adaptedOctave = 0;
				if (MidiPlayerSettings.Instance.autoAdaptNotes)
				{
					while (number < 0)
					{
						number += 12;
						adaptedOctave++;
					}
					while (number > 36)
					{
						number -= 12;
						adaptedOctave--;
					}
				}

				if (MidiPlayerSettings.Instance.lognotes)
					Log.Write(
						$"{GetTime(current).Minutes:00}:{GetTime(current).Seconds:00}.{GetTime(current).Milliseconds:000} {current} ({number:00}) " +
						$"{(number < 0 || number > 36 ? "(out of range)" : string.Empty)}" +
						$"{(MidiPlayerSettings.Instance.autoAdaptNotes && adaptedOctave != 0 ? $"[adapted {adaptedOctave} Oct]" : string.Empty)}");

				playNote(number);

				try
				{
					var sleepdura = GetTime(notes[i + 1]) - GetTime(current);
					if (sleepdura.TotalMicroseconds == 0)
					{
						releaseNote(number);
					}
					else
					{
						if (length > sleepdura)
						{
							await Coroutine.Sleep(new TimeSpan((long)(sleepdura.TotalMicroseconds * 10 / MidiPlayerSettings.Instance.speed)));
							releaseNote(number);
						}
						else
						{
							await Coroutine.Sleep(new TimeSpan((long)(length.TotalMicroseconds * 10 / MidiPlayerSettings.Instance.speed)));
							releaseNote(number);
							await Coroutine.Sleep(new TimeSpan((long)((sleepdura - length).TotalMicroseconds * 10 / MidiPlayerSettings.Instance.speed)));
						}
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					await Coroutine.Sleep(new TimeSpan((long)(length.TotalMicroseconds * 10 / MidiPlayerSettings.Instance.speed)));
					releaseNote(number);

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

	internal static class Log
	{
		public static void Write(object obj)
		{
			Logging.Write(Colors.PaleGreen, $"[MidiPerformer] {obj}");
		}
	}
}