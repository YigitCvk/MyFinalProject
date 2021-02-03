using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //Solid
    /*
     * Single Responsibility Principle
       Open/Closed Principle
       Liskov ‘s Substitution Principle
       Interface Segregation Principle
       Dependency Inversion Principle
     */
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
            
        }
    }
}
