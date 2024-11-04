using Microsoft.EntityFrameworkCore;
using Shop.Domain.Dtos;
using Shop.Domain.Dtos.Product;
using Shop.Domain.Entities.Product;
using Shop.Domain.Repositories;
using Shop.Domain.Repositories.Product;
using Shop.Infrastructure.Database.SqlServer.Efcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories.Product
{
    public class ProductRepository : GenericRepository<ProductModel>, IProductRepository
    {
        public ProductRepository(ShopDbContext context) : base(context)
        {
        }

        public async Task<PaginationResponsDto<ProductModel>> GetAllWithPaginationAsync(GetAllProductFilterRequestDto input,CancellationToken cancellationToken)
        {
            try
            {
                var products =  _dbSet.AsNoTracking()
                   
                    .OrderByDescending(x=>x.Id)
                    .AsQueryable();

                if (input.FromDate != null && input.ToDate != null)
                    products = products.Where(x => x.CreatedAt < input.FromDate && x.CreatedAt > input.ToDate);

                if (!string.IsNullOrEmpty(input.Name)) 
                    products = products.Where(x=>x.Name.Contains(input.Name));
                if(input.CategoryId != 0)
                    products = products.Where(x=>x.CategoryId == input.CategoryId);

                long count  =  await _dbSet.CountAsync();

                products = products.Skip(input.Page*input.PageSize).Take(input.PageSize);


                return new PaginationResponsDto<ProductModel>
                {
                    List = await products.ToListAsync(cancellationToken),
                    TotalCount = count
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ProductModel> GetProductAsync(long Id,CancellationToken cancellationToken)
        {
            try
            {
                var product =await _dbSet.AsNoTracking().Include(x => x.InventoryItems).ThenInclude(x=>x.Color).AsSplitQuery().FirstOrDefaultAsync(x => x.Id == Id);
                return product;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
