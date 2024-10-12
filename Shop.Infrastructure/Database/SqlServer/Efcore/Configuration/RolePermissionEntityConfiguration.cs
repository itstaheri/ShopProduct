using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    internal class RolePermissionEntityConfiguration : IEntityTypeConfiguration<RolePermissionModel>
    {
        public void Configure(EntityTypeBuilder<RolePermissionModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_RolePermission");
            builder.HasOne(x => x.Role)
                .WithMany(x => x.RolePermissions)
                .HasForeignKey(x => x.RoleId);
            builder.HasOne(x => x.Permission)
                .WithMany(x => x.RolePermissions)
                .HasForeignKey(x => x.PermissionId);

        }
    }
}
