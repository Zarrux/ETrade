using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.DAL.Entities;
using Store.DAL.Repositories;

namespace ETrade.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AsserSorting()
        {
            ProductRepository repository = new ProductRepository();

            IQueryable<Product> product = repository.GetAll();

            repository.Create(new Product
            {
                Active = false,
                Category = "Cat",
                Description = "Desc",
                Name = "Name",
                Price = 212
            });



        }
    }
}
