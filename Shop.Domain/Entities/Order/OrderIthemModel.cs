using Shop.Domain.Entities.Inventory;
using Shop.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Order
{
    public class OrderIthemModel : BaseEntity
    {
        public OrderIthemModel(long orderId, long productId, long colorId, long price, int quantity, long discountPrice, long totalPrice)
        {
            OrderId = orderId;
            ProductId = productId;
            ColorId = colorId;
            Price = price;
            Quantity = quantity;
            DiscountPrice = discountPrice;
            TotalPrice = totalPrice;
        }

        public void Edit(long price, int quantity, long discountPrice, long totalPrice)
        {
            Price = price;
            Quantity = quantity;
            DiscountPrice = discountPrice;
            TotalPrice = totalPrice;
        }

        public long OrderId { get; set; }
        public OrderModel Order { get; set; }
        public long ProductId { get; set; }
        public ProductModel Product { get; set; }
        public long ColorId { get; set; }
        public ColorModel Color { get; set; }
        public long Price { get; set; }
        public int Quantity { get; set; }
        public long DiscountPrice { get; set; }
        public long TotalPrice { get; set; }
    }
}
