using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using SSJT.Crm.Core.Server;
using SSJT.Crm.Model;

namespace SSJT.Crm.Core
{
    public class SessionFactory:ILogicalThreadAffinative
    {
        /// <summary>
        /// 获取SessionServer的实例
        /// </summary>
        /// <returns></returns>
        public static ISessionServer GetSessionServer()
        {
            ISessionServer sessionServer = CallContext.LogicalGetData("SessionServer") as ISessionServer;
            if (sessionServer == null)
            {
                sessionServer = new SessionServer();
                CallContext.LogicalSetData("SessionServer", sessionServer);
            }
            return sessionServer;
        }
        public static ISessionMode GetSessionMode()
        {
            ISessionMode sessionMode = CallContext.LogicalGetData("SessionMode") as ISessionMode;
            if (sessionMode == null)
            {
                sessionMode = new SessionMode();
                CallContext.LogicalSetData("SessionMode", sessionMode);
            }
            return sessionMode;
        }
    }
}
