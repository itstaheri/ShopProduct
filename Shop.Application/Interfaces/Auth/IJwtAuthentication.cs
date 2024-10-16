using Shop.Domain.Dtos;
using Shop.Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces.Auth
{
    public interface IJwtAuthentication
    {
        TokenResultDto GenerateToken(UserInfoDto userInfo);
        long GetCurrentUserId();
        bool TokenIsValid(string token);
       
    }
}
