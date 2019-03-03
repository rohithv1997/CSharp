using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Demo_2
{
    class Driver
    {
        public void Drive(IDrive c)
        {
            c.Accelerate();
            c.Start();
            c.ChangeGear();
            c.Breake();
        }
    }
}
