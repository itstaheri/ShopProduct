using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Product
{
    public record GetAllProductFilterRequestDto : PaginationRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public long CategoryId { get; set; } = 0;
    }
}
