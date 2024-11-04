using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Category
{
    public record DeleteCategoryRequestDto
    {
        public long CategoryId { get; set; }
    }
}
