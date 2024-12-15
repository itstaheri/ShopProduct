using Microsoft.EntityFrameworkCore;
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
        private ShopDbContext _context;
        public CategoryRepository(ShopDbContext context) : base(context)
        { 
            _context = context;
        }

        public async Task<List<CategoryModel>> GetMainCategoryListAsync(CancellationToken cancellationToken)
        {
            var categories =   _context.Categories.AsNoTracking().Where(x=>x.IsActive && x.CategoryParentId == null).Take(6).AsQueryable();
            return await categories.ToListAsync(cancellationToken);
        }
    }
}
