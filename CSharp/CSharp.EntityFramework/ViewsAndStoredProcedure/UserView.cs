using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsAndStoredProcedure
{
    public class UserView
    {
        public int UserId { get; set; }
        public string UserNickName { get; set; }
        public DateTime RegTime { get; set; }
        public byte IsDelete { get; set; }
        public string ProvinceName { get; set; }
    }
}
