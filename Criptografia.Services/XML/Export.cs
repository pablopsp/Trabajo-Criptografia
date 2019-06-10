using Criptografia.Services.Util;
using System;
using System.Collections.Generic;
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
        /// Exporta las claves tdes y el IV a un xml
        /// con el nombre 'tdesencriptado.xml'
        /// </summary>
        /// <param name="encryptedTDES"></param>
        /// <param name="filePathWithName"></param>
        public static void ExportTDES(string encryptedTDES, string filePathWithName)
        {
            string[] keys = ByteTransform.DeleteSpacesFromHex(encryptedTDES).Split(new[] {"\r\n"}, StringSplitOptions.None);
            IDictionary<string, string> values = new Dictionary<string, string>()
            {
                { "tdes1", keys[0] },
                { "tdes2", keys[1] },
                { "tdes3", keys[2] },
                { "iv", keys[3] }
            };

            SimpleXMLCreate.FlatXML(values, filePathWithName);
        }

        /// <summary>
        /// Exporta el mensaje encriptado en forma hexadecimal
        /// a un xml con el nombre 'textoencriptado.xml'
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="hexString"></param>
        /// <param name="filePathWithName"></param>
        public static void ExportHexStringToXML(string nodeName, string hexString, string filePathWithName) =>
            SimpleXMLCreate.FlatXML(new Dictionary<string, string> { { nodeName, hexString } }, filePathWithName);
    }
}
