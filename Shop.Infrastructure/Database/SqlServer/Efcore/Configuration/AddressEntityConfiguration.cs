using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    internal class AddressEntityConfiguration : IEntityTypeConfiguration<UserAddressModel>
    {
        public void Configure(EntityTypeBuilder<UserAddressModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_Address");
            builder.HasOne(x => x.UserInformation)
                .WithMany(x => x.UserAddresses)
                .HasForeignKey(x => x.UserInformationId);
            builder.HasOne(x=>x.City).WithMany(x=>x.Addresses).HasForeignKey(x=>x.CityId).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(x => x.Orders)
                .WithOne(x => x.UserAddresse).HasForeignKey(x => x.UserAddressId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
