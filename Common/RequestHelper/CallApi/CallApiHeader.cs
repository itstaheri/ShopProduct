using System;
using System.Collections.Generic;
using System.Text;

namespace Common.RequestHelper.CallApi
{
    public sealed class CallApiHeader
    {
        public CallApiHeader(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}
