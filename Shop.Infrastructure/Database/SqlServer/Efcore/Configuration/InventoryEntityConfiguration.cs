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
    public class InventoryEntityConfiguration : IEntityTypeConfiguration<InventoryModel>
    {
        public void Configure(EntityTypeBuilder<InventoryModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_Inventory");
            builder.HasOne(x => x.Province)
                .WithMany(x => x.Inventories).HasForeignKey(x => x.ProvinceId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x => x.City)
                .WithMany(x => x.Inventories).HasForeignKey(x =>x.CityId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
