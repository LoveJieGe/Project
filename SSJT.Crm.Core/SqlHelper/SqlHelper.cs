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
        /// <summary>
        /// 随机生成一个表的ID
        /// </summary>
        public static string  GenerateTableID()
        {
            TimeSpan span = (TimeSpan)(DateTime.Now - new DateTime(0x7d0, 1, 1));
            long num = Convert.ToInt64((double)(span.TotalMilliseconds / 100.0));
            StringBuilder builder = new StringBuilder();
            while (num >= 0x24L)
            {
                long num2 = num % 0x24L;
                if (num2 < 10L)
                {
                    builder.Insert(0, num2);
                }
                else
                {
                    builder.Insert(0, (char)((ushort)((0x41L + num2) - 10L)));
                }
                num /= 0x24L;
            }
            if (num > 0L)
            {
                if (num < 10L)
                {
                    builder.Insert(0, num);
                }
                else
                {
                    builder.Insert(0, (char)((ushort)((0x41L + num) - 10L)));
                }
            }
            return builder.ToString();
        }
    }
}
