using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Product
{
    public record GetProductCommentRequestDto
    {
        public long ProductCommentParentId { get; set; }
        public long ProductId { get; set; }
    }
}
