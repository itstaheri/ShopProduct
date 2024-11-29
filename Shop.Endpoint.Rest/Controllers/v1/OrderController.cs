using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Services;
using Shop.Domain.Dtos.Order;
using Shop.Domain.Dtos.Profile;
using Shop.Endpoint.Rest.ActionFilters;

namespace Shop.Endpoint.Rest.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion(1)]
    [JWTAuthorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _order;

        public OrderController(IOrderService order)
        {
            _order = order;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery(Name = "UserId")] long orderId, CancellationToken cancellationToken)
        {
            var result = await _order.GetOrderAsync(orderId, cancellationToken);

            return Ok(result.Success);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery(Name = "UserId")] GetAllOrderFilterRequestDto order, CancellationToken cancellationToken)
        {
            var result = await _order.GetAllOrderWithPaginationAsync(order, cancellationToken);

            return Ok(result.Success);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] AddOrderRequestDto order)
        {
            var result = _order.AddOrder(order);

            return Ok(result.Success);
        }

        [HttpDelete("Remove")]
        public IActionResult Remove(long orderId)
        {
            _order.RemoveOrder(orderId);

            return Ok();
        }
    }
}
