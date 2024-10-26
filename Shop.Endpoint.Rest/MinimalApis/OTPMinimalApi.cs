using Asp.Versioning.Builder;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces.OTP;
using Shop.Application.MessageResult;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.OTP;
using Shop.Domain.Enums;

namespace Shop.Endpoint.Rest.MinimalApis
{
    public static class OTPMinimalApi
    {
        public static void AddOtpMinimalApi(this WebApplication app)
        {
            ApiVersionSet apiVersionSet = app.NewApiVersionSet()
    .HasApiVersion(new ApiVersion(1))
    .ReportApiVersions()
    .Build();
            var group = app.MapGroup("api/OTP");

            app.MapPost("/Send", (SendOTPRequestDto request, [FromServices] OTPAbstraction otpService) =>
            {

                if (!Enum.IsDefined(typeof(OTPChannel), request.Channel))
                    return new ResponseDto
                    {
                        Message = "Channel Is not defiend",
                        Result = null,
                        StatusCode = 200
                    };


                otpService.ExpireAt = DateTime.Now.AddMinutes(3);
                var key = otpService.Send(new Domain.Models.OTP.SendOTP
                {
                    OTPChannel = (Domain.Enums.OTPChannel)request.Channel,
                    Refrence = request.Refrence

                });
                return new ResponseDto
                {
                    Message = OTPMessageResult.OperationSuccess,
                    Result = key,
                    StatusCode = 200
                };
            }).WithGroupName("OTP").WithApiVersionSet(apiVersionSet).MapToApiVersion(1);

        }

    }
}
