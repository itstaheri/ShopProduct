using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Discount;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    public class DiscountEntityConfiguration : IEntityTypeConfiguration<DiscountModel>
    {
        public void Configure(EntityTypeBuilder<DiscountModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_Discount");
        }
    }
}
