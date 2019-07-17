using System;
using System.Collections.Generic;
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
        private XmlTransformer()
        {
            XmlHelperInstance = XmlHelper.Instance;
            XmlPreprocessorInstance = XmlPreprocessor.Instance;
            NodeMap = new Dictionary<string, EngineNodeHolder>();
        }


        private void BuildNodeMap()
        {
            NodeMap.Add("ContractType", new EngineNodeHolder(CallbackValue: "Lease"));
            NodeMap.Add("LegalEntity.Name", new EngineNodeHolder(EngineNode: "_Customer"));
            NodeMap.Add("Customer.Party.PartyName", new EngineNodeHolder(EngineNode: "_ShipContact", LinePosition: 2));
            NodeMap.Add("Vendor.Party.PartyName", new EngineNodeHolder(EngineNode: "_CompanyName1"));
            NodeMap.Add("InvoiceNumber", new EngineNodeHolder(EngineNode: "_DocumentRef"));
            NodeMap.Add("Alias", new EngineNodeHolder(EngineNode: "_CallRef"));
            NodeMap.Add("InvoiceDate", new EngineNodeHolder(EngineNode: "_Date"));
            NodeMap.Add("DueDate", new EngineNodeHolder(EngineNode: "_Date"));
            NodeMap.Add("Currency.Name", new EngineNodeHolder(CallbackValue: "ZAR"));
            NodeMap.Add("AllowCreateAssets", new EngineNodeHolder(CallbackValue: "true"));
            NodeMap.Add("InvoiceTotal", new EngineNodeHolder(EngineNode: "_Total", NodePosition: 10));
        }

        public dynamic TransformOcrXmlToEntityXml(string engineXmlString)
        {
            BuildNodeMap();
            return CreateDeserializedDataSet(engineXmlString);
        }

        private dynamic CreateDeserializedDataSet(string engineXmlString)
        {
            var cleanEngineXmlString = XmlPreprocessorInstance.CleanXmlFromEngine(engineXmlString);
            XmlHelperInstance.SetXmlString(cleanEngineXmlString);
            XElement deserializedDataSet;
            GenerateDataSet(out deserializedDataSet);
            return deserializedDataSet;
        }

        private void GenerateDataSet(out XElement deserializedDataSet)
        {
            deserializedDataSet =
                new XElement("PayableInvoices",
                    new XElement("PayableInvoice",
                        from keyvaluePair in NodeMap
                        select new XElement(keyvaluePair.Key,
                            XmlHelperInstance.FetchValueFromNode(NodeMap.GetValueOrDefault(keyvaluePair.Key))
                        )
                    )
                );
        }
    }
}
