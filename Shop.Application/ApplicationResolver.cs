using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application
{
    public static class ApplicationResolver
    {
        public static void ResolveApplication(this IServiceCollection services)
        {
            services.AddTransient<IUserService,UserService>();
            services.AddTransient<IInventoryService, InventoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IPropertyService, PropertyService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IUserCartService, UserCartService>();
        }
    }
}
