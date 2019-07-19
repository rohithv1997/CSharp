using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            var masterString = XmlPreprocessor.Instance.GetXml();
            //Console.WriteLine(masterString);
            //Console.ReadKey();
            var finalxml = XmlTransformer.Instance.TransformOcrXmlToEntityXml(masterString);
            //Debug.WriteLine(finalxml.ToString());
            Console.WriteLine(finalxml);
            Console.ReadKey();
        }
    }
}
