using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Repositories
{
   public class ProductRepository
    {
        private StoreDbEntities StoreDb;

        public ProductRepository()
        {
            StoreDb = new StoreDbEntities();
        }
        public IQueryable<Product> GetAll()
        {
            return StoreDb.Products;
        }

        public void Create(Product product)
        {
            StoreDb.Products.Add(product);
            StoreDb.SaveChanges();
        }
    }
}
