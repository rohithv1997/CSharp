using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
namespace Domain.IDAL
{
    public interface ILeave
    {
        void ApplyLeave(LeaveApplication objleaveapplication);
        void UpdateLeaveBalance(LeaveValidation objleaveapplication);
        void CancelLeave(int LeaveApplicationID);
        LeaveValidation ValidateLeave(int EmployeeID, int LeaveTypeID);
        void ViewLeaveHistory(int EmployeeId, int LeaveTypeID);
        void ViewCurrentLeaveStatus(LeaveStatus ls);
        void ViewLeaveAvailability(int EmployeeID);
        List<int> GetManagers(int EmployeeID);

    }
}
