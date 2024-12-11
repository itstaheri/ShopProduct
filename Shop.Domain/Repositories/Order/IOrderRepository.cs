using Shop.Domain.Dtos.Profile;
using Shop.Domain.Dtos;
using Shop.Domain.Entities.Order;
using Shop.Domain.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.Dtos.Order;

namespace Shop.Domain.Repositories.Order
{
    public interface IOrderRepository : IGenericRepository<OrderModel>
    {
        Task<PaginationResponsDto<OrderModel>> GetAllWithPaginationAsync(GetAllOrderFilterRequestDto input, CancellationToken cancellationToken);
    }
}
