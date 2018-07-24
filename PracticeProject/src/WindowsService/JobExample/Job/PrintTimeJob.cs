using NLog;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobExample.Job
{
    public class PrintTimeJob : IJob
    {
        private static Logger logger;
        public Task Execute(IJobExecutionContext context)
        {
            logger = LogManager.GetCurrentClassLogger();
            Task t = Task.Factory.StartNew(() =>
            {
                logger.Info($"# 时间：[{DateTime.Now}]");
            });
            return t;
        }
    }
}
