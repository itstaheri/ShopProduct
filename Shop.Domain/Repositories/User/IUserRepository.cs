using Shop.Domain.Dtos;
using Shop.Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories.User
{
    public interface IUserRepository
    {

        public Task<OperationResult> CreateUserAsync(CreateUserDto createUser, CancellationToken cancellationToken);
        public OperationResult<UserInfoDto> CheckUserValid(string username, string password);
    }
}
