using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
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

        public UserCartController(IUserCartService userCart)
        {
            _userCart = userCart;
        }

        [HttpGet("Get")]
        public  async Task<IActionResult> Get([FromQuery(Name = "UserId")] GetUserCartFilterRequestDto cart, CancellationToken cancellationToken)
        {
            var result = await _userCart.GetUserCartAsync(cart, cancellationToken);

            return Ok(result.Success);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddUserCartRequestDto Cart, CancellationToken cancellationToken)
        {
            var result = await _userCart.AddUserCartAsync(Cart, cancellationToken);

            return Ok(result.Success);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(long userCartId, CancellationToken cancellationToken)
        {
            await _userCart.RemoveUserCartAsync(userCartId, cancellationToken);

            return Ok();
        }
    }
}
