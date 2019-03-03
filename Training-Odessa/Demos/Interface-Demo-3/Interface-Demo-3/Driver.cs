using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Demo_3
{
    class Driver
    {
        public void Drive(ILandVehicles c)
        {

        }
    }
    class LocoPilot
    {
        public void Drive(IRailVehicles c)
        {

        }
    }
    class Pilot
    {
        public void Drive(IAir c)
        {

        }
    }
    class Sailor
    {
        public void Drive(IWaterVehicles c)
        {

        }
    }
}
