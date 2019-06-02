using Criptografia.Services.Util;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Criptografia.Services.Crypt
{
    public class RSAService
    {
        public static string[] GeneratePrivateAndPublicKey()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(512)
            { 
                PersistKeyInCsp = false
            };

            return new string[]
            {
                rsa.ToXmlString(false),
                rsa.ToXmlString(true)
            };
        }

        public static IEnumerable<byte[]> EncryptTDES(IEnumerable<string> keys, string RSAPublicKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(RSAPublicKey);

            List<byte[]> encryptedKeys = new List<byte[]>();
            try
            {
                foreach (var item in keys)
                {
                    encryptedKeys.Add(rsa.Encrypt(ByteTransform.HexStringToByteArray(item), false));
                }
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }

            return encryptedKeys;
        }

        public static byte[] Decrypt(byte[] encryptedMessage, string RSAPrivateKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(RSAPrivateKey);

            byte[] msgDecrypted;
            try
            {
                msgDecrypted = rsa.Decrypt(encryptedMessage, false);
            }
            catch(CryptographicException ex)
            {
                throw ex;
            }
            return msgDecrypted;
        }
    }
}
