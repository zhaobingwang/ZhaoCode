using BlogAppDAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BlogApp.Models
{
    public class BlogDetailViewModel
    {
        public int Id { get; set; }
        [DisplayName("标题")]
        public string Title { get; set; }
        [DisplayName("正文")]
        public string Body { get; set; }
        [DisplayName("博主")]
        public string AuthorName { get; set; }
        [DisplayName("所属分类")]
        public string CategoryName { get; set; }
        [DisplayName("发布日期")]
        public DateTime CreationTime { get; set; }
        [DisplayName("更新日期")]
        public DateTime UpdateTime { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public string Poster { get; set; }
    }
}