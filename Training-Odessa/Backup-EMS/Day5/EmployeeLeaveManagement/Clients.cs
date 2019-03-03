using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLeaveManagement
{
    public class Clients : IDisposable
    {
        readonly string countrycode;
        readonly string zipcode;
        string cname { get; set; }
        public Clients()
        {
            countrycode = "US";
            Console.WriteLine("Enter Client Name: ");
            cname = Console.ReadLine();
            Console.WriteLine("Enter ZipCode: ");
            string hj = Console.ReadLine();
            if(!String.IsNullOrEmpty(hj) && hj.Length>=6) zipcode=hj ;
        }
        public Clients(string x,string y)
        {
            countrycode = x;
            zipcode = y;
        }
        public string retcname()
        {
            return cname;
        }
        public void retreiveclient()
        {
            Console.WriteLine("Client Details");
            Console.WriteLine("Country Code: {0}",countrycode);
            Console.WriteLine("Client Name: {0}",cname);
            Console.WriteLine("Zip Code: {0}",zipcode);
        }
        

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            cname = null;
            new Clients(null, null);
           // c = null;
            //throw new NotImplementedException();
        }
        
    }
}
