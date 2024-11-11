using Shop.Domain.Entities.Category;
using Shop.Domain.Repositories;
using Shop.Domain.Repositories.Category;
using Shop.Infrastructure.Database.SqlServer.Efcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories.Category
{
    public class CategoryRepository : GenericRepository<CategoryModel>, ICategoryRepository
    {
        public CategoryRepository(ShopDbContext context) : base(context)
        { 
        }
    }
}
