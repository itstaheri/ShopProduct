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
    public class InventoryItemEntityConfiguration : IEntityTypeConfiguration<InventoryItemModel>
    {
        public void Configure(EntityTypeBuilder<InventoryItemModel> builder)
        {
            builder.ToTable("Tbl_InventoryItem");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Inventory).WithMany(x => x.Items).HasForeignKey(x => x.InventoryId);
            builder.HasOne(x=>x.Color).WithMany(x => x.Items).HasForeignKey(x=>x.ColorId);
            builder.HasOne(x => x.Product).WithMany(x => x.InventoryItems).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);



        }
    }
}
