using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeLeaveManagement
{

    public class MailGenerator
    {
        readonly public string mailid2;
        public MailGenerator(string f, string l, Employee eo)
        {
            mailid2 = f + "." + l[0] + "@odessainc.com";
            eo.mailid = mailid2;
        }
    }
    public class Employee
    {
        ConsoleColor bg;
        ConsoleColor fg = ConsoleColor.White;
        public bool status { get; set; }
        readonly string EmployeeID;
        public string propEmployeeID
        {

            get
            {

                return EmployeeID;
            }

        }
        string FirstName;
        public string propFirstName
        {
            set
            {
                if (value.Length <= 30) FirstName = value;
                else {
                    // FirstName = null;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter Valid FirstName");
                    Console.BackgroundColor = fg;
                }
            }
            get
            {
                return FirstName;
            }
        }
        public string LastName;
        public string propLastName
        {
            set
            {
                if (value.Length <= 20) LastName = value;
                else {
                    //LastName = null;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter Valid LastName");
                    Console.BackgroundColor = fg;
                }
            }
            get
            {
                return LastName;
            }
        }

        public string mailid { get; set; }

        string password;
        public string proppassword
        {
            set
            {
                password = value;
            }

            get
            {
                return password;
            }
        }

        string AddressLine1;
        public string propAddressLine1
        {
            set
            {
                if (value.Length >= 20) AddressLine1 = value;
                else {
                    //AddressLine1 = null;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter Valid AddressLine1");
                    Console.BackgroundColor = fg;

                }
            }
            get
            {
                return AddressLine1;
            }
        }

        string AddressLine2;
        public string propAddressLine2
        {
            set
            {
                AddressLine2 = value;


            }
            get
            {
                return AddressLine2;
            }
        }
        DateTime dob;
        public DateTime propdob
        {
            set
            {
                if (DateTime.Now.Year - value.Year >= 18) dob = value;
                else {
                    //dob = DateTime.MinValue;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter Valid DOB where Age>18");
                    Console.BackgroundColor = fg;
                }
            }
            get
            {
                return dob;
            }
        }
        int Age;
        public int propAge
        {
            set
            {
                if (value >= 18) Age = value;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter Valid DOB where Age>18");
                    Console.BackgroundColor = fg;
                }
            }
            get
            {
                return Age;
            }
        }

        double ctc;
        public double propctc
        {
            set
            {
                if (value > 8333.33) ctc = value;
                else {
                    //ctc = 0.00;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter Valid CTC");
                    Console.BackgroundColor = fg;
                }

            }
            get { return ctc; }
        }

        string MobileNumber;
        public string propMobileNumber
        {
            set
            {
                Regex r2 = new Regex(@"[+][9][1][ ][6-9]\d{9}");
                if (r2.IsMatch(value)) MobileNumber = value;
                else {
                    //MobileNumber = null;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter Valid Mobile Number");
                    Console.BackgroundColor = fg;
                }
            }
            get
            {
                return MobileNumber;
            }
        }
        DateTime doj;
        public DateTime propdoj
        {
            set { doj = value; }
            get { return doj; }
        }
        List<String> prefloc = new List<string>();
        public List<String> propprefloc
        {
            get
            {
                return prefloc;
            }
            set
            {
                if (value != null) prefloc.AddRange(value);
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter Valid Preferred Location");
                    Console.BackgroundColor = fg;

                }

            }
        }
        public Employee()
        {
            EmployeeID = Employee.genEID();
        }
        public bool checkdate(ref DateTime d)
        {
            if (((d.Day >= 1 && d.Day <= 30) && (d.Month == 4 || d.Month == 6 || d.Month == 7 || d.Month == 11))
           || ((d.Day >= 1 && d.Day <= 31) && (d.Month != 4 || d.Month != 6 || d.Month != 7 || d.Month != 11) && d.Month >= 1 && d.Month <= 12))
                return true;
            else {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Day and Month mismatch!!");
                Console.WriteLine("Enter Valid Age");
                Console.BackgroundColor = fg;
                d = DateTime.MinValue;
                return false;
            }
        }



        public void AcceptEmployeeDetails()
        {
            DateTime tempd = DateTime.MinValue;
            string s = null;
            //while (true)
            //{
            //    Console.WriteLine(" Enter Employee ID");
            //    propEmployeeID = Console.ReadLine();
            //    if (propEmployeeID != null) break;
            //}


            while (true)
            {
                Console.WriteLine(" Enter Employee First Name");
                propFirstName = Console.ReadLine();
                if (propFirstName != null) break;
            }

            while (true)
            {
                Console.WriteLine(" Enter Employee Last Name");
                propLastName = Console.ReadLine();
                if (propLastName != null) break;
            }

            genEmailID();
            genPassword();

            while (true)
            {
                Console.WriteLine(" Enter Address Line 1");
                propAddressLine1 = Console.ReadLine();
                if (propAddressLine1 != null) break;
            }


            Console.WriteLine(" Enter Address Line 2");
            propAddressLine2 = Console.ReadLine();

            while (true)
            {
                Console.WriteLine(" Enter Date Of Birth <mm/dd/yyyy>");
                // s=Console.ReadLine();
                if (DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempd))
                {
                    if (checkdate(ref tempd) == true) propdob = tempd;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter Valid DOB");
                        Console.WriteLine("Wrong Date Format!");
                        Console.BackgroundColor = fg;

                    }
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter Valid DOB");
                    Console.WriteLine("Wrong Date Format!");
                    Console.BackgroundColor = fg;
                }
                propAge = DateTime.Now.Year - dob.Year;
                if (propAge > 0) break;
                if (propdob != null) break;
            }


            while (true)
            {
                Console.WriteLine(" Enter Salary");
                propctc = Convert.ToInt32(Console.ReadLine());
                if (propctc > 0.00) break;
            }

            while (true)
            {
                Console.WriteLine(" Enter Mobile");
                propMobileNumber = Console.ReadLine();
                if (propMobileNumber != null) break;
            }

            while (true)
            {
                Console.WriteLine(" Enter Date Of Joining <mm/dd/yyyy>");
                //doj = Convert.ToDateTime(Console.ReadLine());
                if (DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempd))
                {
                    if (checkdate(ref tempd) == true) propdoj = tempd;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter Valid DOB");
                        Console.WriteLine("Wrong Date Format!");
                        Console.BackgroundColor = fg;

                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter Valid DOB");
                    Console.WriteLine("Wrong Date Format!");
                    Console.BackgroundColor = fg;

                }
                if (propdoj != null) break;
            }
            Console.WriteLine(" Enter Preferred Locations: ");
            while (true)
            {
                string loc;
                while (!string.IsNullOrEmpty(loc = Console.ReadLine())) propprefloc.Add(loc);
                if (propprefloc != null) break;
            }
            //Console.Clear();
        }

        void genPassword()
        {
            string up = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lo = "abcedefghijklmnopqrstuvxyz";
            string ch = "!@#$%^&)_+=-<>,./[]{}";
            string inte = "0123456789";
            Random r2 = new Random();
            string p = null;
            int y;
            for (int i = 0; i < 3; i++)
            {
                y = r2.Next(0, 26);
                p += up[y];
                y = r2.Next(0, 26);
                p += lo[y];
                y = r2.Next(0, 21);
                p += ch[y];
                y = r2.Next(0, 10);
                p += inte[y];
            }
            proppassword = p;
        }

        public void DisplayEmployeeDetails()
        {
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("{0}:\t{1} {2}", EmployeeID, FirstName, LastName);
            Console.WriteLine("Mail ID: {0}", mailid);
            Console.WriteLine("Password: {0}", proppassword);
            Console.WriteLine("{0} Years", Age);
            Console.WriteLine("{0},{1}", AddressLine1, AddressLine2);
            Console.WriteLine("Salary INR {0} LPA", ctc * 12.0);
            Console.WriteLine(MobileNumber);
            Console.WriteLine("Joined On:" + doj.ToString("d", DateTimeFormatInfo.InvariantInfo) + "," + doj.ToString("dddd"));
            //Console.WriteLine("Joined On:{0:d},{1}",doj);
            Console.WriteLine("Preferred Locations: ");
            foreach (var item in propprefloc)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
        
        static string genEID()
        {
            Random r = new Random();
            int v = r.Next(1000);
            string eid = 'E' + v.ToString("000");
            return eid;
        }
        public void genEmailID()
        {
            MailGenerator m2 = new MailGenerator(propFirstName, propLastName, this);
            genPassword();
        }


    }
    public static class ConsoleChange
    {
       static int i = 0, ch;
        static ConsoleColor bg;
        static ConsoleColor fg = ConsoleColor.White;
        static public void cc()
        {
           
            Console.WriteLine("1.Change Background Color\n2.Change Foreground Color\nEnter Choice: ");
            ch = Convert.ToInt32(Console.ReadLine());
            if (ch == 1)
            {
                i = 0;
                Console.WriteLine("Pick any color.");
                foreach (var item in Enum.GetValues(typeof(ConsoleColor)))
                {
                    Console.WriteLine(i + "." + item);
                    i++;
                }
                bg = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Console.ReadLine().ToString());
                Console.BackgroundColor = bg;
            }
            else if (ch == 2)
            {
                i = 0;
                Console.WriteLine("Pick any color.");
                foreach (var item in Enum.GetValues(typeof(ConsoleColor)))
                {
                    Console.WriteLine(i + "." + item);
                    i++;
                }
                fg = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Console.ReadLine().ToString());
                Console.ForegroundColor = fg;
            }
            Console.Clear();
        }
    }
}





