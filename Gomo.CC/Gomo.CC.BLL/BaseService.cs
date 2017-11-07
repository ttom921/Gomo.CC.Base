using Gomo.CC.IBLL;
using Gomo.CC.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Gomo.CC.BLL
{
    public abstract class BaseService<T> : IBaseService<T>
    {
        public IBaseDal<T> CurrentDal { get; set; }
        public BaseService(IBaseDal<T> baseDal)
        {
            CurrentDal = baseDal;
        }

        #region 查詢
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {

            return CurrentDal.GetEntities(whereLambda);
        }
        //public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total,
        //                                         Expression<Func<T, bool>> whereLambda,
        //                                         Expression<Func<T, S>> orderByLamba,
        //                                         bool isAsc
        //                                         )
        //{
        //    int totaltotal = 0;
        //    return CurrentDal.GetPageEntities(pageSize, pageIndex,out totaltotal, whereLambda, orderByLamba, isAsc);

        //}
        #endregion
        #region cud

        #endregion
        public T Add(T entity)
        {
            CurrentDal.Add(entity);
            
            //DbSession.SaveChanges();
            return entity;
        }

        bool IBaseService<T>.Delete(T entity)
        {
            throw new NotImplementedException();
        }

        bool IBaseService<T>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        bool IBaseService<T>.Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
