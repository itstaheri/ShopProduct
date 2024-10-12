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
    public class ProductCommentEntityConfiguration : IEntityTypeConfiguration<ProductCommentModel>
    {
        public void Configure(EntityTypeBuilder<ProductCommentModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_ProductComment");
            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductComments).HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
