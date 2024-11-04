using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Services;
using Shop.Domain.Dtos.Property;
using Shop.Endpoint.Rest.ActionFilters;

namespace Shop.Endpoint.Rest.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion(1)]
    [JWTAuthorize]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost("GetAll")]
        public virtual async Task<IActionResult> GetAll([FromBody]string name, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _propertyService.GetAllPropertyAsync(name, cancellationToken);

                return Ok(result.Success);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetById")]
        public virtual async Task<IActionResult> GetById([FromQuery(Name = "GetById")]long PropertyId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _propertyService.GetPropertyAsync(PropertyId, cancellationToken);

                return Ok(result.Success);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Create")]
        public virtual IActionResult Create([FromBody] CreatePropertyRequestDto createProperty)
        {
            try
            {
                _propertyService.CreateProperty(createProperty);

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Update")]
        public virtual IActionResult Update(UpdatePropertyRequestDto updateProperty)
        {
            try
            {
                _propertyService.UpdateProperty(updateProperty);

                return Ok();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Delete")]
        public virtual IActionResult Delete(DeletePropertyRequestDto deleteProperty)
        {
            try
            {
                _propertyService.DeleteProperty(deleteProperty);

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
