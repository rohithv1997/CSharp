﻿using System;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace ReleaseCompanion
{
    public class Impersonator : IDisposable
    {
        private WindowsImpersonationContext _impersonatedUser = null;
        private IntPtr _userHandle;
        public Impersonator(string user, string userDomain, string password)
        {
            _userHandle = new IntPtr(0);
            bool returnValue = LogonUser(user, userDomain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref _userHandle);
            if (!returnValue)
                throw new ApplicationException("Login Failed!!!");
            WindowsIdentity newId = new WindowsIdentity(_userHandle);
            _impersonatedUser = newId.Impersonate();
        }
        #region IDisposable Members
        public void Dispose()
        {
            if (_impersonatedUser != null)
            {
                _impersonatedUser.Undo();
                CloseHandle(_userHandle);
            }
        }
        #endregion
        #region Interop imports/constants
        public const int LOGON32_LOGON_INTERACTIVE = 2;
        public const int LOGON32_LOGON_SERVICE = 3;
        public const int LOGON32_PROVIDER_DEFAULT = 0;
        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern bool LogonUser(String lpszUserName, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);
        #endregion
    }
}
