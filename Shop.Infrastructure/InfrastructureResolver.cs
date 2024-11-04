﻿using Microsoft.EntityFrameworkCore;
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
using Shop.Application.Interfaces.Auth;
using Shop.Infrastructure.Interfaces.Auth;
using Shop.Infrastructure.Configs;
using Shop.Application.Interfaces.Dapper;
using ODD.Api.Infrastructure.Utility.Interfaces;
using Shop.Domain.Entities.General;
using Shop.Domain.Repositories.Product;
using Shop.Infrastructure.Repositories.Product;
namespace Shop.Infrastructure
{
    public static class InfrastructureResolver
    {
        public static void ResolveInfrastructure(this IServiceCollection services, Dictionary<string, string> keyValues)
        {
            var serviceProvider = services.BuildServiceProvider();
            services.AddTransient<IJwtAuthentication, JwtAuthentication>();

            services.AddDbContext<ShopDbContext>(x =>
            {
                x.UseSqlServer(keyValues["ConnectionString"]);
                x.AddInterceptors(serviceProvider.CreateScope().ServiceProvider.GetService<AuditInterceptor>());

            }

            , ServiceLifetime.Scoped);
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IApplicationEfCoreContext, ShopDbContext>();
            services.AddScoped<IDistributedCacheService, RedisCache>();
            services.AddScoped<IDapperContext, DapperContext>();
            services.AddTransient<OTPAbstraction, OTP>();
            services.ConfigVersioning();
            services.ConfigAuth(keyValues["Issuer"], keyValues["Audience"], keyValues["Key"]);

            services.AddScoped<IDatabase>(cfg =>
            {
                IConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(keyValues["RedisConnectionStrig"]);
                return multiplexer.GetDatabase();
            });


        }
    }
}
