using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.IDAL
{
    public interface IManager
    {
        void ApprovalStatus(int LeaveID, LeaveStatus status);
        void ViewLeaveRequest(int ManagerID);


    }
}
