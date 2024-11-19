using Shop.Domain.Entities.BaseData;
using Shop.Domain.Entities.DeliverySetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Inventory
{
    public class InventoryModel : BaseEntity
    {
        public InventoryModel(string name ,long cityId, string address, string? postCode)
        {
            Name = name;
            CityId = cityId;
            Address = address;
            PostCode = postCode;
        }

        public void Edit(string name,  long cityId, string address, string? postCode)
        {
            Name = name;
            CityId = cityId;
            Address = address;
            PostCode = postCode;
        }
        public InventoryModel()
        {
                
        }

        public string Name { get;private set; }
        public long? CityId { get; private set; }
        public CityModel City { get; private set; }
        public string Address { get; private set; }
        public string? PostCode { get; private set; }
        public ICollection<InventoryItemModel> Items { get; private set; }
        public List<DeliveryMethodModel> DeliveryMethods { get; private set; }
    }
}
