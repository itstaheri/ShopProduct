﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Infrastructure.Database.SqlServer.Efcore;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shop.Domain.Entities.BaseData.CityModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProvinceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Tbl_City", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.BaseData.ProvinceModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Province", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Category.CategoryModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("CategoryParentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryParentId");

                    b.ToTable("Tbl_Category", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Category.CategoryPropertyModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long>("PropertyId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PropertyId");

                    b.ToTable("Tbl_CategoryProperty", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.General.AuditLogModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("ActionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Operation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RecordId")
                        .HasColumnType("bigint");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Inventory.InventoryModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CityId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ProvinceModelId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ProvinceModelId");

                    b.ToTable("Tbl_Inventory", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Product.ProductCommentModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("ApprovingUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsQuestion")
                        .HasColumnType("bit");

                    b.Property<long?>("ProductCommentParentId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProductPictureModelId")
                        .HasColumnType("bigint");

                    b.Property<short>("Score")
                        .HasColumnType("smallint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductPictureModelId");

                    b.ToTable("Tbl_ProductComment", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Product.ProductModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExteraDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MainPicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Tbl_Product", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Product.ProductPictureModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilePicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long?>("ProductCommentId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Tbl_ProductPicture", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Product.ProductPropertyModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PropertyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("PropertyId");

                    b.ToTable("Tbl_ProductProperty", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Profile.UserAddressModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<long>("ProvinceId1")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserInformationId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId1");

                    b.HasIndex("UserInformationId");

                    b.ToTable("Tbl_Address", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Profile.UserInformationModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsMarried")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Tbl_UserInformation", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Property.PropertyModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MeasurmentUnit")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Property", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.User.PermissionModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Permission", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.User.RoleModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Role", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.User.RolePermissionModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long>("PermissionId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("Tbl_RolePermission", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.User.UserModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ProductCommentModelId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProductCommentModelId1")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductCommentModelId");

                    b.HasIndex("ProductCommentModelId1");

                    b.ToTable("Tbl_User", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.User.UserRoleModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("Tbl_UserRole", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.BaseData.CityModel", b =>
                {
                    b.HasOne("Shop.Domain.Entities.BaseData.ProvinceModel", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Category.CategoryModel", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Category.CategoryModel", "CategoryParent")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryParentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CategoryParent");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Category.CategoryPropertyModel", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Category.CategoryModel", "Category")
                        .WithMany("CategoryProperties")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Domain.Entities.Property.PropertyModel", "Property")
                        .WithMany("CategoryProperties")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Inventory.InventoryModel", b =>
                {
                    b.HasOne("Shop.Domain.Entities.BaseData.CityModel", "City")
                        .WithMany("Inventories")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Shop.Domain.Entities.BaseData.ProvinceModel", null)
                        .WithMany("Inventories")
                        .HasForeignKey("ProvinceModelId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Product.ProductCommentModel", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Product.ProductModel", "Product")
                        .WithMany("ProductComments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Domain.Entities.Product.ProductPictureModel", null)
                        .WithMany("ProductComments")
                        .HasForeignKey("ProductPictureModelId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Product.ProductModel", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Category.CategoryModel", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Product.ProductPictureModel", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Product.ProductModel", "Product")
                        .WithMany("ProductPictures")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Product.ProductPropertyModel", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Product.ProductModel", "Product")
                        .WithMany("ProductProperties")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Shop.Domain.Entities.Property.PropertyModel", "Property")
                        .WithMany("ProductProperties")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Product");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Profile.UserAddressModel", b =>
                {
                    b.HasOne("Shop.Domain.Entities.BaseData.ProvinceModel", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Domain.Entities.Profile.UserInformationModel", "UserInformation")
                        .WithMany("UserAddresses")
                        .HasForeignKey("UserInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");

                    b.Navigation("UserInformation");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Profile.UserInformationModel", b =>
                {
                    b.HasOne("Shop.Domain.Entities.User.UserModel", "User")
                        .WithOne("UserInformation")
                        .HasForeignKey("Shop.Domain.Entities.Profile.UserInformationModel", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shop.Domain.Entities.User.RolePermissionModel", b =>
                {
                    b.HasOne("Shop.Domain.Entities.User.PermissionModel", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Domain.Entities.User.RoleModel", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Shop.Domain.Entities.User.UserModel", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Product.ProductCommentModel", null)
                        .WithMany("ApprovingUsers")
                        .HasForeignKey("ProductCommentModelId");

                    b.HasOne("Shop.Domain.Entities.Product.ProductCommentModel", null)
                        .WithMany("Users")
                        .HasForeignKey("ProductCommentModelId1");
                });

            modelBuilder.Entity("Shop.Domain.Entities.User.UserRoleModel", b =>
                {
                    b.HasOne("Shop.Domain.Entities.User.RoleModel", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Domain.Entities.User.UserModel", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shop.Domain.Entities.BaseData.CityModel", b =>
                {
                    b.Navigation("Inventories");
                });

            modelBuilder.Entity("Shop.Domain.Entities.BaseData.ProvinceModel", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Inventories");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Category.CategoryModel", b =>
                {
                    b.Navigation("CategoryProperties");

                    b.Navigation("Products");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Product.ProductCommentModel", b =>
                {
                    b.Navigation("ApprovingUsers");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Product.ProductModel", b =>
                {
                    b.Navigation("ProductComments");

                    b.Navigation("ProductPictures");

                    b.Navigation("ProductProperties");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Product.ProductPictureModel", b =>
                {
                    b.Navigation("ProductComments");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Profile.UserInformationModel", b =>
                {
                    b.Navigation("UserAddresses");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Property.PropertyModel", b =>
                {
                    b.Navigation("CategoryProperties");

                    b.Navigation("ProductProperties");
                });

            modelBuilder.Entity("Shop.Domain.Entities.User.PermissionModel", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("Shop.Domain.Entities.User.RoleModel", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Shop.Domain.Entities.User.UserModel", b =>
                {
                    b.Navigation("UserInformation")
                        .IsRequired();

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
