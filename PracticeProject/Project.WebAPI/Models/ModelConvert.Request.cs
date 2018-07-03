using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.WebAPI.Models.Request;
using Project.Framework.Data;
using Project.Framework.Data.Entities;

namespace Project.WebAPI.Models
{
    public static partial class ModelConvert
    {
        public static User ToEntity(this UserRequest request)
        {
            User user = new User();
            user.Name = request.Name;
            user.CreateDate = DateTime.Now;
            user.ModifyDate = DateTime.Now;
            return user;
        }
    }
}