using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebAPI.Models.Verify
{
    public class Token
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名对应前面Token
        /// </summary>
        public Guid SignToken { get; set; }

        /// <summary>
        /// Token过期时间
        /// </summary>
        public DateTime ExpireTime { get; set; }
    }
}