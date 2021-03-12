using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security;

namespace WinsLock
{
    class SecureTextbox : TextBox
    {
        private SecureString sstrPassword;

        public override string Text
        {
            get
            {
                //return base.Text.toSecureString();
                //return sstrPassword;
                //return base.Text;
                return "a";
            }
            set
            {
                //base.Text = value.ToString();
                sstrPassword = value.toSecureString();
            }
        }

        public SecureString getText()
        {
            return sstrPassword;
        }
    }
}
