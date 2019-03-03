using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple = true)]
    class bugreport:System.Attribute
    {
        public string name
        {
            get; set;
        }
        public string parameter { get; set; }
       public bugreport(string n,string p)
        {
            name = n;
            parameter = p;
        }
    }
}
