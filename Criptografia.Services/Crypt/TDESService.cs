using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Criptografia.Services.Crypt
{
    public class TDESService
    {
        public static byte[] TDESKey => TripleDES.Create().Key;
        public static byte[] TDESIV => TripleDES.Create().IV;
    }
}
