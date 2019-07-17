using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using XmlChanger.Model;

namespace XmlChanger
{
    internal class XmlHelper
    {
        private static XmlHelper _instance { get; set; }
        public static XmlHelper Instance => _instance ?? (_instance = new XmlHelper());
        private string xmlString { get; set; }
        private XmlHelper()
        {
        }

        public void SetXmlString(string xmlString)
        {
            this.xmlString = xmlString;
        }

        public string FetchValueFromNode(EngineNodeHolder node)
        {
            if (node.CallbackValue != null) return node.CallbackValue;
            using (StringReader s = new StringReader(xmlString))
            {
                XDocument xdoc;
                xdoc = XDocument.Load(s);
                var desc = xdoc.Descendants(node.EngineNode).ToHashSet();
                var nodevalue = desc.Select(x => x.Value).ElementAt(node.NodePosition ?? 0);
                ParseDateNode(node.EngineNode, ref nodevalue);
                return nodevalue;
            }
        }

        private void ParseDateNode(string node, ref string nodevalue)
        {
            if (node != "_Date") return;
            nodevalue = DateTime.ParseExact(nodevalue, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        [Obsolete]
        public void ConvertToXDocument(string xmlString)
        {
            XDocument xdoc;
            using (StringReader s = new StringReader(xmlString))
            {
                xdoc = XDocument.Load(s);
                foreach (XElement element in xdoc.Descendants())
                {
                    Console.WriteLine(element.Name + "--" + element.Value);
                }
                var desc = xdoc.Descendants("_Date").ToHashSet();
                XElement output;
                var d2 = desc.Select(x => x.Value).FirstOrDefault();
                var dt = DateTime.ParseExact(d2, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                Console.WriteLine(dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            }
            Console.ReadKey();
        }
    }
}