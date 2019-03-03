using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Demo_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Car bmw = new Car();
            Driver don = new Driver();
            Bike duke = new Bike();
            don.Drive(bmw);


            Car MyCar = new Car();
            Bike c =(Truck)MyCar.GetVehicleDetails();
        }
    }
  
}
