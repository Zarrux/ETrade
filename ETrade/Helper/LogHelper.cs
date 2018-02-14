using Store.DAL.Entities;
using Store.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETrade.Helper
{
    public static class LogHelper
    {
        private static LogRepository logRepo;

        static LogHelper()
        {
            logRepo = new LogRepository();
        }

        public static void Info(Log log)
        {
            log.LogType = "INFO";
            logRepo.Create(log);
        }
        public static void Error(Log log)
        {
            log.LogType = "Error";
            logRepo.Create(log);
        }
    }
}