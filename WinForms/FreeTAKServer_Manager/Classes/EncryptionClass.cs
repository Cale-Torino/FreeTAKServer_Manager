using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace FreeTAKServer_Manager
{
    public static class EncryptionClass
    {
        static byte[] Entropy = Encoding.Unicode.GetBytes("15021375505qpwoeirutyalskdjfhgmznxbcv");//salt

        public static string EncryptString(SecureString Input)
        {
            byte[] EncryptedData = ProtectedData.Protect(Encoding.Unicode.GetBytes(ToInsecureString(Input)), Entropy, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(EncryptedData);
        }

        public static SecureString DecryptString(string EncryptedData)
        {
            try
            {
                byte[] DecryptedData = ProtectedData.Unprotect(Convert.FromBase64String(EncryptedData), Entropy, DataProtectionScope.CurrentUser);
                return ToSecureString(Encoding.Unicode.GetString(DecryptedData));
            }
            catch
            {
                return new SecureString();
            }
        }

        public static SecureString ToSecureString(string Input)
        {
            SecureString Secure = new SecureString();
            foreach (char Char in Input)
            {
                Secure.AppendChar(Char);
            }
            Secure.MakeReadOnly();
            return Secure;
        }

        public static string ToInsecureString(SecureString Input)
        {
            string ReturnValue = string.Empty;
            IntPtr Pointer = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(Input);
            try
            {
                ReturnValue = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(Pointer);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(Pointer);
            }
            return ReturnValue;
        }
    }
}
