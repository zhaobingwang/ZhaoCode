using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.WebAPI.Models.Response;
using Project.Framework.Data;
using Project.Framework.Data.Entities;

namespace Project.WebAPI.Models
{
    /// <summary>
    /// 数据模型转换Response Model扩展方法
    /// </summary>
    public static partial class ModelConvert
    {
        #region User Model Convert
        /// <summary>
        /// User模型扩展方法：转换为API Response Model
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static UserResponse ToResponse(this User user)
        {
            UserResponse response = new UserResponse();
            response.Name = user.Name;
            return response;
        }

        public static List<UserStatisticsResponse> ToResponse(this List<User> users)
        {
            List<UserStatisticsResponse> responses = new List<UserStatisticsResponse>();
            foreach (var user in users)
            {
                UserStatisticsResponse response = new UserStatisticsResponse();
                response.Name = user.Name;
                response.CreateDate = user.CreateDate.ToString("yyyy-MM-dd HH:mm:ss");
                response.ModifyDate = user.ModifyDate.ToString("yyyy-MM-dd HH:mm:ss");
                responses.Add(response);
            }
            return responses;
        }
        #endregion


        #region Product Model Convert
        public static ProductResponse ToResponse(this Product product)
        {
            ProductResponse response = new ProductResponse();
            response.Name = product.Name;
            response.Price = product.Price;
            response.Remark = product.Remark;
            return response;
        }
        #endregion
    }
}