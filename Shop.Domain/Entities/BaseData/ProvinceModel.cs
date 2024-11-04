using Shop.Domain.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.BaseData
{
    public class ProvinceModel : BaseEntity
    {
        public ProvinceModel(string name)
        {
            Name = name;
        }

        public string  Name { get;private set; }
        public List<CityModel> Cities { get; private set; }
        public List<InventoryModel> Inventories { get; private set; }
    }
}
