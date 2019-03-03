using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial1
{
    class subscriber
    {
        public void subscribe(publisher p)
        {
            agentdelegate a1 = new agentdelegate(read);
            p.eventpublish += a1;
        }
        public void read()
        {
            Console.WriteLine("Line read here");
        }
    }
}
