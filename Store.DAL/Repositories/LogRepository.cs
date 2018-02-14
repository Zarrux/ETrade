using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Repositories
{
  public class LogRepository
    {
        private long DatetimeMinTimeTicks = (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks;

        private StoreDbEntities StoreDb;

        public LogRepository()
        {
            StoreDb = new StoreDbEntities();
        }
        
        public void Create(Log obj)
        {
            obj.Date = DateTime.Today;
            //UNIX Time = 1300123800000; 


            try
            {
                StoreDb.Logs.Add(obj);
                StoreDb.SaveChanges();
            }
            catch (Exception )
            {
                
            }
        }

        public IQueryable<Log> GetAll()
        {
            return StoreDb.Logs;
        }

        public  Log GetById(int i)
        {
            Log p = StoreDb.Logs.Find(i);
            return p != null ? p : null;
        }

        public  void Remove(int i)
        {
            throw new NotImplementedException();
        }

        public  void Update(Log obj)
        {
            throw new NotImplementedException();
        }

        private long ToJavaScriptMilliseconds()
        {
            var date = DateTime.Now;
            var dt = date.ToUniversalTime().Ticks;
            var dif = dt - DatetimeMinTimeTicks;
            var res = dif / 10000;
            return res;
        }
    }
}

