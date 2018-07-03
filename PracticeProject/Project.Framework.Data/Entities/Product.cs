using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Framework.Data.Entities
{
    [Table("Products")]
    [Serializable]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Remark { get; set; }
        public bool IsDelete { get; set; }
    }
}
