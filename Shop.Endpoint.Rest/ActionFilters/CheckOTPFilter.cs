using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Shop.Application.Interfaces.OTP;
using Shop.Domain.Dtos;
using Shop.Domain.Models.OTP;

namespace Shop.Endpoint.Rest.ActionFilters
{
    public class CheckOTPFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var otpService = context.HttpContext.RequestServices.GetRequiredService<OTPAbstraction>();
            var otpHeader = context.HttpContext.Request.Headers["OTP"];
            if (!string.IsNullOrEmpty(otpHeader))
            {
                var otp = JsonConvert.DeserializeObject<CheckOTP>(otpHeader);

                var result = otpService.CheckOTP(new Domain.Models.OTP.CheckOTP
                {
                    Code = otp.Code,
                    Key = otp.Key,
                });

                if (!result.Success)
                {
                    context.Result = new ObjectResult(new ResponseDto
                    {
                        Message = result.Message,
                        Result = false,
                        StatusCode = 200
                    });
                }
            }
            else
            {
                context.Result = new ObjectResult(new ResponseDto
                {
                    Message = "Otp header is empty!",
                    Result = false,
                    StatusCode = 400
                });
            }
        }
    }
}
