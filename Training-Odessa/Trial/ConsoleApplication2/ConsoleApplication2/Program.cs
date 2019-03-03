using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        public delegate void delegateGet();
        public delegate void delegatePut();
        static void Main(string[] args)
        {
            Employee e1 = new Employee();
            delegateGet dg1 = new delegateGet(e1.getEmployeeDetails);
            dg1.Invoke();
            delegatePut dp1 = new delegatePut(e1.putEmployeeDetails);
            dp1.Invoke();


        }
    }
}
