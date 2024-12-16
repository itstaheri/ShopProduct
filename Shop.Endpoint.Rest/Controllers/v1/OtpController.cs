using Asp.Versioning;
using Azure.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces.OTP;
using Shop.Application.MessageResult;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.OTP;
using Shop.Domain.Enums;
using Shop.Endpoint.Rest.ActionFilters;
namespace Shop.Endpoint.Rest.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion(1)]

    public class OtpController : ControllerBase
    {


        private readonly OTPAbstraction _otp;

        public OtpController(OTPAbstraction otp)
        {
            _otp = otp;
        }
        [HttpGet("CheckOTPRequestExist")]
        public IActionResult CheckOTPRequestExist([FromQuery(Name = "key")] string Key)
        {
            var result = _otp.CheckOTPRequestExist(Key);
            return Ok(new ResponseDto
            {
                Result = result.Success,
                Message = result.Message,
            });
        }
        [ParamValidatorAttribute]

        [HttpPost("OtpRequest")]
        public IActionResult OtpRequest([FromBody]SendOTPRequestDto request)
        {

            if (!Enum.IsDefined(typeof(OTPChannel), request.Channel))
                return Ok(new ResponseDto
                {
                    Message = OTPMessageResult.ChannelIsNotDefiend,
                    Result = null,
                    StatusCode = 200
                });


            _otp.ExpireAt = DateTime.Now.AddMinutes(2);
            var result = _otp.Send(new Domain.Models.OTP.SendOTP
            {
                OTPChannel = (Domain.Enums.OTPChannel)request.Channel,
                Refrence = request.Refrence

            });

            return Ok(new ResponseDto
            {
                Message = result.Message,
                Result = result.Success,
                StatusCode = 200
            });
        }
        [HttpPost("DisableOTP")]
        public IActionResult DisableOTP([FromBody] DisableOtpRequestDto otp)
        {
            _otp.DisableOTP(otp.Key);

            return Ok(new ResponseDto
            {
                Message = BaseMessageResult.OperationSuccess,
                StatusCode = 200,
                Result = true
            });
        }
    }
}
