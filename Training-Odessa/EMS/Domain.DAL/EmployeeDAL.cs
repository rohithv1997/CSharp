using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.IDAL;
using EMS;
using System.Globalization;

namespace Domain.DAL
{
    public delegate bool personalisedelegate(int empid);
    public delegate bool leavedelegate();

    public class leavevalidationexception : Exception
    {
        public leavevalidationexception(string m) : base(m)
        {
            Console.WriteLine(Message);
        }
    }

    public class EmployeeDAL : ILeave, IUser
    {
        personalisedelegate pd = new personalisedelegate(new dem().Display);

        public void ApplyLeave(LeaveApplication objleaveapplication)
        {

            if (objleaveapplication.propStartDate < objleaveapplication.propEndDate && objleaveapplication.propAppliedDate < DateTime.Now.AddDays(-30))
            {
                Console.WriteLine("Leave Successfully applied");
            }
            else
            {
                leavevalidationexception e = new leavevalidationexception("Start Date <= End Date || Leave must be applied before 30 days");
                throw e;
            }





            //throw new NotImplementedException();
        }

        public void CancelLeave(int LeaveApplicationID)
        {
            Console.WriteLine("Leave Cancelled Successfully.");
            //throw new NotImplementedException();
        }

        public List<int> GetManagers(int EmployeeID)
        {
            throw new NotImplementedException();
        }

        public void UpdateLeaveBalance(LeaveValidation objleaveapplication)
        {
            throw new NotImplementedException();
        }

        public LeaveValidation ValidateLeave(int EmployeeID, int LeaveTypeID)
        {
            throw new NotImplementedException();
        }

        public void ViewCurrentLeaveStatus(LeaveStatus ls)
        {
            Console.WriteLine("Successful Leave Applied status");
            //return ls;
            //throw new NotImplementedException();
        }

        public void ViewLeaveAvailability(int EmployeeID)
        {
            Console.WriteLine("Leave Available ");
            //throw new NotImplementedException();
        }

        public void ViewLeaveHistory(int EmployeeId, int LeaveTypeID)
        {
            Console.WriteLine("Leave History present successfully");
            //throw new NotImplementedException();
        }

        public DataTable ViewLeaveHistory(int EmployeeId, DateTime StartDate, DateTime EndDate)
        {
            throw new NotImplementedException();
        }

        public User ForgotPassword(string LoginName)
        {
            throw new NotImplementedException();
        }

        public bool Login(string LoginName, string Password, out int empid)
        {

            int i; bool stat = false;
            for (i = 0; i < DataSource.ul.Count; i++)
            {
                if (DataSource.ul[i].propLoginName == LoginName && DataSource.ul[i].propPassword == Password)
                {
                    stat = true;
                    //ConsEvent(DataSource.Empobj[i]);
                    break;
                }
            }
            if (stat)
            {
                empid = DataSource.ul[i].propId;
                pd.Invoke(empid);
                return stat;
            }
            else
            {
                Console.WriteLine("Enter Correct Credentials");
                empid = 0;
                return stat;
                //throw new NotImplementedException();
            }
        }

        public void RegisterUser(User objUser)
        {
            throw new NotImplementedException();
        }

        public void UpdatePassword(string LoginName, string NewPassword)
        {
            throw new NotImplementedException();
        }

        public void UpdateSecurityQuestion(User objUser)
        {
            throw new NotImplementedException();
        }

    }
    public class dem
    {

        public bool Display(int empid)
        {
            Console.ReadKey();
            
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("\n\n\n");
            int i; bool stat = false;
            for (i = 0; i < DataSource.edl.Count; i++)
            {
                if (DataSource.edl[i].propEmployeeId == empid)
                {
                    stat = true;

                    //ConsEvent(DataSource.Empobj[i]);
                    break;
                }
            }
            if (stat)
            {
                Console.WriteLine("Welcome {0} {1}", DataSource.edl[i].propFirstName.ToUpper(), DataSource.edl[i].propLastName.ToUpper());
                //Console.WriteLine("Current Time is {0}:{1}", DateTime.Now.Hour, DateTime.Now.Minute);
                Console.WriteLine("Current Time is {0}:{1} {2}", DateTime.Now.Hour, DateTime.Now.Minute, (DateTime.Now.Hour > 12 ? "PM" : "AM"));
                Console.WriteLine("We Wish You a very Warm Good Morning");
                //pd.Invoke(empid);
                //return stat;
            }
            else
            {
                Console.WriteLine("Enter Correct Credentials");
                empid = 0;

                //throw new NotImplementedException();
            }
            Console.ReadKey();
            //Console.WriteLine("Display");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            return stat;
        }

        //public bool seconddel()
        //{

        //}
    }
    //publisher
    public class alertpublisher
    {
        public event leavedelegate checklogintime;
        public bool trigger()
        {
            if( DateTime.Now.Hour >= 9  && DateTime.Now.Hour<18)
                // return true;
                checklogintime();
            else {
                Console.WriteLine("Leave can be applied only during Office Hours");
                return false;
            }
            return true;
        }
    }


    //delegate

    //method
    //public void mian()
    //{
    //    alertpublisher a1 = new alertpublisher();
    //    empsubscriber e1 = new empsubscriber();
    //    e1.subscribe(a1);
    //    a1.trigger();
    //}


    //subscriber
    public class empsubscriber
    {
        public void subscribe(alertpublisher a11)
        {
            leavedelegate l1 = new leavedelegate(findtime);
            a11.checklogintime += l1;
        }
        public bool findtime()
        {
            //Console.WriteLine("Leave Applied Successfully");
            return true;
            //Console.WriteLine("Find Time method");
        }
    }



}
