using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Inventory
{
    public class InventoryColorModel : BaseEntity
    {
        public long InventoryId { get;private set; }
        public long ColorId { get; private set; }
        public ICollection<InventoryItemModel> InventoryItems { get; private set; }
    }
}
