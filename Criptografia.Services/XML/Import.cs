using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptografia.Services.XML
{
    public class Import
    {
        public static object ImportPublicRSA(string path)
        {
            return XMLParser.SimpleXMLParser.GetDataFromSimpleNode(path, "clavepublica");
        }
    }
}
