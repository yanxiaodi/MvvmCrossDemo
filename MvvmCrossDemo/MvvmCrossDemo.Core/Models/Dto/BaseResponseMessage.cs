using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmCrossDemo.Core.Models.Dto
{
    public class BaseResponseMessage
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class ResponseMessage<T> : BaseResponseMessage
    {
        public T Result { get; set; }
    }
}
