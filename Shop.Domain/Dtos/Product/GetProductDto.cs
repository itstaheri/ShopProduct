using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Product
{
    public record GetProductDto
    {
        public long Id { get; set; }
    }
}
