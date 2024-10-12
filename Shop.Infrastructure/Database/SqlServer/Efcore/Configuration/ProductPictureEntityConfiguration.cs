using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using Shop.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    public class ProductPictureEntityConfiguration : IEntityTypeConfiguration<ProductPictureModel>
    {
        public void Configure(EntityTypeBuilder<ProductPictureModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_ProductPicture");
            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductPictures).HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
