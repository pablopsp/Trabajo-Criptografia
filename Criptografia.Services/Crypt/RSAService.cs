using System.Security.Cryptography;
using XMLCreate;

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
    }
}
