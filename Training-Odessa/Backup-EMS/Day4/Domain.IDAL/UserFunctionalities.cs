using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IDAL
{
    interface UserFunctionalities
    {
        void login();
        void Registeration();
        void ForgotPassword();
        void UpdatePassword();
        void UpdateSecurityQuestion();
    }   
}
