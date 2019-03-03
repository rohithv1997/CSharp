using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Employee e1 = new Employee();
            //e1.CalculateAttendance();
            //e1.DoWork();
            //Manager m1 = new Manager();
            //m1.CalculateAttendance();
            //m1.DoWork();
            //m1.DoManagerWork();

            // Employee e2 = new Manager();
            //Employee e3 = new Developer();
            //e2.DoWork();
            //e3.DoWork();

            // Manager m1 = new Employee();
            //Developer d1 =(Developer) new Employee();
            //d1.EmpID = 1;


            //Employee e2 = new Employee();
            //e2.EmpID = 1;
            //e2.FName = "Don";
            //e2.LName = "Jose";
            //e2.CTC = 15;
            //e2.MonthlySal = 1;

            //Developer d2;
            //d2 =(Developer) e2;
            //Console.WriteLine(d2.FName);

            //Manager m1 = new Manager();
            //Developer d1 = new Developer();
            //m1.DoWork();
            //d1.DoWork();

            //Employee e1 = new Manager();
            //e1.DoWork();

            Employee e=new BA();
            e.DoWork();
         
        }
    }
}
