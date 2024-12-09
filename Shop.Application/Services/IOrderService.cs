using Common.Converter;
using Microsoft.Extensions.Caching.Distributed;
using Shop.Application.Mapper;
using Shop.Application.MessageResult;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.Order;
using Shop.Domain.Dtos.Profile;
using Shop.Domain.Entities.Order;
using Shop.Domain.Entities.Profile;
using Shop.Domain.Enums;
using Shop.Domain.Repositories.Order;
using Shop.Domain.Repositories.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public interface IOrderService
    {
        public OperationResult AddOrder(AddOrderRequestDto order);
        public OperationResult UpdateOrder(UpdateOrderRequestDto order);
        public OperationResult RemoveOrder(long orderId);
        public Task<OperationResult<List<OrderDto>>> GetAllOrderWithPaginationAsync(GetAllOrderFilterRequestDto filter, CancellationToken cancellationToken);
        public Task<OperationResult<OrderDto>> GetOrderAsync(long orderId, CancellationToken cancellationToken);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OperationResult AddOrder(AddOrderRequestDto order)
        {
            try
            {
                var orderModel = new OrderModel(order.UserId, order.UserAddressId, order.TrckingCode, order.DeliveryMethodId, order.DeliveryMethodTermId,
                    order.OrderStatus, order.DiscountId);
                _orderRepository.Add(orderModel);

                _orderRepository.Save();

                return new OperationResult(true, OrderMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OperationResult UpdateOrder(UpdateOrderRequestDto order)
        {
            var checkOrder = _orderRepository.Get(x => x.Id == order.Id);
            if (checkOrder == null)
                return new OperationResult<OrderDto>(null, false, OrderMessageResult.OrderNotFound);

            try
            {
                checkOrder.Edit(order.UserAddressId, order.TrckingCode, order.DeliveryMethodId, 
                    order.DeliveryMethodTermId, order.OrderStatus, order.DiscountId);
                _orderRepository.Save();

                return new OperationResult(true, OrderMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public OperationResult RemoveOrder(long orderId)
        {
            try
            {
                _orderRepository.Remove(orderId);

                return new OperationResult(true, OrderMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<OperationResult<List<OrderDto>>> GetAllOrderWithPaginationAsync(GetAllOrderFilterRequestDto orderFilter, CancellationToken cancellationToken)
        {
            try
            {
                var result = new List<OrderDto>();

                var orders = await _orderRepository.GetAllWithPaginationAsync(new GetAllOrderFilterRequestDto
                {
                    Page = orderFilter.Page,
                    PageSize = orderFilter.PageSize,
                    UserId = orderFilter.UserId,
                }, cancellationToken);

                foreach (var order in orders.List)
                {
                    result.Add(GeneralMapper.Map<OrderModel, OrderDto>(order));
                }

                return new OperationResult<List<OrderDto>>(result, true, OrderMessageResult.OperationSuccess);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<OperationResult<OrderDto>> GetOrderAsync(long orderId, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _orderRepository.GetAsync(x => x.Id == orderId, cancellationToken);

                return new OperationResult<OrderDto>(GeneralMapper.Map<OrderModel, OrderDto>(order), true, OrderMessageResult.OperationSuccess);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
