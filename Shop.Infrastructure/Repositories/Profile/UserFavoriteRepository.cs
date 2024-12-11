using Microsoft.EntityFrameworkCore;
using Shop.Domain.Dtos.Profile;
using Shop.Domain.Dtos;
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
    public class UserFavoriteRepository : GenericRepository<UserFavoriteModel>, IUserFavoriteRepository
    {
        public UserFavoriteRepository(ShopDbContext context) : base(context)
        {
        }
        public async Task<PaginationResponsDto<UserFavoriteModel>> GetAllWithPaginationAsync(GetUserFavoriteFilterRequestDto input, CancellationToken cancellationToken)
        {
            try
            {
                var userFavorites = _dbSet.AsNoTracking()
                    .OrderByDescending(x => x.Id)
                    .AsQueryable();

                userFavorites = userFavorites.Where(x => x.UserId == input.UserId);
                //var userFavorite = await _userFavoriteRepository.GetAsync(x => x.UserId == userId, cancellationToken, true, x => x.Product);
                //var product = GeneralMapper.Map<ProductModel, ProductDto>(userFavorite.Product);
                //var userFavoriteDto = GeneralMapper.Map<UserFavoriteModel, UserFavoriteDto>(userFavorite);
                //userFavoriteDto.Product = product;
                long count = await _dbSet.CountAsync(); 

                userFavorites = userFavorites.Skip(input.Page * input.PageSize).Take(input.PageSize);


                return new PaginationResponsDto<UserFavoriteModel>
                {
                    List = await userFavorites.ToListAsync(cancellationToken),
                    TotalCount = count
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
