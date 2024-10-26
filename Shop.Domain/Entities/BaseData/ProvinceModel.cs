using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.BaseData
{
    public class ProvinceModel : BaseEntity
    {
        public ProvinceModel(string name, long cityId)
        {
            Name = name;
            CityId = cityId;
        }

        public string  Name { get;private set; }
        public long CityId { get;private set; }
        public CityModel City { get; private set; }
    }
}
