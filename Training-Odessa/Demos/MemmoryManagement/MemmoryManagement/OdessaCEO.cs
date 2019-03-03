using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemmoryManagement
{
    class OdessaCEO
    {
        string Name;
        OdessaCEO()
        {
            Name = "Jay";
        }
        public static OdessaCEO CreateCEO()
        {
            OdessaCEO CEOJay = new OdessaCEO();
            return CEOJay;
        }
        public void MeetingWithCEO()
        {
            Console.WriteLine("Meeting CEO-Jay");
        }
    }
}
