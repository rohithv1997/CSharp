using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Demo_2
{
    interface IVehicleDetails
    {
         int VehicleID { get; set; }
         string Color { get; set; }
        string Brand { get; set; }
        string Model { get; set; }
        IVehicleDetails GetVehicleDetails();

    }
}
