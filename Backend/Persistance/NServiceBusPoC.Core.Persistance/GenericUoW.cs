﻿using NServiceBusPoC.Core.Persistance.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NServiceBusPoC.Core.Persistance
{
    public class GenericUoW : IGenericUoW
    {
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        readonly NServiceBusPoCContext entities = null;
        //ICustomersRepository customerRepository;
        //IPeopleRepository peopleRepository;
        //IStoreRepository storeRepository;
        IDbContextTransaction transaction = null;
        bool disposed = false;
        bool transactionOpen = false;


        public GenericUoW(NServiceBusPoCContext entities, bool createTransaction = true)
        {
            this.entities = entities;
            this.transactionOpen = createTransaction;


        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
            }

            IGenericRepository<TEntity> repo = new GenericRepository<TEntity>(entities);

            repositories.Add(typeof(TEntity), repo);
            return repo;
        }

        //public ICustomersRepository GetCustomerRepository()
        //{

        //    if (customerRepository == null)
        //    {
        //        customerRepository = new CustomersRepository(entities);
        //    }

        //    return customerRepository;

        //}

        //public IPeopleRepository GetPeopleRepository()
        //{

        //    if (peopleRepository == null)
        //    {
        //        peopleRepository = new PeopleRepository(entities);
        //    }
        //    return peopleRepository;

        //}

        //public IStoreRepository GetStoreRepository()
        //{
        //    if (storeRepository == null)
        //    {
        //        storeRepository = new StoreRepository(entities);
        //    }
        //    return storeRepository;
        //}




        public void SaveChanges()
        {


            try
            {
                if (this.transactionOpen)
                {
                    OpenTransaction();
                }

                entities.SaveChanges();

                if (this.transactionOpen)
                {
                    this.transaction.Commit();
                    this.transaction.Dispose();
                }


            }
            catch (Exception e)
            {
                //TODO log in the system
                if (this.transactionOpen)
                    this.transaction.Rollback();

                //throw controllated exception after the rollback
                throw e;
            }



        }



        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    entities.Dispose();
                }
                //To clean the transaction always do.
                this.transaction?.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            this.transaction?.Dispose();
        }

        ~GenericUoW()
        {
            Dispose(false);
        }

        private void OpenTransaction()
        {

            //if it´s not created yet, start the transaction
            if (this.transaction == null)
            {

                this.transaction = this.entities.Database.BeginTransaction();
            }

        }
    }
}
