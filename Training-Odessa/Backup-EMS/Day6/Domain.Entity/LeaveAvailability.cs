using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class LeaveAvailablity
    {
        int LeaveTypeId2;
        public int propLeaveTypeId2
        {
            get { return LeaveTypeId2; }
            set { LeaveTypeId2 = value; }
        }
        int EmployeeId3;
        public int propEmployeeId3
        {
            get { return EmployeeId3; }
            set { EmployeeId3 = value; }
        }
        decimal Carry;
        public decimal propCarry
        {
            get { return Carry; }
            set { Carry = value; }
        }
        DateTime Year;
        public DateTime propYear
        {
            get { return Year; }
            set { Year = value; }
        }
        decimal AvailedLeave;
        public decimal propAvailedLeave
        {
            get { return AvailedLeave; }
            set { AvailedLeave = value; }
        }
        decimal AvailableLeave;
        public decimal propAvailableLeave
        {
            get { return AvailableLeave; }
            set { AvailableLeave = value; }
        }
    }
}
