using Gomo.CC.IBLL;
using Gomo.CC.IDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gomo.CC.BLL
{
    public abstract class BaseService<T> : IBaseService<T>
    {
        public IBaseDal<T> CurrentDal { get; set; }
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
