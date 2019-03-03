using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApplication6
{
    class Program
    {
       

        static void Main(string[] args)
        {


            Assembly ass = Assembly.LoadFrom(@"D:\Training\C#\EMS\EMS\bin\Debug\Domain.DAL.dll");
            Type[] t = ass.GetTypes();
            foreach (var item in t)
            {
                PropertyInfo[] pi = item.GetProperties();
                MethodInfo[] mi = item.GetMethods();
                MemberInfo[] mmi = item.GetMembers();

                Console.WriteLine("------------------------------------------------------");
                //Console.WriteLine();
                Console.WriteLine(item.Name);
                Console.WriteLine();

                foreach (var methodi in mi)
                {
                    Console.WriteLine(methodi.Name);
                }
                Console.WriteLine();

                foreach (var propi in pi)
                {
                    Console.WriteLine(propi.Name);
                }
                Console.WriteLine();

                foreach (var memi in mmi)
                {
                    Console.WriteLine(memi.Name);
                }
                Console.WriteLine();
            }
            Console.Read();
            if (DateTime.Now.Hour >= 9 
               &&DateTime.Now.Hour < 18)
                Console.WriteLine("loolol");
        }
    }
}
