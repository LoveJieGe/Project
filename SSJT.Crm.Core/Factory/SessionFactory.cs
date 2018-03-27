using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SSJT.Crm.Core.Server;

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
    }
}
