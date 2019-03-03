 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Demo_1
{
   abstract class GeometricalShapes
    {
       public abstract void Area();
       public abstract void Volume();
    }
    interface IArea
    {
       
        double Length { get; set; }
        void Area();
    }
    interface IVolume
    {
        void Volume();
    }
    class Sphere : IArea, IVolume
    {
        public double Length
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

        public void Area()
        {
            Console.WriteLine("Hello");
        }

        public void Volume()
        {
            throw new NotImplementedException();
        }
    }
    class Circle : IArea
    {
        
        public double Length
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

        public void Area()
        {
            Console.WriteLine("HI");
        }
       
    }
}
