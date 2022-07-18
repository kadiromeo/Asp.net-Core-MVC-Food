using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoreAndFood.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreAndFood.Repositories
{
    public class GenericRepository<T> where T:class
    {
        Context db = new Context();

        public List<T> TList()
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }

        public void TDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        public void TUpdate(T p)
        {
            db.Set<T>().Update(p);
            db.SaveChanges();
        }

        public T TGet(short id)
        {
            return db.Set<T>().Find(id);
        }

        public List<T> TList(string p)
        {
            return db.Set<T>().Include(p).ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return db.Set<T>().Where(filter).ToList();
        }
    }
}
