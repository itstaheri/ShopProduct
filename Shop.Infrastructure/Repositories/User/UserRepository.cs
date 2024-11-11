using Shop.Domain.Entities.User;
using Shop.Domain.Repositories.User;
using Shop.Infrastructure.Database.SqlServer.Efcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories.User
{
    public class UserRepository : GenericRepository<UserModel>, IUserRepository
    {
        public UserRepository(ShopDbContext context) : base(context) 
        { 
        }
    }
}
