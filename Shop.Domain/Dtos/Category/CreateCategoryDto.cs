using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Category
{
    public record CreateCategoryDto
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public long? CategoryParentId { get; set; }
    }
}
