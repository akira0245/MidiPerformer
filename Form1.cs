using System;
using System.Windows.Forms;
using ff14bot;

namespace MidiPerformer
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			numericUpDown1.Value = (decimal) MidiPlayerSettings.Instance.speed;
			numericUpDown2.Value = MidiPerformer.noteOffset;
			checkbox_lognotes.Checked = MidiPlayerSettings.Instance.lognotes;
			checkbox_adaptnotes.Checked = MidiPlayerSettings.Instance.autoAdaptNotes;
			checkbox_pause_when_not_in_mode.Checked = MidiPlayerSettings.Instance.pauseWhenNotInPerformanceMode;
			//checkedListBox1.Items.Clear();
			//checkedListBox1.Items.AddRange(MidiPerformer.currentFile.GetTrackChunks().ToArray());
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			MidiPlayerSettings.Instance.speed = (double) numericUpDown1.Value;
		}

		private void numericUpDown2_ValueChanged(object sender, EventArgs e)
		{
			MidiPerformer.noteOffset = (int) numericUpDown2.Value;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MidiPerformer.noteOffset += 12;
			numericUpDown2.Value = MidiPerformer.noteOffset;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MidiPerformer.noteOffset -= 12;
			numericUpDown2.Value = MidiPerformer.noteOffset;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			MidiPlayerSettings.Instance.speed = 1;
			numericUpDown1.Value = (decimal) MidiPlayerSettings.Instance.speed;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			MidiPerformer.noteOffset = 0;
			numericUpDown2.Value = MidiPerformer.noteOffset;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (!TreeRoot.IsRunning) return;
			MidiPerformer.pausing = true;
			Log.Write("paused".ToUpper());
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (TreeRoot.IsRunning) TreeRoot.StopGently();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			if (!TreeRoot.IsRunning)
			{
				TreeRoot.Start();
			}
			else
			{
				MidiPerformer.pausing = false;
				Log.Write("resumed".ToUpper());
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			MidiPerformer.looping = !MidiPerformer.looping;
			Log.Write(MidiPerformer.looping ? "looping enabled".ToUpper() : "looping disabled".ToUpper());
			button7.ForeColor = MidiPerformer.looping ? System.Drawing.SystemColors.HotTrack : System.Drawing.SystemColors.ControlText;
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			MidiPlayerSettings.Instance.lognotes = checkbox_lognotes.Checked;
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			MidiPlayerSettings.Instance.autoAdaptNotes = checkbox_adaptnotes.Checked;
		}

		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			MidiPlayerSettings.Instance.pauseWhenNotInPerformanceMode = checkbox_pause_when_not_in_mode.Checked;
		}
	}
}