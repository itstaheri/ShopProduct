using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Mapper;
using Shop.Application.Services;
using Shop.Endpoint.Rest.ActionFilters;

namespace Shop.Endpoint.Rest.Controllers.v1
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion(1)]
    public class LookUpController : ControllerBase
    {
        private readonly ILookupService _lookupService;

        public LookUpController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        [HttpGet("GetCityList")]
        public async Task<IActionResult> GetCityList([FromQuery(Name = "provinceId")] long provinceId, CancellationToken cancellationToken)
        {
            var result = await _lookupService.GetCityListAsync(provinceId, cancellationToken);
            return Ok(result.Success());
        }
        [HttpGet("GetProvinceList")]
        public async Task<IActionResult> GetProvinceList(CancellationToken cancellationToken)
        {
            var result = await _lookupService.GetProvinceListAsync(cancellationToken);
            return Ok(result.Success());
        }

    }
}
