using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure(); //读取log4net配置信息
            try
            {
                int a = 0;
                int b = 10 / a;
            }
            catch (Exception ex)
            {
                ILog logger = LogManager.GetLogger("errorMsg");
                logger.Error(ex.ToString());
            }
        }
    }
}
