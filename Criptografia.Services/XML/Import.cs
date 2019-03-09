using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptografia.Services.XML
{
    public class Import
    {
        public static object ImportPublicRSA(string path) => XMLParser.SimpleXMLParser.GetDataFromSimpleNode(path, "clavepublica");

        public static object ImportEncryptedTDES(string path) => XMLParser.SimpleXMLParser.GetDataFromSimpleNode(path, "tdes");

        public static object ImportEncryptedMssg(string path) => XMLParser.SimpleXMLParser.GetDataFromSimpleNode(path, "textoe");
    }
}
