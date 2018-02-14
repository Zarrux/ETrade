using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class LoggingViewModel
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string IPAddress { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Method { get; set; }
        public string LogType { get; set; }
        public DateTime Date { get; set; }
    }
}