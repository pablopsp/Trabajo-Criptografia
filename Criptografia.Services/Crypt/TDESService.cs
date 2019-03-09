using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Criptografia.Services.Crypt
{
    public class TDESService
    {
        public static byte[] TDESKey => TripleDES.Create().Key;

        public static byte[] Encrypt(string textToEncrypt, byte[] keyTDES)
        {
            try
            {
                byte[] textBytes = Encoding.Default.GetBytes(textToEncrypt);
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider
                {
                    Key = md5.ComputeHash(keyTDES),
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                ICryptoTransform cryptoTransform = tdes.CreateEncryptor();
                byte[] encryptedText = cryptoTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);

                return encryptedText;
            }
            catch(CryptographicException ex)
            {
                return null;
            }
                       
        }

        public static string Decrypt(string textToDecrypt, byte[] keyTDES)
        {
            try
            {
                byte[] textBytes = Encoding.Default.GetBytes(textToDecrypt);
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider
                {
                    Key = md5.ComputeHash(keyTDES),
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                ICryptoTransform cryptoTransform = tdes.CreateDecryptor();
                byte[] decryptedText = cryptoTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                
                return Encoding.Default.GetString(decryptedText);
            }
            catch(CryptographicException ex)
            {
                return null;
            }            
        }
    }
}
