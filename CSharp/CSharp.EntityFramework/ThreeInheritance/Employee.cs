using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInheritance
{
    [Table("Employees")]
    public class Employee:Person
    {
        public decimal Salary { get; set; }
    }
}
