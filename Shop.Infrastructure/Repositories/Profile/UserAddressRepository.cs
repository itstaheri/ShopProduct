using Shop.Domain.Entities.Profile;
using Shop.Domain.Repositories.Profile;
using Shop.Infrastructure.Database.SqlServer.Efcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories.Profile
{
    public class UserAddressRepository : GenericRepository<UserAddressModel>, IUserAddressRepository
    {
        public UserAddressRepository(ShopDbContext context) : base(context)
        {
        }
    }
}
