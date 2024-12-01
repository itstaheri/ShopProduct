using Shop.Domain.Entities.DeliverySetting;
using Shop.Domain.Entities.Discount;
using Shop.Domain.Entities.Profile;
using Shop.Domain.Entities.User;
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
        public OrderModel(long userId, long userAddressId, string? trckingCode, long deliveryMethodId, long deliveryMethodTermId, OrderStatus orderStatus, long? discountId) 
        {
            UserId = userId;
            UserAddressId = userAddressId;
            TrckingCode = trckingCode;
            DeliveryMethodId = deliveryMethodId;
            DeliveryMethodTermId = deliveryMethodTermId;
            OrderStatus = orderStatus;
            DiscountId = discountId;
        }

        public void Edit(long userAddressId, string? trckingCode, long deliveryMethodId, long deliveryMethodTermId, OrderStatus orderStatus, long? discountId)
        {
            UserAddressId = userAddressId;
            TrckingCode = trckingCode;
            DeliveryMethodId = deliveryMethodId;
            DeliveryMethodTermId = deliveryMethodTermId;
            OrderStatus = orderStatus;
            DiscountId = discountId;
        }

        public long UserId {  get; set; }
        public UserModel User { get; set; }
        public long UserAddressId { get; set; }
        public UserAddressModel UserAddresse { get; set; }
        public string? TrckingCode { get; set; }
        public long DeliveryMethodId { get; set; }
        public DeliveryMethodModel DeliveryMethod { get; set; }
        public long DeliveryMethodTermId { get; set; }
        public DeliveryMethodTermModel DeliveryMethodTerm { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public long? DiscountId { get; set; }
        public DiscountModel Discount { get; set; }
        public List<OrderIthemModel> OrderIthems { get; set; }
    }
}
