namespace MidiPerformer
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.checkbox_lognotes = new System.Windows.Forms.CheckBox();
			this.checkbox_adaptnotes = new System.Windows.Forms.CheckBox();
			this.checkbox_pause_when_not_in_mode = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			this.SuspendLayout();
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.DecimalPlaces = 2;
			this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDown1.Location = new System.Drawing.Point(12, 27);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(216, 25);
			this.numericUpDown1.TabIndex = 0;
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(12, 111);
			this.numericUpDown2.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
			this.numericUpDown2.Minimum = new decimal(new int[] {
            72,
            0,
            0,
            -2147483648});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(120, 25);
			this.numericUpDown2.TabIndex = 1;
			this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "Play Speed";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(143, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "NoteNumber Offset";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(138, 111);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(93, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Octave+";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(138, 142);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(93, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "Octave-";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(12, 142);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(120, 23);
			this.button3.TabIndex = 6;
			this.button3.Text = "Reset";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(12, 58);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(120, 23);
			this.button4.TabIndex = 7;
			this.button4.Text = "Reset";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button6
			// 
			this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button6.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
			this.button6.Location = new System.Drawing.Point(181, 262);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(50, 50);
			this.button6.TabIndex = 9;
			this.button6.Text = "⏹";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button5.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
			this.button5.Location = new System.Drawing.Point(124, 262);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(50, 50);
			this.button5.TabIndex = 10;
			this.button5.Text = "⏸";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button7
			// 
			this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button7.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button7.Location = new System.Drawing.Point(12, 262);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(50, 50);
			this.button7.TabIndex = 11;
			this.button7.Text = "🔂";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button8
			// 
			this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button8.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button8.Location = new System.Drawing.Point(68, 262);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(50, 50);
			this.button8.TabIndex = 12;
			this.button8.Text = "▶️";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// checkbox_lognotes
			// 
			this.checkbox_lognotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkbox_lognotes.AutoSize = true;
			this.checkbox_lognotes.Location = new System.Drawing.Point(12, 237);
			this.checkbox_lognotes.Name = "checkbox_lognotes";
			this.checkbox_lognotes.Size = new System.Drawing.Size(101, 19);
			this.checkbox_lognotes.TabIndex = 17;
			this.checkbox_lognotes.Text = "Log Notes";
			this.checkbox_lognotes.UseVisualStyleBackColor = true;
			this.checkbox_lognotes.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// checkbox_adaptnotes
			// 
			this.checkbox_adaptnotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkbox_adaptnotes.AutoSize = true;
			this.checkbox_adaptnotes.Location = new System.Drawing.Point(12, 212);
			this.checkbox_adaptnotes.Name = "checkbox_adaptnotes";
			this.checkbox_adaptnotes.Size = new System.Drawing.Size(221, 19);
			this.checkbox_adaptnotes.TabIndex = 18;
			this.checkbox_adaptnotes.Text = "Adapt notes out of range";
			this.checkbox_adaptnotes.UseVisualStyleBackColor = true;
			this.checkbox_adaptnotes.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// checkbox_pause_when_not_in_mode
			// 
			this.checkbox_pause_when_not_in_mode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkbox_pause_when_not_in_mode.Location = new System.Drawing.Point(12, 167);
			this.checkbox_pause_when_not_in_mode.Name = "checkbox_pause_when_not_in_mode";
			this.checkbox_pause_when_not_in_mode.Size = new System.Drawing.Size(221, 43);
			this.checkbox_pause_when_not_in_mode.TabIndex = 19;
			this.checkbox_pause_when_not_in_mode.Text = "Pause when not in performace mode";
			this.checkbox_pause_when_not_in_mode.UseVisualStyleBackColor = true;
			this.checkbox_pause_when_not_in_mode.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(240, 323);
			this.Controls.Add(this.checkbox_pause_when_not_in_mode);
			this.Controls.Add(this.checkbox_adaptnotes);
			this.Controls.Add(this.checkbox_lognotes);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDown2);
			this.Controls.Add(this.numericUpDown1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(258, 306);
			this.Name = "Form1";
			this.ShowIcon = false;
			this.Text = "MidiSetting";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.CheckBox checkbox_lognotes;
		private System.Windows.Forms.CheckBox checkbox_adaptnotes;
		private System.Windows.Forms.CheckBox checkbox_pause_when_not_in_mode;
	}
}