using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Repositories
{
   public class UserRepository
    {
        private StoreDbEntities userDb;

        public UserRepository()
        {
            userDb = new StoreDbEntities();
        }

        public IQueryable<User> GetAll()
        {
            return userDb.Users;
        }

        public void Create(User user)
        {
            userDb.Users.Add(user);
            userDb.SaveChanges();
        }

    }
}
