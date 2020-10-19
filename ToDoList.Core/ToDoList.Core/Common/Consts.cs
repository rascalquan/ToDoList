using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Core.Common
{
    public class Consts
    {

    }

    public class ErrorConsts
    {
        public const string UnknownError = "Unknown error";
        public const string InternalError = "Internal Error";
        public const string ServiceTempUnavailable = "Service temporarily unavailable";
        public const string InvalidParameter = "Invalid parameter";
        public const string InvalidToken = "Invalid token";
        public const string ExpiredToken = "Expired token";
    }
}
