using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.DeliverySetting;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    public class DeliveryMethodEntityConfiguration : IEntityTypeConfiguration<DeliveryMethodModel>
      {
        public void Configure(EntityTypeBuilder<DeliveryMethodModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_DeliveryMethod");
            builder.HasOne(x => x.Inventory)
                .WithMany(x => x.DeliveryMethods).HasForeignKey(x => x.InventoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Terms)
                .WithOne(x => x.DeliveryMethod).HasForeignKey(x => x.DeliveryMethodId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Orders)
                .WithOne(x => x.DeliveryMethod).HasForeignKey(x => x.DeliveryMethodId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
