using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Core
{
    public sealed class SqlHelper
    {
        /// <summary>
        /// 判断表中是否存在满足条件的数据
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="wherelambda">lambda表达式,如果为null则表示判断表中是否有数据</param>
        /// <returns></returns>
        public static bool Exists<TSource>(Expression<Func<TSource, bool>> wherelambda )where TSource:class,new()
        {
            int count = 0;
            if (wherelambda == null)
                 count = DBUtility.DbFactory.DbSession.DbContext.Set<TSource>().Count();
            else
                count = DBUtility.DbFactory.DbSession.DbContext.Set<TSource>().Count(wherelambda);
            if (count > 0)
                return true;
            return false;
        }
    }
}
