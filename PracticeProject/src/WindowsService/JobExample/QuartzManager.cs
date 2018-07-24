using JobExample.Job;
using NLog;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobExample
{
    public class QuartzManager
    {
        private readonly IScheduler scheduler;
        private static Logger logger;

        private static QuartzManager manager;
        public static QuartzManager Manager
        {
            get { return manager; }
        }
        static QuartzManager()
        {
            manager = new QuartzManager();
        }

        private QuartzManager()
        {
            logger = LogManager.GetCurrentClassLogger();

            // 1.创建作业调度池(Scheduler)
            scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;

            // 2.创建一个具体的作业即job (具体的job需要单独在一个文件中执行)
            var job = JobBuilder.Create<PrintTimeJob>().Build();

            // 3.创建并配置一个触发器即trigger,10s执行一次。重复3次
            var trigger = TriggerBuilder.Create().WithSimpleSchedule(x => x.WithIntervalInSeconds(10).WithRepeatCount(2)).Build();

            // 4.将job和trigger加入到作业调度池中
            scheduler.ScheduleJob(job, trigger);

            #region 打印时间任务2 [PrintTimeJob2]
            var printTime2Job = JobBuilder.Create<PrintTimeJob2>()
                .WithIdentity("printTime2Job", "PrintTimeGroup")
                .Build();
            var printTime2Trigger = TriggerBuilder.Create()
                .WithIdentity("printTime2Job", "PrintTimeGroup")
                .StartNow()
                .WithSchedule(CronScheduleBuilder.CronSchedule("0 0/5 * * * ?"))  // 每5分钟执行一次
                .Build();
            scheduler.ScheduleJob(printTime2Job, printTime2Trigger);
            #endregion
        }

        public void Start()
        {
            scheduler.Start();
            logger.Info($"[Job] [{nameof(PrintTimeJob)}] start.");
        }

        public void Stop()
        {
            //true：表示该Sheduler关闭之前需要等现在所有正在运行的工作完成才能关闭
            //false：表示直接关闭
            scheduler.Shutdown(false);
            logger.Info($"[Job] [{nameof(PrintTimeJob)}] stop.");
        }

        public void Continue()
        {
            scheduler.ResumeAll();
            logger.Info($"[Job] [{nameof(PrintTimeJob)}] contnue.");
        }

        public void Pause()
        {
            scheduler.PauseAll();
            logger.Info($"[Job] [{nameof(PrintTimeJob)}] pause.");
        }
    }
}
