using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RequestHelper.CallApi
{
    public class CallApiHttpClient : CallApiHelper
    {
        HttpClientHandler handler;
        HttpClient client;
        public CallApiHttpClient(string baseUrl)
        {
            handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback +=
               (_, _, _, _) => true;
            client = new HttpClient(handler);
            client.BaseAddress = new Uri(baseUrl);

        }

        public async override Task<CallApiResponse<T>> PostRequestAsync<T>(string url, object request, ParameterTypeEnum parameterType, List<CallApiHeader> headers = null)
        {
            try
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Post,url);

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        httpRequest.Headers.Add(header.Key, header.Value);

                    }
                }
                var content = JsonConvert.SerializeObject(request);
                httpRequest.Content = new StringContent(content, Encoding.UTF8,
                                    "application/json");
                
                var response = await client.SendAsync(httpRequest);

                var responseContent = await response.Content.ReadAsStringAsync();
                //{"code":400,"message":"خطای سیستمی, لطفا با مدیر سامانه تماس حاصل فرمایید","responseBody":null,"time":"1728216910064"}
                return new CallApiResponse<T>
                {
                    Content = !string.IsNullOrEmpty(responseContent) ? JsonConvert.DeserializeObject<T>(responseContent) : default,
                    StatusCode = (int)response.StatusCode
                };

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async override Task<CallApiResponse> PostRequestAsync(string url, object request, ParameterTypeEnum parameterType, List<CallApiHeader> headers = null)
        {
            try
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        httpRequest.Headers.Add(header.Key, header.Value);

                    }
                }
                var content = JsonConvert.SerializeObject(request);
                httpRequest.Content = new StringContent(content);
                var response = await client.SendAsync(httpRequest);

                var responseContent = await response.Content.ReadAsStringAsync();

                return new CallApiResponse
                {
                    Content = responseContent,
                    Error = null,
                    StatusCode = (int)response.StatusCode
                };

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
