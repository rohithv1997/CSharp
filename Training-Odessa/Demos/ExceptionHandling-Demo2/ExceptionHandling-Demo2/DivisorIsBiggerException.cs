using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling_Demo2
{
    class DivisorIsBiggerException:Exception
    {
        public DivisorIsBiggerException(string msg):base(msg)
        {
          
        }
    }
}
