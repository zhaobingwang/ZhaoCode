using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebAPI.Models.Response
{
    public class ProductResponse
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Remark { get; set; }
    }
}