using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Test
{
    public class Generic
    {
        private static SymmetricAlgorithm mobjCryptoService = DES.Create();
        public byte[] Encrypto(byte[] bytIn, string key)
        {
            MemoryStream memoryStream = new MemoryStream();
            mobjCryptoService.Key = this.GetLegalKey(key);
            mobjCryptoService.IV = this.GetLegalIV();
            ICryptoTransform encryptor = mobjCryptoService.CreateEncryptor();
            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(bytIn, 0, bytIn.Length);
            cryptoStream.FlushFinalBlock();
            memoryStream.Close();
            return memoryStream.ToArray();
        }
        private byte[] GetLegalKey(string key)
        {
            string s = key;
            mobjCryptoService.GenerateKey();
            int length = mobjCryptoService.Key.Length;
            if (s.Length > length)
                s = s.Substring(0, length);
            else if (s.Length < length)
                s = s.PadRight(length, ' ');
            return Encoding.ASCII.GetBytes(s);
        }

        private byte[] GetLegalIV()
        {
            string s = "E4ghj*Ghg7!rNIfb&95GUY86GfghUb#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";
            mobjCryptoService.GenerateIV();
            int length = mobjCryptoService.IV.Length;
            if (s.Length > length)
                s = s.Substring(0, length);
            else if (s.Length < length)
                s = s.PadRight(length, ' ');
            return Encoding.ASCII.GetBytes(s);
        }
    }
}
