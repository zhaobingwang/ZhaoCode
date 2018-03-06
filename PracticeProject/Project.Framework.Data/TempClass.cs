using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Framework.Data
{
    [Table("temp_table")]
    public class TempClass
    {
        public Guid Id { get; set; }
        public int MyProperty { get; set; }
    }
}
