using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Demo_3
{
    interface IVehicles
    {
        void Start();
        void Stop();
        void Accelerate();
        void Break();
        void ChangeGear();
    }
    interface ILandVehicles:IVehicles
    {
        void Indicator();
    }
    interface IRailVehicles:IVehicles
    {
        void ChangeTrack();
    }
    interface IAir:IVehicles
    {
        void AutoPiolot();
    }
    interface IWaterVehicles:IVehicles
    {
        void DropAnchor();
    }
}
