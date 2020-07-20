using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        int Save(TEntity entity);
        int Update(TEntity entity);
        int Delete(int id);
    }
}
