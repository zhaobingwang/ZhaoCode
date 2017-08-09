using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsAndStoredProcedure
{
    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public DateTime RegTime { get; set; }
        public byte IsDelete { get; set; }
        public virtual Province Province { get; set; }
    }
}
