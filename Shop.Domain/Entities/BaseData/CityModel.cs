using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.BaseData
{
    public class CityModel : BaseEntity
    {
        public CityModel(string name)
        {
            Name = name;
        }

        public string Name { get;private set; }
        public List<ProvinceModel> Provinces { get; set; }
    }
}
