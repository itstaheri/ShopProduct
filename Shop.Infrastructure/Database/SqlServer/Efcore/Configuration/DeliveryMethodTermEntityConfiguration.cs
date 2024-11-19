using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.DeliverySetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    public class DeliveryMethodTermEntityConfiguration : IEntityTypeConfiguration<DeliveryMethodTermModel>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethodTermModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_DeliveryMethodTerm");
            builder.HasOne(x => x.DeliveryMethod)
                .WithMany(x => x.Terms).HasForeignKey(x => x.DeliveryMethodId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
