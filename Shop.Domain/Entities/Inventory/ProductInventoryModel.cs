using Shop.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Inventory
{
    public class ProductInventoryModel : BaseEntity
    {
        public ProductInventoryModel(long productId, long inventoryItemId)
        {
            ProductId = productId;
            InventoryItemId = inventoryItemId;
        }

        public long ProductId { get;private set; }
        public long InventoryItemId { get;private set; }
        public ICollection<ProductModel> Products { get; private set; }
        public ICollection<InventoryItemModel> InventoryItems { get; private set; }

    }
}
