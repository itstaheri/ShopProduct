using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Shop.Domain.Entities.BaseData;
using Shop.Domain.Entities.Profile;
using Shop.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces.Database
{
    public interface IApplicationEfCoreContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserInformationModel> UsersInformations { get; set; }
        public DbSet<UserRoleModel> UserRoles { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<PermissionModel> Permissions { get; set; }
        public DbSet<RolePermissionModel> RolePermissions { get; set; }
        public DbSet<CityModel> Cities { get; set; }
        public DbSet<ProvinceModel> Provinces { get; set; }
        public DbSet<UserAddressModel> UserAddresses { get; set; }

       public DatabaseFacade Database { get; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        public int SaveChanges();
    }
}
