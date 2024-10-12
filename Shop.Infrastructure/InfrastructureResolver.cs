using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Database.SqlServer.Efcore;
using Shop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure
{
    public static class InfrastructureResolver
    {
        public static void ResolveInfrastructure(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<ShopDbContext>(x=>x.UseSqlServer(connectionString),ServiceLifetime.Scoped);
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
