using System;
using System.Collections.Generic;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository; 
        }

        void IServiceBase<TEntity>.Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IServiceBase<TEntity>.GetAll()
        {
            throw new NotImplementedException();
        }

        TEntity IServiceBase<TEntity>.GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        void IServiceBase<TEntity>.Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IServiceBase<TEntity>.Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
