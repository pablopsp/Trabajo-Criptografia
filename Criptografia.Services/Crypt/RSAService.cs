using Criptografia.Services.Util;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Criptografia.Services.Crypt
{
    public class RSAService
    {
        /// <summary>
        /// Genera una nueva clave RSA publica y privada 
        /// </summary>
        /// <returns>Public and private RSA key</returns>
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

        /// <summary>
        /// Encripta las 3 claves TDES y el IV
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="RSAPublicKey"></param>
        /// <returns>Llaves e IV TDES encriptado</returns>
        public static IEnumerable<byte[]> EncryptTDES(IEnumerable<string> keys, string RSAPublicKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(RSAPublicKey);

            List<byte[]> encryptedKeys = new List<byte[]>();
            try
            {
                foreach (var item in keys)
                {
                    encryptedKeys.Add(rsa.Encrypt(ByteTransform.HexStringToByteArray(item), true));
                }
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }

            return encryptedKeys;
        }

        /// <summary>
        /// Desencripta un array de bytes
        /// </summary>
        /// <param name="encryptedMessage"></param>
        /// <param name="RSAPrivateKey"></param>
        /// <returns>Decrypted value</returns>
        public static byte[] Decrypt(byte[] encryptedMessage, string RSAPrivateKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(RSAPrivateKey);

            byte[] msgDecrypted;
            try
            {
                msgDecrypted = rsa.Decrypt(encryptedMessage, true);
            }
            catch(CryptographicException ex)
            {
                throw ex;
            }
            return msgDecrypted;
        }
    }
}
