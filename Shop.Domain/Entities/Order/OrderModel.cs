using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Order
{
    public class OrderModel : BaseEntity
    {
        public OrderModel(long userId, long UserAddressId, string? trckingCode, long deliveryMethodId, OrderStatus orderStatus,) { }
    }
}
