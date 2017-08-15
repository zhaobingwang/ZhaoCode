using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppDAL.Entities
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
