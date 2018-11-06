using System;
using System.Collections.Generic;

namespace NServiceBusPoC.Test.MockRepositories
{
    public class MockGeneralRepository<TEntity> where TEntity : class
    {
        public virtual void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(string id)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Edit(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(params object[] id)
        {
            throw new NotImplementedException();
        }
    }
}
