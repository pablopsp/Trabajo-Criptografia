using System.Collections.Generic;
using System.Linq;
using System.Text;
using XMLCreate;

namespace Criptografia.Services.XML
{
    public class Export
    {
        /// <summary>
        /// Exporta la clave publica RSA a un xml llamado 'cp_esclavo.xml'
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="filePathWithName"></param>
        public static void ExportPublicRSA(string publicKey, string filePathWithName)
        {
            IDictionary<string, string> dict = new Dictionary<string, string>
            {
                { "clavepublica", publicKey }
            };

            SimpleXMLCreate.FlatXML(dict, filePathWithName);
        }

        /// <summary>
        /// Exporta la clave tdes encriptada guardandolo como un array de bytes
        /// a un xml llamado 'tdesencriptado.xml'
        /// </summary>
        /// <param name="encryptedTDES"></param>
        /// <param name="filePathWithName"></param>
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

        /// <summary>
        /// Exporta el mensaje encriptado guardandolo como un array de bytes
        /// a un xml llamado 'textoencriptado.xml'
        /// </summary>
        /// <param name="msgEncrypted"></param>
        /// <param name="filePathWithName"></param>
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
