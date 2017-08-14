using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public DateTime RegTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public byte IsDelete { get; set; }
        public string Bio { get; set; }
        public virtual Province Province { get; set; }
    }
}
