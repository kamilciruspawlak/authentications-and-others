using autentykacja_zadanie.Models;
using autentykacja_zadanie.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace autentykacja_zadanie.Repository
{
    public class AbstractRepository<T>  where T : class , IBasicEntity
    {
        public virtual void Create(T entity)
        {
            using (var context = new Models.ApplicationDbContext())
            {
                entity.DateCreate = DateTime.Now;
                entity.DateMod = DateTime.Now;
                entity.isActive = true;
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }
        public virtual void Update(T entity)
        {
            using (var context = new Models.ApplicationDbContext())
            {
                entity.DateMod = DateTime.Now;
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public virtual List<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            using (var context = new Models.ApplicationDbContext())
            {
                var query = context.Set<T>().Where(expression);
                return query.ToList();
            }
        }

        public virtual void Delete(T entity)
        {
            using (var context = new Models.ApplicationDbContext())
            {
                entity.DateMod = DateTime.Now;
                entity.isActive = false;
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}