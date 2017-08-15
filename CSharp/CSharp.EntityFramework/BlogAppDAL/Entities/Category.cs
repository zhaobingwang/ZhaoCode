using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppDAL.Entities
{
    public partial class Category
    {
        public Category()
        {
            Blogs = new HashSet<Blog>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        [DisplayName("分类名称")]
        public string CategoryName { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
