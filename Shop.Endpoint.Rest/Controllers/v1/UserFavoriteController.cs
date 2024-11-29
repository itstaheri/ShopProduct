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
    public class UserFavoriteController : ControllerBase
    {
        private readonly IUserFavoriteService _userFavorite;

        public UserFavoriteController(IUserFavoriteService userFavorite)
        {
            _userFavorite = userFavorite;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery(Name = "UserId")] GetUserFavoriteFilterRequestDto Favorite, CancellationToken cancellationToken)
        {
            var result = await _userFavorite.GetUserFavoriteAsync(Favorite, cancellationToken);

            return Ok(result.Success);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddUserFavoriteRequestDto Favorite, CancellationToken cancellationToken)
        {
            var result = await _userFavorite.AddUserFavoriteAsync(Favorite, cancellationToken);

            return Ok(result.Success);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(long userFavoriteId, CancellationToken cancellationToken)
        {
            await _userFavorite.RemoveUserFavoriteAsync(userFavoriteId, cancellationToken);

            return Ok();
        }
    }
}
