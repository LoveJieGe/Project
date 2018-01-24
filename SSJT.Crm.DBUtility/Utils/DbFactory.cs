using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.DBUtility
{
    public class DbFactory
    {
        public static IDbSession DbSession { get; set; }
        public static string Message { get; set; }
        private string _message;
        private IDbSession _dbSession;
        public void Init()
        {
            DbFactory.Message = this._message;
            DbFactory.DbSession = this._dbSession;
        }
    }
}
