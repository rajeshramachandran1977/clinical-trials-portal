using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Anju.Navigate.Utilities
{
    public class EncrypPassword
    {
        static string EncryptionKey = ConstDefaultValue.SecurityKey;

        /// <summary>
        /// Encrypt
        /// </summary>
        /// <param name="passwordText"></param>
        /// <returns>Convert.ToBase64String(b1, 0, b1.Length)</returns>
        public static string Encrypt(string passwordText)
        {
            SHA1CryptoServiceProvider hashProvider = new SHA1CryptoServiceProvider();
            byte[] b = System.Text.Encoding.UTF8.GetBytes(passwordText);
            byte[] b1 = hashProvider.ComputeHash(b, 0, b.Length);

            return Convert.ToBase64String(b1, 0, b1.Length);
        }

        /// <summary>
        /// EncryptusingRFC
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns>clearText</returns>
        public static string EncryptusingRFC(string clearText)
        {
            var clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }

                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }

            return clearText;
        }

        /// <summary>
        /// DecryptusingRFC
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns>cipherText</returns>
        public static string DecryptusingRFC(string cipherText)
        {
            cipherText = cipherText.Replace(" ", "");          
            var cipherBytes = Convert.FromBase64String(cipherText);

            using (Aes encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }

                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
