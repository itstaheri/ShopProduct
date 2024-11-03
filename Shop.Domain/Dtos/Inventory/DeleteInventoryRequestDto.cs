using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Inventory
{
    public record DeleteInventoryRequestDto
    {
        public long InventoryId { get; set; }
    }
}
