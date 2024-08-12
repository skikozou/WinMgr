using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinMgr
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			button4 = new Button();
			textBox1 = new TextBox();
			label1 = new Label();
			checkBox1 = new CheckBox();
			panel1 = new Panel();
			button5 = new Button();
			checkBox2 = new CheckBox();
			button6 = new Button();
			button7 = new Button();
			textBox2 = new TextBox();
			label2 = new Label();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new Point(139, 12);
			button1.Name = "button1";
			button1.Size = new Size(122, 94);
			button1.TabIndex = 0;
			button1.Text = "UP";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.Location = new Point(139, 112);
			button2.Name = "button2";
			button2.Size = new Size(122, 85);
			button2.TabIndex = 1;
			button2.Text = "DOWN";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// button3
			// 
			button3.Location = new Point(11, 71);
			button3.Name = "button3";
			button3.Size = new Size(122, 75);
			button3.TabIndex = 2;
			button3.Text = "LEFT";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// button4
			// 
			button4.Location = new Point(267, 71);
			button4.Name = "button4";
			button4.Size = new Size(122, 75);
			button4.TabIndex = 3;
			button4.Text = "RIGHT";
			button4.UseVisualStyleBackColor = true;
			button4.Click += button4_Click;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(11, 15);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(121, 23);
			textBox1.TabIndex = 4;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(11, -1);
			label1.Name = "label1";
			label1.Size = new Size(72, 15);
			label1.TabIndex = 5;
			label1.Text = "Window PID";
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Location = new Point(270, 3);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(100, 19);
			checkBox1.TabIndex = 6;
			checkBox1.Text = "WASD control";
			checkBox1.UseVisualStyleBackColor = true;
			checkBox1.CheckedChanged += checkBox1_CheckedChanged;
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.Control;
			panel1.Location = new Point(5, 207);
			panel1.Name = "panel1";
			panel1.Size = new Size(398, 274);
			panel1.TabIndex = 7;
			// 
			// button5
			// 
			button5.Location = new Point(12, 37);
			button5.Name = "button5";
			button5.Size = new Size(120, 28);
			button5.TabIndex = 8;
			button5.Text = "get handle";
			button5.UseVisualStyleBackColor = true;
			button5.Click += button5_Click;
			// 
			// checkBox2
			// 
			checkBox2.AutoSize = true;
			checkBox2.Location = new Point(376, 5);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new Size(15, 14);
			checkBox2.TabIndex = 9;
			checkBox2.UseVisualStyleBackColor = true;
			// 
			// button6
			// 
			button6.Location = new Point(12, 152);
			button6.Name = "button6";
			button6.Size = new Size(120, 45);
			button6.TabIndex = 10;
			button6.Text = "ZOOM DOWN";
			button6.UseVisualStyleBackColor = true;
			button6.Click += button6_Click;
			// 
			// button7
			// 
			button7.Location = new Point(267, 152);
			button7.Name = "button7";
			button7.Size = new Size(122, 45);
			button7.TabIndex = 11;
			button7.Text = "ZOOM UP";
			button7.UseVisualStyleBackColor = true;
			button7.Click += button7_Click;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(270, 42);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(119, 23);
			textBox2.TabIndex = 12;
			textBox2.Text = "10";
			textBox2.TextChanged += textBox2_TextChanged;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(270, 23);
			label2.Name = "label2";
			label2.Size = new Size(46, 15);
			label2.TabIndex = 13;
			label2.Text = "MoveN";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(408, 485);
			Controls.Add(label2);
			Controls.Add(textBox2);
			Controls.Add(button7);
			Controls.Add(button6);
			Controls.Add(checkBox2);
			Controls.Add(button5);
			Controls.Add(panel1);
			Controls.Add(checkBox1);
			Controls.Add(label1);
			Controls.Add(textBox1);
			Controls.Add(button4);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Name = "Form1";
			Text = "Window Controller";
			Shown += Form1_Shown;
			KeyDown += Form1_KeyDown;
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion

		private Button button1;
		private Button button2;
		private Button button3;
		private Button button4;
		private TextBox textBox1;
		private Label label1;
		private CheckBox checkBox1;
		private Panel panel1;
		private Button button5;
		private CheckBox checkBox2;
		private Button button6;
		private Button button7;
		private TextBox textBox2;
		private Label label2;
	}
}
