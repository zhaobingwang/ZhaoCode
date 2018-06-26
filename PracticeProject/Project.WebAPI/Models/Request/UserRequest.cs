using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.WebAPI.Models.Request
{
    public class UserRequest
    {
        [MaxLength(12)]
        public string Name { get; set; }
    }

    public class UserUpdateRequest
    {
        public int Id { get; set; }
        [MaxLength(12)]
        public string Name { get; set; }
    }
}