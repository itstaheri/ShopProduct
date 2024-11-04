using Asp.Versioning;
using Azure.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces.OTP;
using Shop.Application.MessageResult;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.OTP;
using Shop.Domain.Enums;

namespace Shop.Endpoint.Rest.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion(1)]
    [EnableCors("cors")]
    public class OtpController : ControllerBase
    {


        private readonly OTPAbstraction _otp;


        public OtpController(OTPAbstraction otp)
        {
            _otp = otp;
        }
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


            _otp.ExpireAt = DateTime.Now.AddMinutes(3);
            var key = _otp.Send(new Domain.Models.OTP.SendOTP
            {
                OTPChannel = (Domain.Enums.OTPChannel)request.Channel,
                Refrence = request.Refrence

            });

            return Ok(new ResponseDto
            {
                Message = OTPMessageResult.OperationSuccess,
                Result = key,
                StatusCode = 200
            });
        }
    }
}
