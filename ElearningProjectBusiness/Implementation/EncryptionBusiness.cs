using ElearningProjectBusiness.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ElearningProjectBusiness.Implementation
{
    public class EncryptionBusiness : IEncryptionBusiness
    {
        public string PlainTextEncryption(string AESToken,string key)
        {
            return Convert.ToBase64String(EncryptionAlgorithm(AESToken, key));
        }

        private string GenerateAESKey(string GUID)
        {
            return GUID.Substring(0,16);
        }

        private byte[] EncryptionAlgorithm(string AESToken, string key)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(GenerateAESKey(key));
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(AESToken);
                        }
                        array = memoryStream.ToArray();
                    }
                }
            }
            return array;
        }

        public string DecryptText(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(GenerateAESKey(key));
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
