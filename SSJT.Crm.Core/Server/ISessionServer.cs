using SSJT.Crm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Core.Server
{
    public interface ISessionServer
    {
        void RegSession(string userID, string password);
        void RemoveSession(string sessionID);
        SessionMode GetSessionMode(string sessionID);
        string GetCurrentSessionID();
        int Timeout { get; }
        HrEmploy CurrentUser { get; }
    }
}
