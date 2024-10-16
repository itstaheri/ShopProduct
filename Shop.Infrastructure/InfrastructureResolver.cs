using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Interfaces.Database;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Database.SqlServer.Efcore;
using Shop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using Shop.Application.Interfaces.Cache;
using Shop.Infrastructure.Interfaces.Cache;
using Shop.Application.Interfaces.OTP;
using Shop.Infrastructure.Interfaces.OTP;
namespace Shop.Infrastructure
{
    public static class InfrastructureResolver
    {
        public static void ResolveInfrastructure(this IServiceCollection services,string connectionString,string redisConnectionStrig)
        {
            services.AddDbContext<ShopDbContext>(x=>x.UseSqlServer(connectionString),ServiceLifetime.Scoped);
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IApplicationEfCoreContext, ShopDbContext>();
            services.AddScoped<IDistributedCacheService, RedisCache>();
            services.AddTransient<OTPAbstraction, OTP>();

            services.AddScoped<IDatabase>(cfg =>
            {
                IConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(redisConnectionStrig);
                return multiplexer.GetDatabase();
            });
           

        }
    }
}
