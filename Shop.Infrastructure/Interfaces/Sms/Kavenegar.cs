using Common.Helper.Json;
using Common.RequestHelper.CallApi;
using Shop.Application.Interfaces.Sms;
using Shop.Domain.Models.Api;
using Shop.Domain.Models.SMS;
using Shop.Domain.Models.SMS.Kavenegar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Interfaces.Sms
{
    public class Kavenegar : ISMS
    {

        private readonly CallApiHelper _callApi;
        KavenegarApiConfig Apiconfig;
        public Kavenegar()
        {
            var json = JsonReader.LoadJson(Environment.CurrentDirectory + "/ThirdPartyApiConfig.json");
            Apiconfig = json.ToClass<KavenegarApiConfig>("SMS");

            _callApi = new CallApiRestSharp(Apiconfig.BaseUrl);

        }

        public SendSmsResponse Send<I>(I input) where I : SendSmsBaseRequest
        {
            throw new NotImplementedException();
        }

        public async Task<SendSmsResponse> SendAsync<I>(I input) where I : SendSmsBaseRequest
        {
            try
            {
                var request = input as KavenegarSendSingleSmsRequest;

                var response = await _callApi.PostRequestAsync<KavenegarSendSingleSmsResponse>(Apiconfig.SendSmsMethod, request, ParameterTypeEnum.Jsonbody);

                if (response.StatusCode is not 200)
                    return new SendSmsResponse { Message = "ErrorOnCallKavenrgar", Status = 0 };
                return new SendSmsResponse
                {
                    Status = response.Content.status,
                    Message = response.Content.statustext
                };


            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
