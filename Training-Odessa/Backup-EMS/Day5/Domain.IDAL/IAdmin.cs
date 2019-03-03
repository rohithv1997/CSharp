using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.IDAL
{
    public interface IAdmin
    {
        void AddNewEmployee(EmployeeDetails objEmp);
        void UpdateEmployee(EmployeeDetails objEmp);
        void AddNewLeaveType(LeaveType objLeaveType);
        void UpdateLeaveType(LeaveType objLeaveType);
        void AddPortfolio(Portfolio objPortfolio);
        void UpdateHoliday(Holiday objHolida);
        void AdjustLeave(LeaveAvailablity objLeaveAvailability);
    }
}
