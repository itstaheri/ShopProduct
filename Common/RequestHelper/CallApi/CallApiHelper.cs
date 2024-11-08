using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestHelper.CallApi
{
    public abstract class CallApiHelper
    {
        public SecurityProtocolType Tls;

        public abstract Task<CallApiResponse<T>> PostRequestAsync<T>(string url, object request, ParameterTypeEnum parameterType, List<CallApiHeader> headers = null);

        public abstract Task<CallApiResponse> PostRequestAsync(string url,object request, ParameterTypeEnum parameterType,List<CallApiHeader> headers = null);
    }
}
