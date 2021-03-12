using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;

namespace WinsLock
{
    public static class SecureStringExtension
    {
        public static SecureString toSecureString(this string src)
        {
            if (string.IsNullOrWhiteSpace(src))
                return null;
            else
            {
                SecureString secstr = new SecureString();
                foreach (char c in src.ToCharArray())
                    secstr.AppendChar(c);
                return secstr;
            }
        }

        public static SecureString getSubstring(this SecureString src, int start, int length)
        {
            string str = new System.Net.NetworkCredential(string.Empty, src).Password.Substring(start, length);
            return str.toSecureString();
        }

        public static SecureString toUpper(this SecureString src)
        {
            string str = new System.Net.NetworkCredential(string.Empty, src).Password.ToUpper();
            return str.toSecureString();
        }

        public static void removeChars(this SecureString src, int index)
        {
            src = new System.Net.NetworkCredential(string.Empty, src).Password.Remove(index).toSecureString();
        }

        public static string getChar(this SecureString src, int location)
        {
            string str = new System.Net.NetworkCredential(string.Empty, src).Password.Substring(location, 1);
            return str;
        }

        public static bool compareString(this SecureString src, string toBeCompared)
        {
            return toBeCompared.Equals(new System.Net.NetworkCredential(string.Empty, src).Password);
        }

        public static bool compareChar(this SecureString src, char toBeCompared)
        {
            return toBeCompared.Equals(new System.Net.NetworkCredential(string.Empty, src).Password.ToCharArray()[0]);
        }

        public static bool compareCharArray(this SecureString src, char[] toBeCompared)
        {
            return toBeCompared.Equals(new System.Net.NetworkCredential(string.Empty, src).Password.ToCharArray());
        }
    }
}
