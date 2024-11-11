using Shop.Domain.Entities.Product;
using Shop.Domain.Repositories.Product;
using Shop.Infrastructure.Database.SqlServer.Efcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories.Product
{
    public class ProductCommentRepository : GenericRepository<ProductCommentModel>, IProductCommentRepository
    {
        public ProductCommentRepository(ShopDbContext context) : base(context)
        {
        }
    }
}
