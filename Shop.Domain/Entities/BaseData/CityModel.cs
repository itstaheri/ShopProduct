using Shop.Domain.Entities.Inventory;
using Shop.Domain.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.BaseData
{
    public class CityModel : BaseEntity
    {
        public CityModel(string name, long provinceId)
        {
            Name = name;
            ProvinceId = provinceId;
        }

        public string Name { get;private set; }
        public long ProvinceId { get; private set; }
        public ProvinceModel Province { get; set; }
        public List<InventoryModel> Inventories { get; private set; }
        public List<UserAddressModel> Addresses { get; private set; }
    }
}
