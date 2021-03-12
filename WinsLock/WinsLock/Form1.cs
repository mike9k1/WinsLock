using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security;

namespace WinsLock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            LockForm lf;

            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter a password (and REMEMBER it) before continuing", "Enter a valid password");
                return;
            }
            else if (txtPassword.Text.Any(ch => !Char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Please enter only letters and digits in the password -- special characters are not supported (yet)", "Special characters unsupported");
                return;
            }

            if (Screen.AllScreens.Length > 1)
            {
                multiMonitor(sender, e);
                return;
            }

            lf = new LockForm();
            try
            {
                lf.BackColor = Color.FromName(cmbScreensaver.SelectedItem.ToString());
            }
            catch (ArgumentException ex)
            {
                //'MessageBox.Show("Invalid screensaver selection -- please try again", "Invalid Color")
                //'Return
                lf.BackColor = Color.Black;
            }
            catch (NullReferenceException ex)
            {
                lf.BackColor = Color.Black;
            }

            SecureString password = txtPassword.Text.toSecureString();
            txtPassword.Text = "";

            lf.Start(sender, e, password);
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private bool checkSpecialChars(string str)
        {
            foreach (char ch in str.ToCharArray())
            {
                if (!Char.IsLetterOrDigit(ch)) return true;
            }
            return false;
        }

        private void multiMonitor(object sender, EventArgs e)
        {
            List<LockForm> lfl = new List<LockForm>();
            LockForm lf;

            foreach (Screen scr in Screen.AllScreens)
            {
                lf = new LockForm();
                lfl.Add(lf);
                lf.StartPosition = FormStartPosition.Manual;
                lf.SetBounds(scr.Bounds.X, scr.Bounds.Y, scr.Bounds.Width, scr.Bounds.Height);
                try
                {
                    lf.BackColor = Color.FromName(cmbScreensaver.SelectedItem.ToString());
                }
                catch (ArgumentException ex)
                {
                    //'MessageBox.Show("Invalid screensaver selection -- please try again", "Invalid Color")
                    //'Return
                    lf.BackColor = Color.Black;
                }
                catch (NullReferenceException ex)
                {
                    lf.BackColor = Color.Black;
                }

                lf.Start(sender, e, txtPassword.Text.toSecureString());
            }
        }

    }
}
