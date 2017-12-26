using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzNetConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ////调度器
            //IScheduler scheduler;
            ////调度器工厂
            //ISchedulerFactory factory;

            ////创建一个调度器
            //factory = new StdSchedulerFactory();
            //scheduler = factory.GetScheduler();
            //scheduler.Start();

            ////2、创建一个任务
            //IJobDetail job = JobBuilder.Create<TimeJob>().WithIdentity("job1", "group1").Build();

            ////3、创建一个触发器
            ////DateTimeOffset runTime = DateBuilder.EvenMinuteDate(DateTimeOffset.UtcNow);
            //ITrigger trigger = TriggerBuilder.Create()
            //    .WithIdentity("trigger1", "group1")
            //    .WithCronSchedule("0/5 * * * * ?")     //5秒执行一次
            //                                           //.StartAt(runTime)
            //    .Build();
            ////4、将任务与触发器添加到调度器中
            //scheduler.ScheduleJob(job, trigger);
            ////5、开始执行
            //scheduler.Start();

            try
            {
                Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = Common.Logging.LogLevel.Info };

                // Grab the Scheduler instance from the Factory 
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();

                // and start it off
                scheduler.Start();

                // define the job and tie it to our HelloJob class
                IJobDetail job = JobBuilder.Create<HelloJob>()
                    .WithIdentity("job1", "group1")
                    .Build();

                // Trigger the job to run now, and then repeat every 2 seconds
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger1", "group1")
                    .StartNow()
                    .WithSimpleSchedule(
                        x => x
                        .WithIntervalInSeconds(2)
                        .RepeatForever())
                    .Build();

                //Tell quartz to schedule the job using our trigger
                scheduler.ScheduleJob(job, trigger);

                //some sleep to show what's happening
                Thread.Sleep(TimeSpan.FromSeconds(10));

                //and last shut down the scheduler when you are ready to close your program
                scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }
    }

    public class HelloJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"Greetings from HelloJob! [{DateTime.Now}]");
        }
    }
}
