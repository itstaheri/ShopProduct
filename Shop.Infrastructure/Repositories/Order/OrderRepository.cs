using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.Order;
using Shop.Domain.Dtos.Profile;
using Shop.Domain.Entities.Order;
using Shop.Domain.Entities.Profile;
using Shop.Domain.Repositories.Order;
using Shop.Infrastructure.Database.SqlServer.Efcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories.Order
{
    public class OrderRepository : GenericRepository<OrderModel>, IOrderRepository
    {
        public OrderRepository(ShopDbContext context) : base(context) 
        { 
        }

        public async Task<PaginationResponsDto<OrderModel>> GetAllWithPaginationAsync(GetAllOrderFilterRequestDto input, CancellationToken cancellationToken)
        {
            try
            {
                var orders = _dbSet.AsNoTracking()
                    .OrderByDescending(x => x.Id)
                    .AsQueryable();

                orders = orders.Where(x => x.UserId == input.UserId);
                long count = await _dbSet.CountAsync();
                orders = orders.Skip(input.Page * input.PageSize).Take(input.PageSize);

                return new PaginationResponsDto<OrderModel>
                {
                    List = await orders.ToListAsync(cancellationToken),
                    TotalCount = count
                };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
