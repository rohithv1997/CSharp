using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Demo_2
{
    interface IDrive
    { 
       void Start();
        void Stop();
        void Accelerate();
        void Breake();
        void ChangeGear();
    }
}
