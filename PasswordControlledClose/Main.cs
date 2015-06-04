using System;
using System.Drawing;
using System.Runtime.InteropServices; // Needed for mouse move
using System.Windows.Forms;

namespace PasswordControlledClose
{
    public partial class Main : Form
    {
        //Data Members
        private const int WM_NCLBUTTONDOWN = 0xA1;

        private const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        public Main()
        {
            InitializeComponent();
            this.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (var pb = new PasswordBox())
            {
                var result = pb.ShowDialog();

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void KeepCursorInBounds()
        {
            if (Cursor.Position.X < this.Bounds.X)
                Cursor.Position = new Point(this.Bounds.X + 1, Cursor.Position.Y);
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void Main_MouseLeave(object sender, EventArgs e)
        {
            KeepCursorInBounds();
        }
    }
}