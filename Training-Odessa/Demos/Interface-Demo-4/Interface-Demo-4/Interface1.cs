using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Demo_4
{
    interface IArea
    {
       void GetDetails();
        void Area();
    }
    interface IVolume
    {
        void GetDetails();
        void Volume();
    }
    class Circle : IArea
    {
        public void Area()
        {
            throw new NotImplementedException();
        }

        public void GetDetails()
        {
            throw new NotImplementedException();
        }
    }
    class Sphere : IArea, IVolume
    {
        public void Area()
        {
            throw new NotImplementedException();
        }

         void IArea.GetDetails()
        {
            throw new NotImplementedException();
        }
        void IVolume.GetDetails()
        {
            throw new NotImplementedException();
        }

        public void Volume()
        {
            throw new NotImplementedException();
        }
    }
}
