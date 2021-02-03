using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;//Naming Convencion
        public InMemoryProductDal()
        {
            _products = new List<Product> { 
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsINStock=15},
            new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsINStock=3},
            new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsINStock=2},
            new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsINStock=65},
            new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsINStock=1} };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        //LINQ-Language Integrated Query
        // => --> lambda demek
        public void Delete(Product product)
        {   //Gönderdiğ,m ürün Id sine sahip olan listedeki ürün Id sini bul demek
            Product productToDelete=_products.SingleOrDefault(p => p.ProductId==product.ProductId);
            //Tek bir eleman bulmaya yarar,her p elemanını bulmak için linq kullandık(first olan methodlarda olur)

            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllbyCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();

        }

        public void Update(Product product)
        {
            //Gönderdiğ,m ürün Id sine sahip olan listedeki ürün Id sini bul demek
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsINStock = product.UnitsINStock;
        }
    }
}
