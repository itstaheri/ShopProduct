using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Product;
using Shop.Domain.Entities.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    public class PropertyEntityConfiguration : IEntityTypeConfiguration<PropertyModel>
    {
        public void Configure(EntityTypeBuilder<PropertyModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_Property");
            builder.HasMany(x => x.CategoryProperties)
                .WithOne(x => x.Property).HasForeignKey(x => x.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.ProductProperties)
                .WithOne(x => x.Property).HasForeignKey(x => x.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
