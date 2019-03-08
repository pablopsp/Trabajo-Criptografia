using System.Security.Cryptography;
using System;
using System.Text;

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

        public static byte[] Encrypt(string messageToEncrypt, string RSAPublicKey)
        {
            byte[] byteMessage = Encoding.Default.GetBytes(messageToEncrypt);

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(RSAPublicKey);
            byte[] msgEncrypted = rsa.Encrypt(byteMessage, false);

            return msgEncrypted;
        }

        public static byte[] Decrypt(byte[] encryptedMessage, string RSAPrivateKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(RSAPrivateKey);
            byte[] msgDecrypted = rsa.Decrypt(encryptedMessage, false);

            return msgDecrypted;
        }
    }
}
