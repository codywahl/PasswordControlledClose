using System;
using System.Windows.Forms;

namespace PasswordControlledClose
{
    public partial class PasswordBox : Form
    {
        public PasswordBox()
        {
            InitializeComponent();

            textBox1.Text = "";
            textBox1.UseSystemPasswordChar = true;
            textBox1.MaxLength = 14;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            OkButtonClick();
        }

        private void OkButtonClick()
        {
            if (textBox1.Text.Trim() == password.thePassword)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                OkButtonClick();
            }
        }
    }
}