using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Shop.Domain.Entities.Property;
using Shop.Domain.Repositories.IPropertyRepository;
using Shop.Infrastructure.Database.SqlServer.Efcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories.Property
{
    public class PropertyRepository : GenericRepository<Domain.Entities.Property.PropertyModel>, IPropertyRepository
    {
        public PropertyRepository(ShopDbContext context) : base(context)
        {

        }
    }
}
