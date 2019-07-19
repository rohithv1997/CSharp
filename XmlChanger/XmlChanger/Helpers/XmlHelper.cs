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

        public string FetchValueFromNodeForParent(EngineNodeHolder node)
        {
            switch (node.engineNodeOptions)
            {
                case EngineNodeOptions.CallbackValue: return FetchValueForCallbackValue(node.Value);
                default: return FetchValueForOtherOptions(node);
            }
        }

        public string FetchValueFromNodeForChild(EngineNodeHolder node, XElement childNode)
        {
            switch (node.engineNodeOptions)
            {
                case EngineNodeOptions.CallbackValue: return FetchValueForCallbackValue(node.Value);
                default: return FetchValueForOtherOptions(node, childNode.ConvertToString());
            }
        }

        private string FetchValueForOtherOptions(EngineNodeHolder node, string nodeString = null)
        {
            using (StringReader s = new StringReader(nodeString ?? xmlString))
            {
                XDocument xdoc = XDocument.Load(s);
                var desc = xdoc.Descendants(node.EngineNode).ToHashSet();
                var nodes = desc.Select(x => x.Value);
                switch (node.engineNodeOptions)
                {
                    case EngineNodeOptions.Date: return FetchValueForDate(node.EngineNode, ref nodes);
                    case EngineNodeOptions.EngineNode: return FetchValueForEngineNode(ref nodes);
                    case EngineNodeOptions.LinePosition: return FetchValueForLinePosition(node.Value, ref nodes);
                    case EngineNodeOptions.NodeCount: return FetchValueForNodeCount(ref nodes);
                    case EngineNodeOptions.NodePosition: return FetchValueForNodePosition(node.Value, ref nodes);
                    default: return String.Empty;
                }
            }
        }

        private string FetchValueForCallbackValue(string nodevalue)
        {
            return nodevalue;
        }

        private string FetchValueForDate(string engineNode, ref IEnumerable<string> nodes)
        {
            return DateTime.ParseExact(nodes.FirstOrDefault(), "yyyy-MM-dd", CultureInfo.InvariantCulture)
                        .ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        private string FetchValueForEngineNode(ref IEnumerable<string> nodes)
        {
            return nodes.FirstOrDefault();
        }

        private string FetchValueForLinePosition(string index, ref IEnumerable<string> nodes)
        {
            return nodes.FirstOrDefault().Split('\n').ElementAt(Convert.ToInt32(index));
        }

        private string FetchValueForNodeCount(ref IEnumerable<string> nodes)
        {
            return nodes.Count().ToString();
        }

        private string FetchValueForNodePosition(string nodePosition, ref IEnumerable<string> nodes)
        {
            return nodes.ElementAt(Convert.ToInt32(nodePosition));
        }
    }
}