using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Interfaces.Auth;
using Shop.Application.Services;
using Shop.Domain.Dtos.Order;
using Shop.Domain.Dtos.Profile;
using Shop.Endpoint.Rest.ActionFilters;
using System.Text.Json.Serialization.Metadata;

namespace Shop.Endpoint.Rest.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion(1)]
    [JWTAuthorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _order;
        private readonly IJwtAuthentication _jwt;

        public OrderController(IOrderService order, IJwtAuthentication jwt)
        {
            _order = order;
            _jwt = jwt;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(long orderId, CancellationToken cancellationToken)
        {
            var result = await _order.GetOrderAsync(orderId, cancellationToken);

            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(GetAllOrderFilterRequestDto order, CancellationToken cancellationToken)
        {
            long userId = _jwt.GetCurrentUserId();

            var result = await _order.GetAllOrderWithPaginationAsync(order, cancellationToken);

            return Ok(result);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] AddOrderRequestDto order)
        {
            long userId = _jwt.GetCurrentUserId();

            var result = _order.AddOrder(order);

            return Ok(result);
        }

        [HttpDelete("Remove")]
        public IActionResult Remove(long orderId)
        {
            _order.RemoveOrder(orderId);

            return Ok();
        }
    }
}
