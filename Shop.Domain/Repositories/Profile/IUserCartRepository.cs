using Shop.Domain.Dtos;
using Shop.Domain.Entities.Profile;
using Shop.Domain.Dtos.Profile;

namespace Shop.Domain.Repositories.Profile
{
    public interface IUserCartRepository : IGenericRepository<UserCartModel>
    {
        Task<PaginationResponsDto<UserCartModel>> GetAllWithPaginationAsync(GetUserCartFilterRequestDto input, CancellationToken cancellationToken);
    }
}
