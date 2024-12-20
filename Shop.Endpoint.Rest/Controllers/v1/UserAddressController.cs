using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces.Auth;
using Shop.Application.Services;
using Shop.Domain.Dtos.Profile;
using Shop.Endpoint.Rest.ActionFilters;

namespace Shop.Endpoint.Rest.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion(1)]
    [JWTAuthorize]
    public class UserAddressController : ControllerBase
    {
        private readonly IUserAddressService _userAddressService;
        private readonly IJwtAuthentication _jwt;
        public UserAddressController(IUserAddressService userAddress, IJwtAuthentication jwt)
        {
            _userAddressService = userAddress;
            _jwt = jwt;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            long userId = _jwt.GetCurrentUserId();
            var result = await _userAddressService.GetUserAddressAsync(userId, cancellationToken);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]  AddUserAddressDto address, CancellationToken cancellationToken)
        {
            long userId = _jwt.GetCurrentUserId();
            var result = await _userAddressService.AddAddressAsync(address, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("Remove")]
        public IActionResult Remove(long userAddressId)
        {
            try
            {
                _userAddressService.RemoveAddress(userAddressId);

                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost("Update")]
        public IActionResult Update(UpdateUserAddressDto address)
        {
            try
            {
                var result = _userAddressService.UpdateAddress(address);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
