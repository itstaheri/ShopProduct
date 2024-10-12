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
    internal class UserInformationEntityConfiguration : IEntityTypeConfiguration<UserInformationModel>
    {
        public void Configure(EntityTypeBuilder<UserInformationModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_UserInformation");
            builder.HasOne(x => x.User).WithOne(x => x.UserInformation)
                .HasForeignKey<UserInformationModel>(x => x.UserId);
            builder.HasMany(x => x.UserAddresses)
                .WithOne(x => x.UserInformation)
                .HasForeignKey(x => x.UserInformationId);
        }
    }
}
