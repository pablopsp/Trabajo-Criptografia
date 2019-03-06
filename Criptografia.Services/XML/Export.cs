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
        public static void ExportPublicRSA(string publicKey, string fileName)
        {
            IDictionary<string, string> dict = new Dictionary<string, string>
            {
                { "clavepublica", publicKey }
            };

            SimpleXMLCreate.FlatXML(dict, fileName);
        }
    }
}
