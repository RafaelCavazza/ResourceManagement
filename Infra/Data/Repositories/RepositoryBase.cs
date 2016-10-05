using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Domain.Interfaces.Repositories;
using Infra.Data.Context;
using Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class                                                    
    {
        protected DataBaseContext dbContext = new DataBaseContext();

        public virtual void Add(TEntity entity)
        {
            var type = entity.GetType();
            var props = new List<PropertyInfo>(type.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                if(prop.Name=="Id")
                {
                    prop.SetValue(entity, Guid.NewGuid());
                    continue;
                }
            }

            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(Guid id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public virtual void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            dbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    dbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~RepositoryBase() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            //GC.SuppressFinalize(this);
        }
        #endregion
    }
}
