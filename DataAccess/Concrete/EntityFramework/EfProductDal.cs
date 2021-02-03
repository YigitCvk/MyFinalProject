using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext contex=new NorthwindContext())//yazılan nesnler iş bitince bellekten atar//using=Idiposable pattern implementation of c#
            {
                var adedEntity = contex.Entry(entity);
                adedEntity.State = EntityState.Added;
                contex.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext contex = new NorthwindContext())//yazılan nesnler iş bitince bellekten atar//using=Idiposable pattern implementation of c#
            {
                var deletedEntity = contex.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                contex.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);

            }   
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext contex = new NorthwindContext())//yazılan nesnler iş bitince bellekten atar//using=Idiposable pattern implementation of c#
            {
                var updatedEntity = contex.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                contex.SaveChanges();
            }
        }
    }
}
