using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces.Auth;
using Shop.Application.Mapper;
using Shop.Application.MessageResult;
using Shop.Application.Services;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.OTP;
using Shop.Domain.Dtos.User;
using Shop.Endpoint.Rest.ActionFilters;

namespace Shop.Endpoint.Rest.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion(1)]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtAuthentication _jwtAuthentication;
        public AuthController(IUserService userService, IJwtAuthentication jwtAuthentication)
        {
            _userService = userService;
            _jwtAuthentication = jwtAuthentication;
        }

        [HttpPost("Login")]
        public virtual IActionResult Login(LoginDto login)
        {
            try
            {

                var result = _userService.Login(login);
                if (result.Success)
                {
                    var token = _jwtAuthentication.GenerateToken(result.Result);

                    return Ok(new ResponseDto { Message = BaseMessageResult.OperationSuccess, StatusCode = 200, Result = token });

                }

                return Ok(new ResponseDto { Message = BaseMessageResult.OperationFaild,StatusCode = 401,Result = null});
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        [HttpPost("SignUp")]
        public virtual async  Task<IActionResult> SignUp(CreateUserDto request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.SignupWithDetailAsync(request, cancellationToken);

                return Ok(result.Success());


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        [CheckOTPFilter]
        [HttpPost("LoginOrSignupWithPhone")]
        public virtual async Task<IActionResult> LoginOrSignupWithPhone(LoginOrSignupWithPhoneRequestDto request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.LoginOrSignupWithPhoneAsync(request.PhoneNumber, cancellationToken);

                return Ok(result.Success());


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }
       
    }
}
