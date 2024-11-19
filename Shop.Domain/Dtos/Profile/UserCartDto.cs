using Shop.Domain.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Profile
{
    public record UserCartDto : PaginationRequestDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public ProductDto Product { get; set; }
        public long ColorId { get; set; }
        public long Quantity { get; set; }
    }
}
