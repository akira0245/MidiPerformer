using System.ComponentModel;
using System.IO;
using ff14bot.Helpers;

namespace MidiPerformer
{
	internal class MidiPlayerSettings : JsonSettings
	{
		private static MidiPlayerSettings _settings;

		public MidiPlayerSettings() : base(Path.Combine(CharacterSettingsDirectory, "MidiPlayerSettings.json"))
		{
		}

		public static MidiPlayerSettings Instance => _settings ?? (_settings = new MidiPlayerSettings());

		private string _midifilepath;
		public string midifilepath
		{
			get => _midifilepath;
			set
			{
				_midifilepath = value;
				Save();
			}
		}

		private double _speed;
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

		private bool _lognotes;
		public bool lognotes
		{
			get => _lognotes;
			set
			{
				_lognotes = value;
				Save();
			}
		}

		private bool _autoAdaptNotes;
		public bool autoAdaptNotes
		{
			get => _autoAdaptNotes;
			set
			{
				_autoAdaptNotes = value;
				Save();
			}
		}

		private bool _pauseWhenNotInPerformanceMode;
		public bool pauseWhenNotInPerformanceMode
		{
			get => _pauseWhenNotInPerformanceMode;
			set
			{
				_pauseWhenNotInPerformanceMode = value;
				Save();
			}
		}
	}
}