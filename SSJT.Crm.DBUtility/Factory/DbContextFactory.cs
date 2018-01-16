using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using SSJT.Crm.Model;

namespace SSJT.Crm.DBUtility
{
    public class DbContextFactory
    {
        public static DbContext GetDnContext()
        {
            DbContext db = CallContext.GetData("DbContext") as DbContext;
            if(db==null)
            {
                db = new CrmEntities();
                CallContext.SetData("DbContext", db);
            }
            return db;
        }
    }

    public class DbSessionFactory
    {
        public static IDbSession GetDbSession()
        {
            IDbSession dbSession = CallContext.GetData("DbSession") as IDbSession;
            if(dbSession==null)
            {
                dbSession = new DbSession();
                CallContext.SetData("DbSession", dbSession);
            }
            return dbSession;
        }

    }
}
