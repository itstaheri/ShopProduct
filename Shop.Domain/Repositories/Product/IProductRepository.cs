using Shop.Domain.Dtos;
using Shop.Domain.Dtos.Product;
using Shop.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories.Product
{
    public interface IProductRepository : IGenericRepository<ProductModel>
    {
        Task<ProductModel> GetProductAsync(long Id, CancellationToken cancellationToken);
        Task<PaginationResponsDto<ProductModel>> GetAllWithPaginationAsync(GetAllProductFilterRequestDto input, CancellationToken cancellationToken);
    }
}
