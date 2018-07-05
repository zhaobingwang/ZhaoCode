using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebAPI.Enums
{
    public enum StatusCodeEnum
    {
        Success = 200, //请求(或处理)成功
        Error = 500, //内部请求出错
        Unauthorized = 401,//未授权标识
        ParameterError = 400,//请求参数不完整或不正确
        TokenInvalid = 403,//请求TOKEN失效
        HttpMehtodError = 405,//HTTP请求类型不合法
        HttpRequestError = 406,//HTTP请求不合法
        URLExpireError = 407,//HTTP请求不合法,该URL已经失效
    }
}