using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Log
    {
        public Guid LogId { get; set; }
        public string LogLevel { get; set; }
        public string LogContext { get; set; }
        public DateTime LogDate { get; set; }
    }
}
