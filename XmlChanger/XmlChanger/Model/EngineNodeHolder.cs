using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlChanger.Model
{
    public class EngineNodeHolder
    {
        public EngineNodeOptions engineNodeOptions { get; set; }
        public string Value { get; set; }
        public string EngineNode { get; set; }
        public bool IsParentAttribute { get; set; }
        
        public EngineNodeHolder(string EngineNode, EngineNodeOptions engineNodeOptions = EngineNodeOptions.EngineNode, string Value = null
            ,bool IsParentAttribute=true)
        {
            this.EngineNode = EngineNode;
            this.Value = Value;
            this.engineNodeOptions = engineNodeOptions;
            this.IsParentAttribute = IsParentAttribute;
        }
    }
}
