using System;
using System.Collections.Generic;

namespace Aplication.Interfaces
{
    public interface IAppServiceBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity GetById(Guid id);    
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetPaged(int pageIndex, int pageSize = 10);   
    }
}
