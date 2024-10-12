using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Repositories;
using Shop.Application.Services;
using Shop.Domain.Repositories.User;
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
            services.AddSingleton<IUserRepository,UserRepository>();
            services.AddTransient<IUserService,UserService>();

        }
    }
}
