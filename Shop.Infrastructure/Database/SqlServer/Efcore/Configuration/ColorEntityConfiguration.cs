using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    public class ColorEntityConfiguration : IEntityTypeConfiguration<ColorModel>
    {
        public void Configure(EntityTypeBuilder<ColorModel> builder)
        {
            builder.ToTable("Tbl_Color");
            builder.HasMany(x=>x.Items).WithOne(x=>x.Color).HasForeignKey(x=>x.ColorId);
            builder.HasMany(x => x.OrderIthems)
                .WithOne(x => x.Color).HasForeignKey(x => x.ColorId);
        }
    }
}
 