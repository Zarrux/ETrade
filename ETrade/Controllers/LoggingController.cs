using ETrade.Models;
using Store.DAL.Entities;
using Store.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETrade.Controllers
{
    [Authorize]
    public class LoggingController : BaseController
    {
        
        // GET: Logging
        public ActionResult GetLogs()
        {
            

            var log = new LogRepository().GetAll();
            var res = log.Select(MapToModel);

            return View(res);
        }

        private Log MapFromModel(LoggingViewModel model)
        {
            return new Log
            {
                Id = model.Id,
                User = model.User,
                IPAddress = model.IPAddress,
                Controller = model.Controller,
                Action = model.Action,
                Method = model.Method,
                LogType = model.LogType,
                Date = model.Date
            };
        }
        private LoggingViewModel MapToModel(Log log)
        {
            return new LoggingViewModel
            {
                Id = log.Id,
                User = log.User,
                IPAddress = log.IPAddress,
                Controller = log.Controller,
                Action = log.Action,
                Method = log.Method,
                LogType = log.LogType,
                Date = log.Date
            };
        }
    }
}