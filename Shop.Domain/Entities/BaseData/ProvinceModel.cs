using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.BaseData
{
    public class ProvinceModel : BaseEntity
    {
        public ProvinceModel(string name, int citryId)
        {
            Name = name;
            CitryId = citryId;
        }

        public string  Name { get;private set; }
        public int CitryId { get;private set; }
        public CityModel City { get; private set; }
    }
}
