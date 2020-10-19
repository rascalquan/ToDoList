using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Core.Models
{
    /// <summary>
    /// 待办项目状态
    /// </summary>
    public enum ToDoState
    {
        /// <summary>
        /// 未完成
        /// </summary>
        Undo =0,
        /// <summary>
        /// 已完成
        /// </summary>
        Done = 1
    }

    public enum ErrorCode
    {

        Success=0,

        //1xxx内部服务相关错误
        UnknownError = 1001,
        InternalError = 1002,
        ServiceTempUnavailable = 1003,

        //2xxx参数相关错误
        InvalidParameter = 2001,

        //3xxx授权相关错误
        InvalidToken = 3001,
        ExpiredToken = 3002,

        //4xxxx业务相关错误
    }
}
