using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{
   static class Logger
    {
        public static void CreateLog(Exception o)
        {
            if (o.GetType() == typeof(Exception)) throw new Exception(o.Message);
            return;

        }
        public static void CreateLog(Object o)
        {
            return;
        }
    }
}
