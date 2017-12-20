using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo
{
    public class Notiy
    {
        public virtual bool Info(string messg)
        {
            //发送消息、邮件发送、短信发送。。。
            //.........
            if (string.IsNullOrWhiteSpace(messg))
            {
                return false;
            }
            return true;
        }
    }
}
