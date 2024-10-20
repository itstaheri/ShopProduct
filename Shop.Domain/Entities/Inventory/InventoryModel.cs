using Shop.Domain.Entities.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Inventory
{
    public class InventoryModel : BaseEntity
    {
        public InventoryModel(string name, long provinceId, long cityId, string address, string postCode)
        {
            Name = name;
            ProvinceId = provinceId;
            CityId = cityId;
            Address = address;
            PostCode = postCode;
        }

        public void Edit(string name, long provinceId, long cityId, string address, string postCode)
        {
            Name = name;
            ProvinceId = provinceId;
            CityId = cityId;
            Address = address;
            PostCode = postCode;
        }

        public string Name { get; set; }
        public long ProvinceId { get; set; }
        public ProvinceModel Province { get; set; }
        public long CityId { get; set; }
        public CityModel City { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
    }
}
