using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Project.WebAPI.Common
{
    public class SignHelper
    {
        public static bool Validate(string timeStamp, string nonce, int userId, string token, string data, string signature)
        {
            var hash = System.Security.Cryptography.MD5.Create();
            var signStr = timeStamp + nonce + userId + token + data;
            var sortStr = string.Concat(signStr.OrderBy(c => c));
            var bytes = Encoding.UTF8.GetBytes(sortStr);
            var md5Val = hash.ComputeHash(bytes);
            StringBuilder result = new StringBuilder();
            foreach (var item in md5Val)
            {
                result.Append(item.ToString("X2"));
            }
            return result.ToString().ToUpper() == signature;
        }
    }
}