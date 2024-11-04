using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shop.Domain.Entities.Product;
using Shop.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_Product");
           

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products).HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ProductComments)
                .WithOne(x => x.Product).HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ProductProperties)
                .WithOne(x => x.Product).HasForeignKey(x => x.PropertyId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.ProductPictures)
                .WithOne(x => x.Product).HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.InventoryItems).WithOne(x => x.Product).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);
                
        }
    }
}
