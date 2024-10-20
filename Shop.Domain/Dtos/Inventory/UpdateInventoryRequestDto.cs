using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Inventory
{
    public record UpdateInventoryRequestDto : CreateInventoryRequestDto
    {
        public long Id { get; set; }
    }
}
