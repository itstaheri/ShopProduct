using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Shop.Application.Interfaces.Auth;
using Shop.Application.Mapper;
using Shop.Application.MessageResult;
using Shop.Application.Services;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.Inventory;
using Shop.Endpoint.Rest.ActionFilters;

namespace Shop.Endpoint.Rest.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion(1)]
    [JWTAuthorize]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }   

        [HttpPost("GetAll")]
        public virtual async Task<IActionResult> GetAll([FromBody]GetInventoryRequestDto getInventory, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _inventoryService.GetAllInventoryAsync(getInventory, cancellationToken);

                return Ok(result.Success());
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        [HttpGet("GetById")]
        public virtual async Task<IActionResult> GetById([FromQuery(Name ="GetById")]long inventoryId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _inventoryService.GetInventoryAsync(inventoryId, cancellationToken);

                return Ok(result.Success());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            
        [HttpPost("Create")]
        public virtual IActionResult Create([FromBody]CreateInventoryRequestDto createInventory)
        {
            try
            {
                _inventoryService.CreateInventory(createInventory);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Update")]
        public virtual IActionResult Update(UpdateInventoryRequestDto updateInventory)
        {
            try
            {
                _inventoryService.UpdateInventory(updateInventory);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("Delete")]
        public virtual IActionResult Delete(DeleteInventoryRequestDto deleteInventory)
        {
            try
            {
                _inventoryService.DeleteInventory(deleteInventory);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
