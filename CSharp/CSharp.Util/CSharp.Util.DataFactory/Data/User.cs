using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Util.DataFactory.Data
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            BindAccount = new HashSet<BindAccount>();
        }
        public virtual ICollection<BindAccount> BindAccount { get; set; }

        public Guid Id { get; set; }

        [StringLength(12,MinimumLength =2)]
        [DisplayName("名字")]
        public string Name { get; set; }

        public short Age { get; set; }

        public DateTime Birthday { get; set; }

        [DisplayName("注册日期")]
        public DateTime RegDate { get; set; }

        [DisplayName("修改日期")]
        public DateTime ModifyDate { get; set; }
    }
}
