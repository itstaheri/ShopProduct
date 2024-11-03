using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Inventory
{
    public record GetInventoryRequestDto : PaginationRequestDto
    {
        public string Name { get; set; }
        public long ProvinceId { get; set; }
        public long CityId { get; set; }
    }
}
