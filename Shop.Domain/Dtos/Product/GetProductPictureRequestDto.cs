using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Product
{
    public record GetProductPictureRequestDto
    {
        public long ProductId { get; set; }
        public long ProductCommentId { get; set;}
    }
}
