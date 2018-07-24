using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobExample
{
    public class ServiceManager
    {
        private static Logger logger;
        private string ServiceName = string.Empty;
        public ServiceManager(string serviceName)
        {
            logger = LogManager.GetCurrentClassLogger();
            ServiceName = serviceName;
        }
        public void OnStart()
        {
            logger.Info($"[SERVICE] [{ServiceName}] start");
            QuartzManager.Manager.Start();
        }

        public void OnStop()
        {
            logger.Info($"[SERVICE] [{ServiceName}] stop");
            QuartzManager.Manager.Stop();
        }
    }
}
