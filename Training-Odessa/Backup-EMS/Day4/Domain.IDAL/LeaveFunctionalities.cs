using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IDAL
{
    interface LeaveFunctionalities
    {
        void validateLeaves();
        void updateLeaveBalance();
        void cancelLeave();
        void viewLeaveHistory();
        void viewCurrentStatus();
        void viewLeaveAvailability();
        void getManagerDetails();
    }
}
