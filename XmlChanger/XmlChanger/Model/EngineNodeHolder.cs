using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlChanger.Model
{
    public class EngineNodeHolder
    {
        public int? NodePosition { get; set; }
        public int? LinePosition { get; set; }
        public string EngineNode { get; set; }
        public string CallbackValue { get; set; }
        public EngineNodeHolder(string EngineNode = null, int? NodePosition = null, int? LinePosition = null, string CallbackValue = null)
        {
            this.EngineNode = EngineNode; ;
            this.NodePosition = NodePosition;
            this.LinePosition = LinePosition;
            this.CallbackValue = CallbackValue;
        }
    }
}
