using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderModel>
    {
        public void Configure(EntityTypeBuilder<OrderModel> builder)
        { 
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_Order");
            builder.HasOne(x => x.User)
                .WithMany(x => x.Orders).HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.UserAddresse)
                .WithMany(x => x.Orders).HasForeignKey(x => x.UserAddressId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.DeliveryMethod)
                .WithMany(x => x.Orders).HasForeignKey(x => x.DeliveryMethodId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.DeliveryMethodTerm)
                .WithMany(x => x.Orders).HasForeignKey(x =>x.DeliveryMethodTermId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Discount)
                .WithMany(x => x.Orders).HasForeignKey(x => x.DiscountId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.OrderIthems)
                .WithOne(x => x.Order).HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
