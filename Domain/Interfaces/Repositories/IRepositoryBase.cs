using System;
using System.Collections.Generic;
using Sakura.AspNetCore;

namespace Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();

        IPagedList<TEntity> GetAllPaged(int pageIndex, int pageSize);
    }
}
