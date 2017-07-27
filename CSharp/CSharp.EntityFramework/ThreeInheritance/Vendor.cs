using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInheritance
{
    [Table("Vendors")]
    public class Vendor:Person
    {
        public decimal HourlyRate { get; set; }
    }
}
