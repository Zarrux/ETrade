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
       

        public  Product GetById(int i)
        {
            Product d = StoreDb.Products.Find(i);
            if (d == null) return null;
            return d;
        }
        public  void Remove(int i)
        {
            StoreDb.Products.Remove(GetById(i));
            StoreDb.SaveChanges();
        }
        public void Update(Product product)
        {
            try
            {
                var x = product;
                StoreDb.Entry(x).State = System.Data.EntityState.Modified;
                StoreDb.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
