using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW
{
    class Employee
    {
        int Eid;
        public int EmpID
        {
            get
            { return Eid; }

            set
            {
                if(value>100)
                {
                    Eid = value;
                }
            }

        }

        public int CTC { get; set; }
        //public int EmpID;
        int Age=18;
        public int propAge
        {
            set
            {
                if (value>18 && value<60)
                {
                    Age = value;
                }
              
            }
            get
            {
                return Age;
            }
        }
       public string Name;
        string UserName="Dinoop.u";
        public string propUserName
        {
            get
            {
                return UserName;
            }
        }
         string Password;
        public string propPassword  {
            set
            {
                if(value.Length>6)
                {
                    Password = value;
                }
            }

        }

    }
}
