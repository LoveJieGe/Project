using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.DBUtility
{
    public interface IDbSession
    {
        /// <summary>
        /// 获取操作的上下文
        /// </summary>
        DbContext DbContext { get; }
        /// <summary>
        /// 保存更改
        /// </summary>
        /// <returns></returns>
        bool SaveChange();
        /// <summary>
        /// 执行sql语句，返回执行后成功的个数
        /// /// 如：ExecuteSql("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor))
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteSql(string sql, params SqlParameter[] parameters);
        /// <summary>
        /// 执行sql语句返回执行后得到的结果列表
        /// ExcuteQuery&lt;Post&gt;("SELECT * FROM dbo.Posts WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor))
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        List<T> ExcuteQuery<T>(string sql, params SqlParameter[] parameters);
    }
}
