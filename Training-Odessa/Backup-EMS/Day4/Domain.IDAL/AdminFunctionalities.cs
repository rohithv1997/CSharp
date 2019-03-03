using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IDAL
{
    interface AdminFunctionalities
    {
        void addEmployee();
        void updateEmployee();
        void addLeaveType();
        void updateLeaveType();
        void addPortfolios();
        void updateHolidayCalendar();
        void adjustLeaveBalance();
    }
}
