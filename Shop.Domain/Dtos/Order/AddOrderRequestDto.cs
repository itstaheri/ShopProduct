using Shop.Domain.Entities.DeliverySetting;
using Shop.Domain.Entities.Profile;
using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Order
{
    public record AddOrderRequestDto
    {
        public long UserId { get; set; }
        public long UserAddressId { get; set; }
        public string? TrckingCode { get; set; }
        public long DeliveryMethodId { get; set; }
        public long DeliveryMethodTermId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public long? DiscountId { get; set; }
    }
}
