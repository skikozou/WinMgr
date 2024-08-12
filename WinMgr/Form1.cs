using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WinMgr
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void ResizableRectangle_SizeChanged(object sender, EventArgs e)
		{
			ResizableRectangle rect = sender as ResizableRectangle;
			MoveWindow(Handle, rect.Location.X * ratio, rect.Location.Y * ratio, rect.Size.Width * ratio, rect.Size.Height * ratio, true);
			Debug.WriteLine($"New size: {rect.Size}, New location: {rect.Location}");
		}
		private void Form1_Shown(object sender, EventArgs e)
		{
			var resizableRectangle = new ResizableRectangle
			{
				Location = new Point(50, 50)
			};
			resizableRectangle.SizeChanged += ResizableRectangle_SizeChanged;

			this.panel1.Controls.Add(resizableRectangle);
			panel1.Size = new Size(Screen.PrimaryScreen.Bounds.Width / ratio, Screen.PrimaryScreen.Bounds.Height / ratio);
			Width = panel1.Size.Width + 27;
			panel1.BackColor = Color.White;
			Debug.WriteLine(ratio);
		}
		private int ratio = 4;
		private nint Handle = new nint();
		private int MoveN = 10;
		public void button1_Click(object sender, EventArgs e)
		{
			RECT rect;
			if (GetWindowRect(Handle, out rect))
			{
				MoveWindow(Handle, rect.Left, rect.Top - MoveN, rect.Right - rect.Left, rect.Bottom - rect.Top, true);
			}
		}
		public void button2_Click(object sender, EventArgs e)
		{
			RECT rect;
			if (GetWindowRect(Handle, out rect))
			{
				MoveWindow(Handle, rect.Left, rect.Top + MoveN, rect.Right - rect.Left, rect.Bottom - rect.Top, true);
			}
		}
		public void button3_Click(object sender, EventArgs e)
		{
			RECT rect;
			if (GetWindowRect(Handle, out rect))
			{
				MoveWindow(Handle, rect.Left - MoveN, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top, true);
			}
		}
		public void button4_Click(object sender, EventArgs e)
		{
			RECT rect;
			if (GetWindowRect(Handle, out rect))
			{
				MoveWindow(Handle, rect.Left + MoveN, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top, true);
			}
		}
		private void button5_Click(object sender, EventArgs e)
		{
			uint targetPid = uint.Parse(textBox1.Text);

			IntPtr windowHandle = IntPtr.Zero;
			EnumWindows((hWnd, lParam) =>
			{
				GetWindowThreadProcessId(hWnd, out uint pid);
				if (pid == targetPid)
				{
					windowHandle = hWnd;
					return false;
				}
				return true;
			}, IntPtr.Zero);

			if (windowHandle != IntPtr.Zero)
			{
				Handle = windowHandle;
			}
			else
			{
				Debug.WriteLine("Window not found.");
			}
		}
		private void button6_Click(object sender, EventArgs e)
		{
			RECT rect;
			if (GetWindowRect(Handle, out rect))
			{
				MoveWindow(Handle, rect.Left + MoveN / 2, rect.Top + MoveN / 2, rect.Right - rect.Left - MoveN, rect.Bottom - rect.Top - MoveN, true);
			}
		}
		private void button7_Click(object sender, EventArgs e)
		{
			RECT rect;
			if (GetWindowRect(Handle, out rect))
			{
				MoveWindow(Handle, rect.Left - MoveN / 2, rect.Top - MoveN / 2, rect.Right - rect.Left + MoveN, rect.Bottom - rect.Top + MoveN, true);
			}
		}
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			KeyPreview = checkBox1.Checked;
		}
		public void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			RECT rect;
			if (GetWindowRect(Handle, out rect))
			{
				switch (e.KeyCode)
				{
					case Keys.W:
						MoveWindow(Handle, rect.Left, rect.Top - MoveN, rect.Right - rect.Left, rect.Bottom - rect.Top, true);
						break;
					case Keys.S:
						MoveWindow(Handle, rect.Left, rect.Top + MoveN, rect.Right - rect.Left, rect.Bottom - rect.Top, true);
						break;
					case Keys.A:
						MoveWindow(Handle, rect.Left - MoveN, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top, true);
						break;
					case Keys.D:
						MoveWindow(Handle, rect.Left + MoveN, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top, true);
						break;
					case Keys.Space:
						MoveWindow(Handle, rect.Left - MoveN / 2, rect.Top - MoveN / 2, rect.Right - rect.Left + MoveN, rect.Bottom - rect.Top + MoveN, true);
						break;
					case Keys.ShiftKey:
						MoveWindow(Handle, rect.Left + MoveN / 2, rect.Top + MoveN / 2, rect.Right - rect.Left - MoveN, rect.Bottom - rect.Top - MoveN, true);
						break;
				}
			}
		}

		// WinAPIä÷êî
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			MoveN = int.Parse(textBox2.Text);
		}


		private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

		private struct RECT
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
		}
	}
}
