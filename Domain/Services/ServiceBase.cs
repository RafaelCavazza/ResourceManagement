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
            _repository.Add(entity);
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IServiceBase<TEntity>.GetAll()
        {
            return _repository.GetAll();
        }

        TEntity IServiceBase<TEntity>.GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        void IServiceBase<TEntity>.Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }

        void IServiceBase<TEntity>.Update(TEntity entity)
        {
            _repository.Update(entity);
        }
    }
}
