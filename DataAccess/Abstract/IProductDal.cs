using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        List<Product> GetAll();//Product tablosundaki verilerin hepsini getir.
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        List<Product> GetAllbyCategory(int categoryId);

    }
}
