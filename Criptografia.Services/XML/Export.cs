using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLCreate;

namespace Criptografia.Services.XML
{
    public class Export
    {
        public static void ExportPublicRSA(string publicKey, string filePathWithName)
        {
            IDictionary<string, string> dict = new Dictionary<string, string>
            {
                { "clavepublica", publicKey }
            };

            SimpleXMLCreate.FlatXML(dict, filePathWithName);
        }

        public static void ExportEncryptedTDES(string encryptedTDES, string filePathWithName)
        {
            byte[] bytesTDES = Encoding.Default.GetBytes(encryptedTDES);
            List<byte> list = bytesTDES.OfType<byte>().ToList();
            string complete = null;

            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count-1)
                    complete += list[i];
                else
                    complete += list[i] + ",";
            }

            IDictionary<string, string> dict = new Dictionary<string, string>
            {
                { "tdes", complete }
            };

            SimpleXMLCreate.FlatXML(dict, filePathWithName);
        }

        public static void ExportEncryptedMessage(string msgEncrypted, string filePathWithName)
        {
            byte[] bytesTDES = Encoding.Default.GetBytes(msgEncrypted);
            List<byte> list = bytesTDES.OfType<byte>().ToList();
            string complete = null;

            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                    complete += list[i];
                else
                    complete += list[i] + ",";
            }

            IDictionary<string, string> dict = new Dictionary<string, string>
            {
                { "textoe", complete }
            };

            SimpleXMLCreate.FlatXML(dict, filePathWithName);
        }
    }
}
