using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {   
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity GetById(Guid id);    
        IEnumerable<TEntity> GetAll();   

    }
}
