using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace mRemoteNGAlgorithm
{
    public class MRemoteCrypter
    {
        public string decrypt(string masterPassword, string encryptedPassword)
        {
            var md5 = MD5.Create();
            var hashedMasterPassword = md5.ComputeHash(Encoding.UTF8.GetBytes(masterPassword));

            var base64DecodedPasswordInDataBase = Convert.FromBase64String(encryptedPassword);

            var aes = Aes.Create();
            aes.BlockSize = 128;
            aes.Key = hashedMasterPassword;

            var ms = new MemoryStream(base64DecodedPasswordInDataBase);

            var iv = new byte[16];
            ms.Read(iv, 0, iv.Length);
            aes.IV = iv;

            var cryptoStream = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            var streamReader = new StreamReader(cryptoStream, Encoding.UTF8, true);

            return streamReader.ReadToEnd();
        }

        public string encrypt(string masterPassword, string plainPassword)
        {
            var md5 = MD5.Create();

            var aes = Aes.Create();
            aes.BlockSize = 128;
            aes.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(masterPassword));
            aes.GenerateIV();

            var ms = new MemoryStream();
            ms.Write(aes.IV, 0, 16);

            var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
            var data = Encoding.UTF8.GetBytes(plainPassword);

            cs.Write(data, 0, data.Length);
            cs.FlushFinalBlock();

            var encdata = ms.ToArray();

            return Convert.ToBase64String(encdata);
        }
    }
}