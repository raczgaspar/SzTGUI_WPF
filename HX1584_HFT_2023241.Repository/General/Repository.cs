﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HX1584_HFT_2023241.Repository.Database;
using HX1584_HFT_2023241.Repository.Interface;

namespace HX1584_HFT_2023241.Repository.General
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected ShopDbContext ctx;
        public Repository(ShopDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }

        public abstract T Read(int id);
        public abstract void Update(T item);

    }
}
