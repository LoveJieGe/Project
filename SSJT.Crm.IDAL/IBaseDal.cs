using SSJT.Crm.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.IDAL
{
    public interface IBaseDal<T> where T:class,new()
    {
        /// <summary>
        /// 获取满足指定条件的数据
        /// </summary>
        /// <param name="lambdaWhere">获取数据的条件lambda</param>
        /// <returns></returns>
        T LoadEntity(Expression<Func<T, bool>> lambdaWhere);
        /// <summary>
        /// 分页形式的数据获取
        /// </summary>
        /// <typeparam name="S">在isAsc为false时，指定按什么类型的字段排序</typeparam>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示多少条数据</param>
        /// <param name="totalCount">输出参数，输出总共的条数，为了在页面分页栏显示</param>
        /// <param name="isAsc">true升序排序，false降序排序，false时需给出排序的lambda表达式</param>
        /// <param name="oederLambdaWhere">排序的lambda表达式</param>
        /// <param name="lambdaWhere">获取数据的lambda</param>
        /// <returns></returns>
        IEnumerable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int totalCount, bool isAsc, Expression<Func<T, S>> oederLambdaWhere, Expression<Func<T, bool>> lambdaWhere);
        /// <summary>
        /// 得到最大的ID
        /// </summary>
        /// <returns></returns>
        T GetMaxModel();
        /// <summary>
        /// 判断是否存在某条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Exists(int id);
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Add(T model);
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Update(T model);
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Delete(T model);

    }
}
