using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XmlChanger
{
    public class XmlPreprocessor
    {
        private static XmlPreprocessor _instance;
        public static XmlPreprocessor Instance => _instance ?? (_instance = new XmlPreprocessor());

        private XmlPreprocessor()
        {
        }

        public string GetXml()
        {
            var rootPath = AppDomain.CurrentDomain.BaseDirectory;
            var FilesFolder = Directory.GetParent(Directory.GetParent(Directory.GetParent(rootPath).ToString()).ToString());
            var xmlString = File.ReadAllText(FilesFolder + @"\Files\abby.xml", Encoding.Default);
            var cleanString = CleanXmlFromEngine(xmlString);
            return cleanString;
        }

        public string CleanXmlFromEngine(string engineXmlString)
        {
            return CheckXmlIsValid(ref engineXmlString) ? engineXmlString : RemoveInvalidCharacters(engineXmlString);
        }

        private bool CheckXmlIsValid(ref string engineXmlString)
        {
            try
            {
                XmlDocument engineXmlDocument = new XmlDocument();
                engineXmlDocument.Load(engineXmlString);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private string RemoveInvalidCharacters(string engineXmlString)
        {
            int index = engineXmlString.IndexOf('<');
            var newString = engineXmlString.Substring(index, engineXmlString.Length - index);
            RemoveEscapeSequences(ref newString);
            return newString;
        }

        private void RemoveEscapeSequences(ref string newString)
        {
            newString = newString.Replace("\r", String.Empty);
            newString = newString.Replace("\t", String.Empty);
        }
    }
}
