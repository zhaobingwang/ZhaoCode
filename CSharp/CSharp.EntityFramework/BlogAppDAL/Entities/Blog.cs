using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppDAL.Entities
{
    public partial class Blog
    {
        public Blog()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        [DisplayName("标题")]
        public string Title { get; set; }
        [Required]
        [DisplayName("正文")]
        public string Body { get; set; }
        [DisplayName("创建时间")]
        public DateTime CreateTime { get; set; }
        [DisplayName("更新时间")]
        public DateTime UpdateTime { get; set; }
        [DisplayName("选择类别")]
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
