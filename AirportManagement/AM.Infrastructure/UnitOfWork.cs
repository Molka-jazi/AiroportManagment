﻿using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class UnitOfWork:IUnitOfWork
    {
        private DbContext context;

        public UnitOfWork(DbContext ctx)
        {
            context = ctx;
        }
        public IGenericRepository<T> Repository<T>() where T : class
        {

            return new GenericRepository<T>(context);
        }
        public int Save()
        {
            return context.SaveChanges();
        }

        //Disposeble =aala fazet el supperssion mta3 el memoire liberer le contexte
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            //GC = garbale collector
            GC.SuppressFinalize(this);
        }

    }
}
