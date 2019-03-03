using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class LeaveType
    {
        int LeaveTypeId3;
        public int propLeaveTypeId3
        {
            get { return LeaveTypeId3; }
            set { LeaveTypeId3 = value; }
        }
        string Name3;
        public string propName3
        {
            get { return Name3; }
            set { Name3 = value; }
        }
        decimal MaxNoOfDays;
        public decimal propMaxNoOfDays
        {
            get { return MaxNoOfDays; }
            set { MaxNoOfDays = value; }
        }
        decimal ContinuousDays;
        public decimal propContinuousDays
        {
            get { return ContinuousDays; }
            set { ContinuousDays = value; }
        }
        decimal DaysInAdvance;
        public decimal propDaysInAdvance
        {
            get { return DaysInAdvance; }
            set { DaysInAdvance = value; }
        }
    }
}
