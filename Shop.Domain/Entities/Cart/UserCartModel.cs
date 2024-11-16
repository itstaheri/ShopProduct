using Shop.Domain.Entities.Product;
using Shop.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Cart
{
    public class UserCartModel : BaseEntity
    {
        public UserCartModel(long userId, long productId, long colorId, long quantity)
        {
            UserId = userId;
            ProductId = productId;
            ColorId = colorId;
            Quantity = quantity;

        }

        public void Edit(long quantity)
        {
            Quantity = quantity;
        }

        public long UserId { get; set; }
        public List<UserModel> Users { get; set; }
        public long ProductId { get; set; }
        public List<ProductModel> Products { get; set; }
        public long ColorId { get; set; }
        public long Quantity { get; set; }
    }
}
