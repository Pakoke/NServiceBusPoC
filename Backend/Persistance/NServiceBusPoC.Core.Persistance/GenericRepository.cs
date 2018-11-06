﻿using NServiceBusPoC.Core.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NServiceBusPoC.Core.Persistance
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly NServiceBusPoCContext DbContext;
        protected DbSet<TEntity> _objectSet;

        public GenericRepository(NServiceBusPoCContext dbContext)
        {
            DbContext = dbContext;
            _objectSet = DbContext.Set<TEntity>();
        }

        public virtual TEntity GetById(int id)
        {
            return _objectSet.Find(id);
        }

        public virtual TEntity GetById(string id)
        {
            return _objectSet.Find(id);
        }

        public virtual TEntity GetById(params object[] id)
        {
            return _objectSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate = null)
        {

            if (predicate != null)
            {
                return _objectSet.Where(predicate).ToList();
            }
            //Add to list, to execute the query inside of the repo.
            return _objectSet.AsEnumerable().ToList();
        }

        public TEntity Get(Func<TEntity, bool> predicate)
        {
            return _objectSet.FirstOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            _objectSet.Add(entity);

        }

        public void Delete(TEntity entity)
        {
            _objectSet.Remove(entity);
        }

        public void Edit(TEntity entity)
        {
            _objectSet.Attach(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _objectSet.AddRange(entities);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _objectSet.RemoveRange(entities);
        }

    }
}
