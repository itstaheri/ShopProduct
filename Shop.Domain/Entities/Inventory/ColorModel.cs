using Shop.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Inventory
{
    public class ColorModel : BaseEntity
    {
        public ColorModel()
        {
                
        }
        public string Name { get;private set; }
        public ICollection<InventoryItemModel> Items { get; private set; }
        public List<OrderIthemModel> OrderIthems { get; private set; }
    }
}
