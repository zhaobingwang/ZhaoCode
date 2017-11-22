using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSite.Domain
{
    public class User
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [StringLength(12, MinimumLength = 2)]
        [DisplayName("昵称")]
        public string NickName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [StringLength(12, MinimumLength = 2)]
        [DisplayName("名字")]
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 注册日期
        /// </summary>
        [DisplayName("注册日期")]
        public DateTime RegDate { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        [DisplayName("修改日期")]
        public DateTime ModifyDate { get; set; }
    }
}
