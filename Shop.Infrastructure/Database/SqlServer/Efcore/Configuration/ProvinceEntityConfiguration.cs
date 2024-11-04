using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    internal class ProvinceEntityConfiguration : IEntityTypeConfiguration<ProvinceModel>
    {
        public void Configure(EntityTypeBuilder<ProvinceModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_Province");
            builder.HasMany(x => x.Cities)
                .WithOne(x => x.Province)
                .HasForeignKey(x => x.ProvinceId);
           
        }
    }
}
