using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.DBUtility
{
    public class DbSession : IDbSession
    {
        public DbContext DbContext
        {
            get { return DbContextFactory.GetDnContext(); }
        }

        public List<T> ExcuteQuery<T>(string sql, params SqlParameter[] parameters)
        {
            return this.DbContext.Database.SqlQuery<T>(sql, parameters).ToList();
        }

        public int ExecuteSql(string sql, params SqlParameter[] parameters)
        {
            return this.DbContext.Database.ExecuteSqlCommand(sql, parameters);
        }

        public bool SaveChange()
        {
            if(DbContext.SaveChanges()>0)
                return true;
            return false;
        }
    }
}
