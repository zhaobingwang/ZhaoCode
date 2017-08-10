using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndTransaction
{
    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string Bio { get; set; }
        public DateTime RegTime { get; set; }
        public byte IsDelete { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
