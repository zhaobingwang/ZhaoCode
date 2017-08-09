using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsAndStoredProcedure
{
    public class Province
    {
        public Province()
        {
            Users = new HashSet<User>();
        }
        public int Id { get; set; }
        [StringLength(200)]
        public string ProvinceName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
