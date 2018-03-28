using SSJT.Crm.Core;
using SSJT.Crm.DBUtility;
using SSJT.Crm.IDAL;
using SSJT.Crm.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SSJT.Crm.BLL
{
    public abstract class BaseService<T,K> where T:BaseModel,new() where K:IBaseDal<T>,new()
    {
        public IDbSession DbSession
        {
            get { return DbSessionFactory.GetDbSession(); }
        }
        public  IBaseDal<T> CurrentDal { get; set; }
        public BaseService()
        {
            CurrentDal = new K();
        }
        public T LoadEntity(Expression<Func<T, bool>> lambdaWhere)
        {
            return CurrentDal.LoadEntity(lambdaWhere);
        }
        public IEnumerable<T> LoadEntities(Expression<Func<T, bool>> lambdaWhere)
        {
            return CurrentDal.LoadEntities(lambdaWhere);
        }
        public IEnumerable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int totalCount, bool isAsc, 
            Expression<Func<T, S>> orederLambdaWhere, Expression<Func<T, bool>> lambdaWhere)
        {
           return  this.CurrentDal.LoadPageEntities<S>(pageIndex, pageSize, out totalCount, isAsc, orederLambdaWhere, lambdaWhere);
        }
        public T GetMaxModel()
        {
            return this.CurrentDal.GetMaxModel();
        }
        public bool Exists(int id)
        {
            return this.CurrentDal.Exists(id);
        }
        /// <summary>
        /// 添加数据之前
        /// </summary>
        /// <param name="model"></param>
        public virtual void BeforeAdd(T model)
        {
            HrEmploy user = SessionFactory.GetSessionServer().CurrentUser;
            if (user != null)
            {
                model["CreatorId"] = user.UserID;
                model["CreatorName"] = user.UserName;
            }
            model["CreateDate"] = DateTime.Now;
        }
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Add(T model)
        {
            this.BeforeAdd(model);
            this.CurrentDal.Add(model);
            this.DbSession.SaveChange();
        }
        /// <summary>
        /// 更新数据之前
        /// </summary>
        /// <param name="model"></param>
        public virtual void BeforeUpdate(T model)
        {
            HrEmploy user = SessionFactory.GetSessionServer().CurrentUser;
            if (user != null)
            {
                model["UpdaterID"] = user.UserID;
                model["UpdaterName"] = user.UserName;
            }
            model["UpdateDate"] = DateTime.Now;
        }
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(T model)
        {
            this.BeforeUpdate(model);
            this.CurrentDal.Update(model);
            this.DbSession.SaveChange();
        }
        public virtual void BeforeDelete(T model)
        {

        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(T model)
        {
            this.BeforeDelete(model);
            this.CurrentDal.Delete(model);
            this.DbSession.SaveChange();
        }
    }
}
