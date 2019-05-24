namespace Criptografia.Services.XML
{
    public class Import
    {
        /// <summary>
        /// Importa el dato que contiene un nodo de un xml
        /// </summary>
        /// <param name="path"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public static object ImportDataFromNode(string path, string nodeName) => 
                             XMLParser.SimpleXMLParser.GetDataFromSimpleNode(path, nodeName);
    }
}
