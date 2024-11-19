using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Shop.Application.Interfaces.Database;
using Shop.Domain.Entities.BaseData;
using Shop.Domain.Entities.Category;
using Shop.Domain.Entities.DeliverySetting;
using Shop.Domain.Entities.Discount;
using Shop.Domain.Entities.General;
using Shop.Domain.Entities.Inventory;
using Shop.Domain.Entities.Order;
using Shop.Domain.Entities.Product;
using Shop.Domain.Entities.Profile;
using Shop.Domain.Entities.Property;
using Shop.Domain.Entities.User;
using Shop.Infrastructure.Database.SqlServer.Efcore.Configuration;

namespace Shop.Infrastructure.Database.SqlServer.Efcore
{
    public class ShopDbContext : DbContext, IApplicationEfCoreContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
                
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserInformationModel> UsersInformations { get; set; }
        public DbSet<UserRoleModel> UserRoles { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<PermissionModel> Permissions { get; set; }
        public DbSet<RolePermissionModel> RolePermissions { get; set; }
        public DbSet<CityModel> Cities { get; set; }
        public DbSet<ProvinceModel> Provinces { get; set; }
        public DbSet<UserAddressModel> UserAddresses { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<PropertyModel> Properties { get; set; }
        public DbSet<CategoryPropertyModel> CategoriesProperty { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ProductPropertyModel> ProductProperties { get; set; }
        public DbSet<ProductCommentModel> ProductComments { get; set; }
        public DbSet<ProductPictureModel> ProductPictures { get; set; }
        public DbSet<InventoryModel> Inventory { get; set; }
        public DbSet<AuditLogModel> AuditLogs { get; set; }
        public DbSet<InventoryItemModel> InventoryItems { get; set; }
        public DbSet<ColorModel> Colors { get; set; }
        public DbSet<ProductInventoryModel> ProductInventories { get; set; }
        public DbSet<UserCartModel> UserCart {  get; set; }
        public DbSet<OrderModel> OrderModel { get; set; }
        public DbSet<OrderIthemModel> OrderIthem {  get; set; }
        public DbSet<DeliveryMethodModel> DeliveryMethod { get; set; }
        public DbSet<DeliveryMethodTermModel> DeliveryMethodTerm { get; set; }
        public DbSet<DiscountModel> Discount { get; set; }
        public DbSet<UserFavoriteModel> UserFavorite { get; set; }


        public override DatabaseFacade Database => base.Database;

        

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserInformationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AddressEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CityEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProvinceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryPropertyEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCommentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductPictureEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductPropertyEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ColorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryItemEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AuditLogEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserCartEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderIthemEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryMethodEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryMethodTermEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserFavoriteEntityConfiguration());
        }

    }
}
