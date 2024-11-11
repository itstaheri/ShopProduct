using Shop.Domain.Entities.Inventory;
using Shop.Domain.Repositories.Inventory;
using Shop.Infrastructure.Database.SqlServer.Efcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories.Inventory
{
    public class InventoryRepository : GenericRepository<InventoryModel>, IInventoryRepository
    {
        public InventoryRepository(ShopDbContext context) : base(context)
        {
        }
    }
}
