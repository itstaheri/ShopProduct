using Shop.Domain.Dtos.UserCart;
using Shop.Domain.Dtos;
using Shop.Domain.Entities.UserCart;
using Shop.Domain.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shop.Domain.Dtos.Profile;

namespace Shop.Domain.Repositories.Profile
{
    public interface IUserCartRepository : IGenericRepository<UserCartModel>
    {
        Task<PaginationResponsDto<UserCartModel>> GetAllWithPaginationAsync(GetUserCartFilterRequestDto input, CancellationToken cancellationToken);
    }
}
