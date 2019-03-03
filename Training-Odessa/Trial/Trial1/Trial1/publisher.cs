using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial1
{
    class publisher
    {
        public event agentdelegate eventpublish;
        public void trigger(bool f)
        {
            if (f == true) eventpublish();
        }
    }
}
