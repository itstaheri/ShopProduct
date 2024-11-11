using Shop.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories.User
{
    public interface IUserRepository : IGenericRepository<UserModel>
    {
    }
}
