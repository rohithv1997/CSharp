﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Demo_2
{
    class Bike : IDrive,IVehicleDetails
    {
        public string Brand
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Color
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Model
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int VehicleID
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Accelerate()
        {
            throw new NotImplementedException();
        }

        public void Breake()
        {
            throw new NotImplementedException();
        }

        public void ChangeGear()
        {
            throw new NotImplementedException();
        }

        public IVehicleDetails GetVehicleDetails()
        {
            return new Bike();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
