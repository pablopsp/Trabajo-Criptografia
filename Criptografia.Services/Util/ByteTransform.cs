using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptografia.Services.Util
{
    public class ByteTransform
    {
        public static byte[] GetByteArrayOnString(string arrayOfBytes)
        {
            string[] splitedString = arrayOfBytes.Split(new char[] { ',' });
            byte[] byteArray = new byte[splitedString.Length];

            foreach (string byteInt in splitedString)
            {
                byte newByte = byte.Parse(byteInt);
                byteArray = AddByteToArray(byteArray, newByte);
            }

            byteArray = DeleteZerosFromByteArray(byteArray);
            byte[] reversedByteArray = byteArray.Reverse().ToArray();

            return reversedByteArray;
        }

        private static byte[] AddByteToArray(byte[] bArray, byte newByte)
        {
            byte[] newArr = new byte[bArray.Length + 1];
            bArray.CopyTo(newArr, 1);
            newArr[0] = newByte;
            return newArr;
        }

        private static byte[] DeleteZerosFromByteArray(byte[] array)
        {
            int lastIndex = Array.FindLastIndex(array, b => b != 0);
            Array.Resize(ref array, lastIndex + 1);
            return array;
        }
    }
}
