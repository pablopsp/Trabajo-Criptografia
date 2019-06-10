using Criptografia.Services.Util;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Criptografia.Services.Crypt
{
    public class TDESService
    {
        private static byte[] TDESKey;
        public static byte[] TDESIv;
        public static IEnumerable<string> Keys = TripleKeys();

        /// <summary>
        /// Crea el IV y la clave TDES la cual divide en 3
        /// </summary>
        /// <returns>IEnumerable string (keys)</returns>
        private static IEnumerable<string> TripleKeys()
        {
            IEnumerable<string> result;

        ReDoit:
            if (TDESKey != null)
            {               
                string key = ByteTransform.DeleteSpacesFromHex(BitConverter.ToString(TDESKey));

                result = new List<string>()
                {
                    key.Substring(0, 16),
                    key.Substring(16, 16),
                    key.Substring(32, 16)
                };
            }
            else
            {
                TDESKey = TripleDES.Create().Key;
                TDESIv = TripleDES.Create().IV;
                goto ReDoit;
            }

            return result;
        }

        /// <summary>
        /// Encripta un string hexadecimal
        /// </summary>
        /// <param name="textToEncrypt"></param>
        /// <param name="keyTDES"></param>
        /// <returns>Encrypted data</returns>
        public static byte[] Encrypt(string textToEncrypt, byte[] keyTDES)
        {
            try
            {
                byte[] textBytes = Encoding.Default.GetBytes(textToEncrypt);
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyTDES,
                    IV = TDESIv,
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                };
                ICryptoTransform cryptoTransform = tdes.CreateEncryptor();
                byte[] encryptedText = cryptoTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);

                return encryptedText;
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Desencripta un string encriptado en forma hexadecimal
        /// </summary>
        /// <param name="textToDecrypt"></param>
        /// <param name="keyTDES"></param>
        /// <returns>Decrypted data</returns>
        public static byte[] Decrypt(string textToDecrypt, byte[] keyTDES)
        {
            try
            {
                byte[] textBytes = ByteTransform.HexStringToByteArray(textToDecrypt);
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyTDES,
                    IV = TDESIv,
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                };
                ICryptoTransform cryptoTransform = tdes.CreateDecryptor();
                byte[] decryptedText = cryptoTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);

                return decryptedText;
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
        }
    }
}
