using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    public class CategoryPropertyEntityConfiguration : IEntityTypeConfiguration<CategoryPropertyModel>
    {
        public void Configure(EntityTypeBuilder<CategoryPropertyModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_CategoryProperty");
            builder.HasOne(x => x.Category)
                .WithMany(x => x.CategoryProperties).HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Property)
                .WithMany(x => x.CategoryProperties).HasForeignKey(x => x.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
