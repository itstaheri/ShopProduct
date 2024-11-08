using System;
using System.Collections.Generic;
using System.Text;

namespace Common.RequestHelper.CallApi
{
    public class CallApiResponse
    {
        public int StatusCode { get; set; }
        public string Content { get; set; }
        public string Error { get; set; }
    }
    public class CallApiResponse<T> : CallApiResponse
    {
        public T Content { get; set; }
    }
}
