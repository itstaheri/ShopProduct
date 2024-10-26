using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryModel>
    {
        public void Configure(EntityTypeBuilder<CategoryModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_Category");
            builder.HasMany(x => x.CategoryProperties)
                .WithOne(x => x.Category).HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(x => x.Products)
                .WithOne(x => x.Category).HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
        .HasOne(c => c)
        .WithMany(c => c.SubCategories)
        .HasForeignKey(c => c.CategoryParentId)
        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
