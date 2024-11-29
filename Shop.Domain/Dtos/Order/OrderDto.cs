using Shop.Domain.Entities.DeliverySetting;
using Shop.Domain.Entities.Discount;
using Shop.Domain.Entities.Order;
using Shop.Domain.Entities.Profile;
using Shop.Domain.Entities.User;
using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Order
{
    public record OrderDto : AddOrderRequestDto
    {
        public long Id { get; set; }
        public UserAddressModel UserAddresse { get; set; }
        public DeliveryMethodModel DeliveryMethod { get; set; }
        public DeliveryMethodTermModel DeliveryMethodTerm { get; set; }
        public bool IsActive { get; set; }
    }
}
