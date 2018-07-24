using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using JobExample.Job;

namespace JobExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceName = "JobExample";
            string serviceDisplayName = "JobExample显示名称";
            string serviceDescription = "JobExample描述信息";
            HostFactory.Run(x =>
            {
                x.Service<ServiceManager>(s =>
                {
                    s.ConstructUsing(name => new ServiceManager(serviceName));
                    s.WhenStarted(ts => ts.OnStart());
                    s.WhenStopped(ts => ts.OnStop());
                });
                x.RunAsLocalSystem();   // 以本地系统账号运行,可选的还有网络服务和本地服务账号
                x.SetDescription(serviceDescription);
                x.SetDisplayName(serviceDisplayName);
                x.SetServiceName(serviceName);
            });
        }
    }
}
