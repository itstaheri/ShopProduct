using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.RequestHelper.CallApi
{
    public class CallApiRestSharp : CallApiHelper
    {
        private RestClient client;
        string BaseUrl = string.Empty;
        public CallApiRestSharp(string baseUrl)
        {
            BaseUrl = baseUrl;




        }

        public override async Task<CallApiResponse<T>> PostRequestAsync<T>(string url, object request, ParameterTypeEnum parameterType, List<CallApiHeader> headers = null)
        {
            try
            {
                 ServicePointManager.ServerCertificateValidationCallback += (_, _, _, _) => true;

                client = new RestClient(BaseUrl);
                RestRequest restRequest = new RestRequest(url, Method.Post);
                
                restRequest.AddJsonBody(request);
                restRequest.AddHeader("Content-Type", "application/json");
                if (headers != null)
                {
                    foreach (var header in headers)
                        restRequest.AddHeader(header.Key, header.Value);
                }
                var response = await client.ExecuteAsync(restRequest);

                return new CallApiResponse<T>
                {
                    Content = !string.IsNullOrEmpty(response.Content) ? JsonConvert.DeserializeObject<T>(response.Content) : default,
                    StatusCode = (int)response.StatusCode
                };



            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex.InnerException);
            }
        }

        public override async Task<CallApiResponse> PostRequestAsync(string url, object request, ParameterTypeEnum parameterType, List<CallApiHeader> headers = null)
        {
            try
            {
                client = new RestClient(BaseUrl);
                RestRequest restRequest = new RestRequest(url, Method.Post);

                restRequest.AddJsonBody(request);

                if (headers != null)
                {
                    foreach (var header in headers)
                        restRequest.AddHeader(header.Key, header.Value);
                }
                var response = await client.ExecuteAsync(restRequest);

                return new CallApiResponse
                {
                    Content = response.Content,
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
