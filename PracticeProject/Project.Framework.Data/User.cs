using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Framework.Data
{
    [Table("users")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
