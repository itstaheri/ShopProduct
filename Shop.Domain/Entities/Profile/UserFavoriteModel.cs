using Shop.Domain.Entities.Product;
using Shop.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Profile
{
    public class UserFavoriteModel : BaseEntity
    {
        public UserFavoriteModel(long userId, long productId) 
        {
            UserId = userId;
            ProductId = productId;
        }

        public long UserId { get; set; }
        public UserModel User { get; set; }
        public long ProductId { get; set; }
        public ProductModel Product { get; set; }
    }
}
