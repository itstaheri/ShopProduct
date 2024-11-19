using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    public class UserCartEntityConfiguration : IEntityTypeConfiguration<UserCartModel>
    {
        public void Configure(EntityTypeBuilder<UserCartModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_UserCart");
            builder.HasOne(x => x.User)
                .WithMany(x => x.UserCarts).HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Product)
                .WithMany(x => x.UserCarts).HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
