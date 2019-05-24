using System;
using System.Linq;

namespace Criptografia.Services.Util
{
    public class ByteTransform
    {
        /// <summary>
        /// Devuelve un array de bytes que esta en un string
        /// </summary>
        /// <param name="arrayOfBytes"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Agrega un byte a un array de bytes
        /// </summary>
        /// <param name="bArray"></param>
        /// <param name="newByte"></param>
        /// <returns></returns>
        private static byte[] AddByteToArray(byte[] bArray, byte newByte)
        {
            byte[] newArr = new byte[bArray.Length + 1];
            bArray.CopyTo(newArr, 1);
            newArr[0] = newByte;
            return newArr;
        }

        /// <summary>
        /// Borra todos los ceros extras de bytes
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static byte[] DeleteZerosFromByteArray(byte[] array)
        {
            int lastIndex = Array.FindLastIndex(array, b => b != 0);
            Array.Resize(ref array, lastIndex + 1);
            return array;
        }
    }
}
