using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.IDAL;
using EMS;

namespace Domain.DAL
{

    public class EmployeeDAL : ILeave, IUser
    {
        public void ApplyLeave(LeaveApplication objleaveapplication)
        {
            Console.WriteLine("Leave Successfully applied");
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
}
