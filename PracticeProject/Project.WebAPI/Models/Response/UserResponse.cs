using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebAPI.Models.Response
{
    public class UserResponse
    {
        public string Name { get; set; }
    }

    public class UserStatisticsResponse
    {
        public string  Name { get; set; }
        public string CreateDate { get; set; }
        public string ModifyDate { get; set; }
    }
}