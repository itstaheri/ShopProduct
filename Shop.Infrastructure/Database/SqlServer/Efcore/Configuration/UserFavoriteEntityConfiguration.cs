using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Profile;

namespace Shop.Infrastructure.Database.SqlServer.Efcore.Configuration
{
    public class UserFavoriteEntityConfiguration : IEntityTypeConfiguration<UserFavoriteModel>
    {
        public void Configure(EntityTypeBuilder<UserFavoriteModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Tbl_UserFavorite");
            builder.HasOne(x => x.User)
                .WithMany(x => x.UserFavorites).HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Product)
                .WithMany(x => x.UserFavorites).HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
