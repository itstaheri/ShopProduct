using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Order;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    public class OrderIthemEntityConfiguration : IEntityTypeConfiguration<OrderIthemModel>
    {
        public void Configure(EntityTypeBuilder<OrderIthemModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_OrderIthem");
            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderIthems).HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Product)
                .WithMany(x => x.OrderIthems).HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Color)
                .WithMany(x => x.OrderIthems).HasForeignKey(x => x.ColorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
