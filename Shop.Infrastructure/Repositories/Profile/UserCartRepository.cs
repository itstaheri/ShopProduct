using Microsoft.EntityFrameworkCore;
using Shop.Domain.Dtos;
using Shop.Domain.Entities.Profile;
using Shop.Domain.Repositories.Profile;
using Shop.Infrastructure.Database.SqlServer.Efcore;
using Shop.Domain.Dtos.Profile;

namespace Shop.Infrastructure.Repositories.Profile
{
    public class UserCartRepository : GenericRepository<UserCartModel>, IUserCartRepository
    {
        public UserCartRepository(ShopDbContext context) : base(context)
        {
        }
        public async Task<PaginationResponsDto<UserCartModel>> GetAllWithPaginationAsync(GetUserCartFilterRequestDto input, CancellationToken cancellationToken)
        {
            try
            {
                var userCarts = _dbSet.AsNoTracking()
                    .OrderByDescending(x => x.Id)
                    .AsQueryable();

                userCarts = userCarts.Where(x => x.UserId == input.UserId);
                //var userCart = await _userCartRepository.GetAsync(x => x.UserId == userId, cancellationToken, true, x => x.Product);
                //var product = GeneralMapper.Map<ProductModel, ProductDto>(userCart.Product);
                //var userCartDto = GeneralMapper.Map<UserCartModel, UserCartDto>(userCart);
                //userCartDto.Product = product;
                long count = await _dbSet.CountAsync();

                userCarts = userCarts.Skip(input.Page * input.PageSize).Take(input.PageSize);


                return new PaginationResponsDto<UserCartModel>
                {
                    List = await userCarts.ToListAsync(cancellationToken),
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
