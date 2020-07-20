using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IContactRepository<TEntity> : IRepository<TEntity>
    {
        IEnumerable<TEntity> FindByName(string name);
    }
}
