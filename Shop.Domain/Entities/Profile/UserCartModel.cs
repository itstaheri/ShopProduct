using Shop.Domain.Entities.Product;
using Shop.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Profile
{
    public class UserCartModel : BaseEntity
    {
        public UserCartModel(long userId, long productId, long colorId, int quantity)
        {
            UserId = userId;
            ProductId = productId;
            ColorId = colorId;
            Quantity = quantity;

        }

        public void Edit(int quantity)
        {
            Quantity = quantity;
        }

        public long UserId { get; set; }
        public UserModel User { get; set; }
        public long ProductId { get; set; }
        public ProductModel Product { get; set; }
        public long ColorId { get; set; }
        public int Quantity { get; set; }
    }
}
