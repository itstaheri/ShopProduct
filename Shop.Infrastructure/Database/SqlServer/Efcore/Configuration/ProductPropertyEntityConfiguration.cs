using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    public class ProductPropertyEntityConfiguration : IEntityTypeConfiguration<ProductPropertyModel>
    {
        public void Configure(EntityTypeBuilder<ProductPropertyModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_ProductProperty");
            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductProperties).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Property)
                .WithMany(x => x.ProductProperties).HasForeignKey(x => x.PropertyId);

        }
    }
}
