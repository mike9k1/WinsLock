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
    public partial class LockForm : Form
    {

        bool boolAltF4 = false;
        SecureString sstrPassword;
        int intCharCount;
        int intCheckCounter;

        public LockForm()
        {
            InitializeComponent();
        }

        private void LockForm_Load(object sender, EventArgs e)
        {
            this.Show();
        }

        public void Start(object sender, EventArgs e, SecureString password)
        {
            sstrPassword = password;
            LockForm_Load(sender, e);
        }

        private void LockForm_LostFocus(object sender, EventArgs e)
        {
            this.BringToFront();
            this.Focus();
        }

        private void tLock_Tick(object sender, EventArgs e)
        {
            this.BringToFront();
            this.Focus();
        }

        private void HandleKeys(object sender, KeyEventArgs e)
        {
            
            string strKeyPress = e.KeyData.ToString();
            SecureString sstrPassChar = sstrPassword.getSubstring(intCharCount, 1);
            char chrKeyPress = Convert.ToChar(e.KeyValue);

            boolAltF4 = (e.KeyCode.Equals(Keys.F4) && (e.Alt == true));

            if (sstrPassChar.toUpper().compareString(strKeyPress) || sstrPassChar.compareChar(chrKeyPress) )
            {
                if (intCharCount == (sstrPassword.Length - 1)) this.Close();
                intCharCount += 1;
            }

            if (intCharCount > 0) intCheckCounter += 1;
            if ((intCheckCounter == (intCharCount + (sstrPassword.Length / 3))) || (intCheckCounter == (intCharCount + 4)))
            {
                intCheckCounter = 0;
                intCharCount = 0;
            }

            //MessageBox.Show(sstrPassChar.toUpper().getChar(0));

        }

        private void LockForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (boolAltF4)
            {
                e.Cancel = true;
                return;
            }

        }



    }
}
