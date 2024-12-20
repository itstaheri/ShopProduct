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
    public class UserCartController : ControllerBase
    {
        private readonly IUserCartService _userCart;
        private readonly IJwtAuthentication _jwt;

        public UserCartController(IUserCartService userCart, IJwtAuthentication jwt)
        {
            _userCart = userCart;
            _jwt = jwt;
        }

        [HttpGet("Get")]
        public  async Task<IActionResult> Get(GetUserCartFilterRequestDto cart, CancellationToken cancellationToken)
        {
            long userId = _jwt.GetCurrentUserId();

            var result = await _userCart.GetUserCartAsync(cart, cancellationToken);

            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddUserCartRequestDto Cart, CancellationToken cancellationToken)
        {
            long userId = _jwt.GetCurrentUserId();

            var result = await _userCart.AddUserCartAsync(Cart, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(long userCartId, CancellationToken cancellationToken)
        {
            await _userCart.RemoveUserCartAsync(userCartId, cancellationToken);

            return Ok();
        }
    }
}
