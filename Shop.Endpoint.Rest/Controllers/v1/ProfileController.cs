using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces.Auth;
using Shop.Application.Mapper;
using Shop.Application.Services;
using Shop.Domain.Dtos.Profile;
using Shop.Endpoint.Rest.ActionFilters;

namespace Shop.Endpoint.Rest.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion(1)]
    [JWTAuthorize]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly IJwtAuthentication _jwt;
        public ProfileController(IProfileService profileService, IJwtAuthentication jwt)
        {
            _profileService = profileService;
            _jwt = jwt;
        }

        [HttpGet("GetProfileInformation")]
        public async Task<IActionResult> GetProfileInformation(CancellationToken cancellationToken)
        {
            long userId = _jwt.GetCurrentUserId();
            var result = await _profileService.GetProfileInformationAsync(userId, cancellationToken);
            return Ok(result.Success());
        }

        [HttpGet("GetUserAddress")]
        public async Task<IActionResult> GetUserAddress(CancellationToken cancellationToken)
        {
            long userId = _jwt.GetCurrentUserId();
            var result = await _profileService.GetUserAddressAsync(userId, cancellationToken);
            return Ok(result.Success());
        }
        [HttpPost("AddAddress")]
        public async Task<IActionResult> AddAddress(AddUserAddressDto address,CancellationToken cancellationToken)
        {
            long userId = _jwt.GetCurrentUserId();
            var result = await _profileService.AddAddressAsync(address, cancellationToken);
            return Ok(result.Success());
        }
        [HttpPost("UpdateProfile")]
        public IActionResult UpdateProfile(UpdateProfileRequestDto request)
        {
            var result = _profileService.UpdateProfile(request);
            return Ok(result.Success());
        }
    }
}
