using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.IDAL;

namespace Domain.DAL
{
    public class ManagerDAL : EmployeeDAL, IManager
    {
        public void ApprovalStatus(int LeaveID, LeaveStatus status)
        {
            Console.WriteLine("Approval Status viewed successfully");
            //throw new NotImplementedException();
        }

        public void ViewLeaveRequest(int ManagerID)
        {
            Console.WriteLine("Leave request viewed Successfully");
            //throw new NotImplementedException();
        }
    }
}
