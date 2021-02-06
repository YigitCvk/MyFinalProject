using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContex>:IEntityRepository<TEntity>
    
        where TEntity: class , IEntity , new()
        where TContex:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContex contex = new TContex())//yazılan nesnler iş bitince bellekten atar//using=Idiposable pattern implementation of c#
            {
                var adedEntity = contex.Entry(entity);
                adedEntity.State = EntityState.Added;
                contex.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContex contex = new TContex())//yazılan nesnler iş bitince bellekten atar//using=Idiposable pattern implementation of c#
            {
                var deletedEntity = contex.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                contex.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContex context = new TContex())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContex context = new TContex())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContex contex = new TContex())//yazılan nesnler iş bitince bellekten atar//using=Idiposable pattern implementation of c#
            {
                var updatedEntity = contex.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                contex.SaveChanges();
            }
        }
    }
}
