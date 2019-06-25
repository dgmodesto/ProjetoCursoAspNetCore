using System.Collections.Generic;

namespace StoreOfBuild.Domain
{
    public interface IRepository<TEntity>
    {
         IEnumerable<TEntity> All();
         TEntity GetById(int id);

         void Save(TEntity entity);
    }
}