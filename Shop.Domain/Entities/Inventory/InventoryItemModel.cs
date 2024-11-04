using Shop.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Inventory
{
    public class InventoryItemModel : BaseEntity
    {
        public InventoryItemModel(string itemName, long quantity, int colorId, long inventoryId)
        {
            ItemName = itemName;
            Quantity = quantity;
            ColorId = colorId;
            InventoryId = inventoryId;
        }
        public void Edit(string itemName, long quantity, long colorId, long inventoryId)
        {
            ItemName = itemName;
            Quantity = quantity;
            ColorId = colorId;
            InventoryId = inventoryId;
        }
        public void SetProduct(long prodcutId) => ProductId = prodcutId;    

        public string ItemName { get; private set; }
        public long Quantity { get; private set; }
        public long ColorId { get; private set; }
        public ColorModel Color { get; private set; }
        public long InventoryId { get; private set; }
        public InventoryModel Inventory { get; private set; }
        //public long ProductInventoryId { get; private set; }
        //public ProductInventoryModel ProductInventory { get; private set; }
        public long? ProductId { get; private set; }
        public ProductModel Product { get; private set; }

        public bool CheckItemExist() => Quantity > 0;
    }
}
