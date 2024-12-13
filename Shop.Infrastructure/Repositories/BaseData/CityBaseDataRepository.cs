using Shop.Domain.Entities.BaseData;
using Shop.Domain.Repositories.BaseData;
using Shop.Infrastructure.Database.SqlServer.Efcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories.BaseData
{
    public class CityBaseDataRepository : GenericRepository<CityModel>, ICityBaseDataRepository
    {
        public CityBaseDataRepository(ShopDbContext context) : base(context)
        {
        }
    }
}
