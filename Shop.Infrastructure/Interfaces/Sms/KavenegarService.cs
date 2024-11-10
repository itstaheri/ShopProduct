using Common.Helper.Json;
using Common.RequestHelper.CallApi;
using Kavenegar;
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
    public class KavenegarService : ISMS
    {

        private readonly CallApiHelper _callApi;
        KavenegarApiConfig Apiconfig;
        public KavenegarService()
        {
            var json = JsonReader.LoadJson(Environment.CurrentDirectory + "/ThirdPartyApiConfig.json");
            Apiconfig = json.GetSection("SMS").ToClass<KavenegarApiConfig>("Kavenegar");

            _callApi = new CallApiRestSharp(Apiconfig.BaseUrl);

        }

        public SendSmsResponse Send<I>(I input) where I : SendSmsBaseRequest
        {
            try
            {
                var request = input as KavenegarSendSingleSmsRequest;
                var kavenegar = new KavenegarApi(Apiconfig.ApiKey);
                var response = kavenegar.Send("2000500666", request.Receptor, request.Message);

                //var response = await _callApi.PostRequestAsync<KavenegarSendSingleSmsResponse>(Apiconfig.SendSmsMethod, request, ParameterTypeEnum.Jsonbody);

                if (response.Status is not 1)
                    return new SendSmsResponse { Message = "ErrorOnCallKavenrgar", Status = 0 };
                return new SendSmsResponse
                {
                    Status = response.Status,
                    Message = response.StatusText
                };


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<SendSmsResponse> SendAsync<I>(I input) where I : SendSmsBaseRequest
        {
            try
            {
                var request = input as KavenegarSendSingleSmsRequest;
                var kavenegar = new KavenegarApi(Apiconfig.ApiKey);
                var response =  kavenegar.Send("1000689696", request.Receptor, request.Message);

                //var response = await _callApi.PostRequestAsync<KavenegarSendSingleSmsResponse>(Apiconfig.SendSmsMethod, request, ParameterTypeEnum.Jsonbody);

                if (response.Status is not 200)
                    return new SendSmsResponse { Message = "ErrorOnCallKavenrgar", Status = 0 };
                return new SendSmsResponse
                {
                    Status = response.Status,
                    Message = response.StatusText
                };


            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
