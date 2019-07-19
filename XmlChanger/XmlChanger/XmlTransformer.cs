using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XmlChanger.Model;

namespace XmlChanger
{
    class XmlTransformer
    {
        private static XmlTransformer _instance;
        public static XmlTransformer Instance => _instance ?? (_instance = new XmlTransformer());
        private XmlHelper XmlHelperInstance { get; set; }
        private XmlPreprocessor XmlPreprocessorInstance { get; set; }
        private Dictionary<string, EngineNodeHolder> NodeMap { get; set; }
        private string cleanEngineXmlString { get; set; }
        private Dictionary<string, EngineNodeHolder> PointerNodeMap { get; set; }

        private XmlTransformer()
        {
            XmlHelperInstance = XmlHelper.Instance;
            XmlPreprocessorInstance = XmlPreprocessor.Instance;
            NodeMap = new Dictionary<string, EngineNodeHolder>();
            PointerNodeMap = new Dictionary<string, EngineNodeHolder>();
        }

        public string TransformOcrXmlToEntityXml(string engineXmlString)
        {
            BuildNodeMap();
            return CreateDeserializedDataSet(engineXmlString);
        }

        private void BuildNodeMap()
        {
            BuildChildEntityNodePointers();
            BuildParentEntityNodes();
            BuildChildEntityNodes();
        }

        private void BuildChildEntityNodes()
        {
            NodeMap.Add("PayableInvoiceAssets.Asset.Alias",
                new EngineNodeHolder(EngineNode: "_ItemCode", EngineNodeOptions.EngineNode, IsParentAttribute: false));
            NodeMap.Add("Asset.Alias",
                new EngineNodeHolder(EngineNode: "_ItemCode", EngineNodeOptions.EngineNode, IsParentAttribute: false));
            NodeMap.Add("Asset.Description",
                new EngineNodeHolder(EngineNode: "_ItemDescription", EngineNodeOptions.EngineNode, IsParentAttribute: false));
            NodeMap.Add("Asset.Quantity",
                new EngineNodeHolder(EngineNode: "_Quantity", EngineNodeOptions.EngineNode, IsParentAttribute: false));
        }

        private void BuildChildEntityNodePointers()
        {
            PointerNodeMap.Add("PayableInvoiceAsset",
                new EngineNodeHolder(EngineNode: "_LineItems", EngineNodeOptions.ChildEntityPointer, IsParentAttribute: false));
        }

        private void BuildParentEntityNodes()
        {
            NodeMap.Add("ContractType",
                new EngineNodeHolder(EngineNode: null, EngineNodeOptions.CallbackValue, "Lease"));
            NodeMap.Add("LegalEntity.Name",
                new EngineNodeHolder(EngineNode: "_Customer"));
            NodeMap.Add("Customer.Party.PartyName",
                new EngineNodeHolder(EngineNode: "_ShipContact", EngineNodeOptions.LinePosition, "2"));
            NodeMap.Add("Vendor.Party.PartyName",
                new EngineNodeHolder(EngineNode: "_CompanyName1"));
            NodeMap.Add("InvoiceNumber",
                new EngineNodeHolder(EngineNode: "_DocumentRef"));
            NodeMap.Add("Alias",
                new EngineNodeHolder(EngineNode: "_CallRef"));
            NodeMap.Add("InvoiceDate",
                new EngineNodeHolder(EngineNode: "_Date", EngineNodeOptions.Date));
            NodeMap.Add("DueDate",
                new EngineNodeHolder(EngineNode: "_Date", EngineNodeOptions.Date));
            NodeMap.Add("Currency.Name",
                new EngineNodeHolder(EngineNode: null, EngineNodeOptions.CallbackValue, "ZAR"));
            NodeMap.Add("ContractCurrency.Name",
                new EngineNodeHolder(EngineNode: null, EngineNodeOptions.CallbackValue, "ZAR"));
            NodeMap.Add("InvoiceTotal",
                new EngineNodeHolder(EngineNode: "_Total", EngineNodeOptions.NodePosition, "10"));
            NodeMap.Add("NumberOfAssets",
                new EngineNodeHolder(EngineNode: "_LineItems", EngineNodeOptions.NodeCount));
            NodeMap.Add("AllowCreateAssets",
                new EngineNodeHolder(EngineNode: null, EngineNodeOptions.CallbackValue, "true"));
        }

        private string CreateDeserializedDataSet(string engineXmlString)
        {
            string endTag = "</PayableInvoice></PayableInvoices>";
            cleanEngineXmlString = XmlPreprocessorInstance.CleanXmlFromEngine(engineXmlString);
            XmlHelperInstance.SetXmlString(cleanEngineXmlString);
            XElement parentDataSet;
            string childDataSet;
            GenerateDataSet(out parentDataSet, out childDataSet);
            Console.WriteLine(XElement.Parse(parentDataSet.ConvertToString().Replace(endTag, childDataSet + endTag)));
            Console.ReadKey();
            return parentDataSet.ConvertToString().Replace(endTag, childDataSet + endTag);
        }

        private void GenerateDataSet(out XElement parentDataSet, out string childDataSet)
        {
            parentDataSet =
                new XElement("PayableInvoices",
                    new XElement("PayableInvoice",
                        NodeMap.Where(keyvaluePair => keyvaluePair.Value.IsParentAttribute)
                            .Select(keyvaluePair => new XElement(keyvaluePair.Key,
                                XmlHelperInstance.FetchValueFromNodeForParent(NodeMap.GetValueOrDefault(keyvaluePair.Key)))
                            )
                    )
                );
            childDataSet = "<PayableInvoiceAssets>" + GenerateChildDataSet() + "</PayableInvoiceAssets>";
        }

        private string GenerateChildDataSet()
        {
            var NodesToBeIterated = PointerNodeMap
                .Where(keyvaluePair => keyvaluePair.Value.engineNodeOptions.Equals(EngineNodeOptions.ChildEntityPointer))
                .Select(kvpair => kvpair.Value.EngineNode).ToArray();
            return SelectXmlNodes(NodesToBeIterated);
        }

        private string SelectXmlNodes(string[] NodesToBeIterated)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var nodetobeiterated in NodesToBeIterated)
            {
                using (StringReader s = new StringReader(cleanEngineXmlString))
                {
                    XDocument xdoc = XDocument.Load(s);
                    var childnodes = xdoc.Descendants(nodetobeiterated).ToArray();
                    foreach (var childnode in childnodes)
                    {
                        var child =
                            new XElement("PayableInvoiceAsset",
                                NodeMap.Where(keyvaluePair => !keyvaluePair.Value.IsParentAttribute
                                                              && keyvaluePair.Value.engineNodeOptions != EngineNodeOptions.ChildEntityPointer)
                                    .Select(keyvaluePair => new XElement(keyvaluePair.Key,
                                        XmlHelperInstance.FetchValueFromNodeForChild(NodeMap.GetValueOrDefault(keyvaluePair.Key), childnode))
                                    )
                            );
                        sb.Append(child.ConvertToString());
                    }
                }
            }
            return sb.ToString();
        }
    }
}
