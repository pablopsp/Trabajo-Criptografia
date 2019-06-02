using System;
using System.Linq;

namespace Criptografia.Services.Util
{
    public class ByteTransform
    {
        public static byte[] HexStringToByteArray(string hex)
        {
            string hexVal = DeleteSpacesFromHex(hex);
            return Enumerable.Range(0, hexVal.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(hexVal.Substring(x, 2), 16))
                     .ToArray();
        }

        public static string DeleteSpacesFromHex(string input) => string.Join("", input.Split('-'));
    }
}
