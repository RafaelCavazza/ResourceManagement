using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Extensions
{
    //Retirado de http://myview.rahulnivi.net/dbset-find-api-missing-entity-framework-core-final-rc1-version/
    //Revisar estrutura proposta.
    public static class EntityExtensions
    {
        public static TEntity Find<TEntity>(this DbSet<TEntity> set, object keyValue) where TEntity : class
        {
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var query = Queryable.Where(set, (Expression<Func<TEntity, bool>>)
                Expression.Lambda(
                    Expression.Equal(
                        Expression.Property(parameter, "Id"),
                        Expression.Constant(keyValue)),
                    parameter));

            // Look in the database
            return query.FirstOrDefault();
        }
    }
}
