using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Connect2PayLibrary
{
    public class EncryptionHelper
    {
        public static byte[] ConvertFromBase64String(string input)
        {
            string working = input.Replace('-', '+').Replace('_', '/');
            while (working.Length % 3 != 0)
            {
                working += '=';
            }
            try
            {
                return Convert.FromBase64String(working);
            }
            catch (Exception)
            {
                // .Net core 2.1 bug
                // https://github.com/dotnet/corefx/issues/30793
                try
                {
                    return Convert.FromBase64String(input.Replace('-', '+').Replace('_', '/'));
                }
                catch (Exception) { }
                try
                {
                    return Convert.FromBase64String(input.Replace('-', '+').Replace('_', '/') + "=");
                }
                catch (Exception) { }
                try
                {
                    return Convert.FromBase64String(input.Replace('-', '+').Replace('_', '/') + "==");
                }
                catch (Exception) { }

                return null;
            }
        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
           
            //if (IV == null || IV.Length <= 0)
                //throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.Mode = CipherMode.ECB;
                aesAlg.Padding = PaddingMode.PKCS7;

                if (IV != null)
                {
                    aesAlg.IV = IV;
                }

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;
        }
    }


}