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
using Shop.Application.Interfaces.Auth;
using Shop.Infrastructure.Interfaces.Auth;
using Shop.Infrastructure.Configs;
using Shop.Application.Interfaces.Dapper;
using ODD.Api.Infrastructure.Utility.Interfaces;
using Shop.Domain.Entities.General;
using Shop.Domain.Repositories.Product;
using Shop.Infrastructure.Repositories.Product;
using Shop.Application.Interfaces.Sms;
using Shop.Infrastructure.Interfaces.Sms;
using Shop.Application.Interfaces.Email;
using Shop.Infrastructure.Interfaces.Email;
using Shop.Domain.Repositories.Profile;
using Shop.Infrastructure.Repositories.Profile;
using Shop.Domain.Repositories.Category;
using Shop.Infrastructure.Repositories.Category;
using Shop.Infrastructure.Repositories.Inventory;
using Shop.Domain.Repositories.Inventory;
using Shop.Infrastructure.Repositories.Property;
using Shop.Infrastructure.Repositories.User;
using Shop.Domain.Repositories.IPropertyRepository;
using Shop.Domain.Repositories.User;
using Shop.Domain.Repositories.Order;
using Shop.Infrastructure.Repositories.Order;
namespace Shop.Infrastructure
{
    public static class InfrastructureResolver
    {
        public static void ResolveInfrastructure(this IServiceCollection services, Dictionary<string, string> keyValues)
        {
            services.ConfigVersioning();

            services.AddTransient<IJwtAuthentication, JwtAuthentication>();
            services.AddScoped<AuditInterceptor>();

            services.AddDbContext<ShopDbContext>((sp,x) =>
            {
                x.UseSqlServer(keyValues["ConnectionString"]);
                x.AddInterceptors(sp.GetRequiredService<AuditInterceptor>());

            }

            , ServiceLifetime.Scoped);
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            #region repositories
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IUserAddressRepository, UserAddressRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryPropertyRepository, CategoryPropertyRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCommentRepository, ProductCommentRepository>();
            services.AddScoped<IProductInventoryRepository, ProductInventoryRepository>();
            services.AddScoped<IProductPictureRepository, ProductPictureRepository>();
            services.AddScoped<IProductPropertyRepository, ProductPropertyRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<IRoleRepository,  RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserCartRepository, UserCartRepository>();
            services.AddScoped<IUserFavoriteRepository, UserFavoriteRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            #endregion
            services.AddScoped<IApplicationEfCoreContext, ShopDbContext>();
            services.AddScoped<IDistributedCacheService, RedisCache>();
            services.AddScoped<IDapperContext, DapperContext>();
            services.AddTransient<OTPAbstraction, OTP>();
            services.AddTransient<IEmail, EmailService>();

            switch (keyValues["SmsProvider"])
            {
                case "Kavenegar": services.AddSingleton<ISMS, KavenegarService>();
                    break;
                default:
                    break;
            }

            services.ConfigAuth(keyValues["Issuer"], keyValues["Audience"], keyValues["Key"]);

            services.AddScoped<IDatabase>(cfg =>
            {
                IConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(keyValues["RedisConnectionStrig"]);
                return multiplexer.GetDatabase();
            });


        }
    }
}
