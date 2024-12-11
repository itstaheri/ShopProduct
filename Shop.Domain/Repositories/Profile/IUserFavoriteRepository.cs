using Shop.Domain.Dtos;
using Shop.Domain.Entities.Profile;
using Shop.Domain.Dtos.Profile;

namespace Shop.Domain.Repositories.Profile
{
    public interface IUserFavoriteRepository : IGenericRepository<UserFavoriteModel>
    {
        Task<PaginationResponsDto<UserFavoriteModel>> GetAllWithPaginationAsync(GetUserFavoriteFilterRequestDto input, CancellationToken cancellationToken);
    }
}
