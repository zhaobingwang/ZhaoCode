using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string PosterName { get; set; }
        public string Message { get; set; }
        public DateTime CreationTime { get; set; }
    }
}