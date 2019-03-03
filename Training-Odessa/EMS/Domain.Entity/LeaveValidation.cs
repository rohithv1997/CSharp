using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class LeaveValidation
    {
        int EmployeeId4;
        public int propEmployeeId4
        {
            get { return EmployeeId4; }
            set { EmployeeId4 = value; }
        }
        int LeaveTypeId4;
        public int propLeaveTypeId4
        {
            get { return LeaveTypeId4; }
            set { LeaveTypeId4 = value; }
        }
        decimal ContinuousDays2;
        public decimal propContinuousDays2
        {
            get { return ContinuousDays2; }
            set { ContinuousDays2 = value; }
        }
        decimal DaysInAdvance2;
        public decimal propDaysInAdvance2
        {
            get { return DaysInAdvance2; }
            set { DaysInAdvance2 = value; }
        }
        decimal AvailedLeave2;
        public decimal propAvailedLeave2
        {
            get { return AvailedLeave2; }
            set { AvailedLeave2 = value; }
        }
        decimal AvailableLeave2;
        public decimal propAvailableLeave2
        {
            get { return AvailableLeave2; }
            set { AvailableLeave2 = value; }
        }
    }
}

