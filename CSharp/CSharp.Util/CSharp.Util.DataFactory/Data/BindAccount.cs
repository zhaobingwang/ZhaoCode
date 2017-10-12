using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Util.DataFactory.Data
{
    [Table("BindAccounts")]
    public class BindAccount
    {
        public BindAccount()
        {
            User = new HashSet<User>();
        }
        public virtual ICollection<User> User { get; set; }

        public int Id { get; set; }
        public string Type { get; set; }
    }
}
