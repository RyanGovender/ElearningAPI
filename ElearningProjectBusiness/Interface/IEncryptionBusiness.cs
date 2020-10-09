using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectBusiness.Interface
{
    public interface IEncryptionBusiness
    {
        string PlainTextEncryption(string AESToken,string key);
        string DecryptText(string key, string cipherText);
    }
}
