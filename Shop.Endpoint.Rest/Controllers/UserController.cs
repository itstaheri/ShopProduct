using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces.Auth;
using Shop.Application.Mapper;
using Shop.Application.MessageResult;
using Shop.Application.Services;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.User;

namespace Shop.Endpoint.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtAuthentication _jwtAuthentication;
        public UserController(IUserService userService, IJwtAuthentication jwtAuthentication)
        {
            _userService = userService;
            _jwtAuthentication = jwtAuthentication;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto login)
        {
            try
            {

                var result = _userService.Login(login);

                if (result.Success)
                {
                    var token = _jwtAuthentication.GenerateToken(result.Result);

                    return Ok(new ResponseDto { Message = BaseMessageResult.OperationSuccess ,StatusCode = 200,Result = token});

                }

                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex.InnerException);
            }
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(CreateUserDto request,CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.SignupAsync(request, cancellationToken);

                return Ok(result.Success());


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex.InnerException);
            }
        }
    }
}
