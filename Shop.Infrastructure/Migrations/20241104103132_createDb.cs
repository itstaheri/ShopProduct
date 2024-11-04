using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RecordId = table.Column<long>(type: "bigint", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryParentId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Category_Tbl_Category_CategoryParentId",
                        column: x => x.CategoryParentId,
                        principalTable: "Tbl_Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Permission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Property",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasurmentUnit = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Property", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Province",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Role",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExteraDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Product_Tbl_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Tbl_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CategoryProperty",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    PropertyId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CategoryProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_CategoryProperty_Tbl_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Tbl_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_CategoryProperty_Tbl_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Tbl_Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_City",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_City_Tbl_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Tbl_Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_RolePermission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_RolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_RolePermission_Tbl_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Tbl_Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_RolePermission_Tbl_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Tbl_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductPicture",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ProductCommentId = table.Column<long>(type: "bigint", nullable: true),
                    FilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ProductPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ProductPicture_Tbl_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Tbl_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductProperty",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    PropertyId = table.Column<long>(type: "bigint", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ProductProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ProductProperty_Tbl_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Tbl_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tbl_ProductProperty_Tbl_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Tbl_Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Inventory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceModelId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Inventory_Tbl_City_CityId",
                        column: x => x.CityId,
                        principalTable: "Tbl_City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tbl_Inventory_Tbl_Province_ProvinceModelId",
                        column: x => x.ProvinceModelId,
                        principalTable: "Tbl_Province",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductComment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCommentParentId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    UserFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<short>(type: "smallint", nullable: false),
                    ApprovingUserId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsQuestion = table.Column<bool>(type: "bit", nullable: false),
                    ProductPictureModelId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ProductComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ProductComment_Tbl_ProductPicture_ProductPictureModelId",
                        column: x => x.ProductPictureModelId,
                        principalTable: "Tbl_ProductPicture",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tbl_ProductComment_Tbl_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Tbl_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCommentModelId = table.Column<long>(type: "bigint", nullable: true),
                    ProductCommentModelId1 = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_User_Tbl_ProductComment_ProductCommentModelId",
                        column: x => x.ProductCommentModelId,
                        principalTable: "Tbl_ProductComment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tbl_User_Tbl_ProductComment_ProductCommentModelId1",
                        column: x => x.ProductCommentModelId1,
                        principalTable: "Tbl_ProductComment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserInformation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    IsMarried = table.Column<bool>(type: "bit", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_UserInformation_Tbl_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_UserRole_Tbl_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Tbl_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_UserRole_Tbl_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Tbl_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Address",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserInformationId = table.Column<long>(type: "bigint", nullable: false),
                    ProvinceId1 = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Address_Tbl_Province_ProvinceId1",
                        column: x => x.ProvinceId1,
                        principalTable: "Tbl_Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Address_Tbl_UserInformation_UserInformationId",
                        column: x => x.UserInformationId,
                        principalTable: "Tbl_UserInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Address_ProvinceId1",
                table: "Tbl_Address",
                column: "ProvinceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Address_UserInformationId",
                table: "Tbl_Address",
                column: "UserInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Category_CategoryParentId",
                table: "Tbl_Category",
                column: "CategoryParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CategoryProperty_CategoryId",
                table: "Tbl_CategoryProperty",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CategoryProperty_PropertyId",
                table: "Tbl_CategoryProperty",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_City_ProvinceId",
                table: "Tbl_City",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Inventory_CityId",
                table: "Tbl_Inventory",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Inventory_ProvinceModelId",
                table: "Tbl_Inventory",
                column: "ProvinceModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Product_CategoryId",
                table: "Tbl_Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductComment_ProductId",
                table: "Tbl_ProductComment",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductComment_ProductPictureModelId",
                table: "Tbl_ProductComment",
                column: "ProductPictureModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductPicture_ProductId",
                table: "Tbl_ProductPicture",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductProperty_ProductId",
                table: "Tbl_ProductProperty",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ProductProperty_PropertyId",
                table: "Tbl_ProductProperty",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_RolePermission_PermissionId",
                table: "Tbl_RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_RolePermission_RoleId",
                table: "Tbl_RolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_User_ProductCommentModelId",
                table: "Tbl_User",
                column: "ProductCommentModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_User_ProductCommentModelId1",
                table: "Tbl_User",
                column: "ProductCommentModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserInformation_UserId",
                table: "Tbl_UserInformation",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserRole_RoleId",
                table: "Tbl_UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserRole_UserId",
                table: "Tbl_UserRole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Tbl_Address");

            migrationBuilder.DropTable(
                name: "Tbl_CategoryProperty");

            migrationBuilder.DropTable(
                name: "Tbl_Inventory");

            migrationBuilder.DropTable(
                name: "Tbl_ProductProperty");

            migrationBuilder.DropTable(
                name: "Tbl_RolePermission");

            migrationBuilder.DropTable(
                name: "Tbl_UserRole");

            migrationBuilder.DropTable(
                name: "Tbl_UserInformation");

            migrationBuilder.DropTable(
                name: "Tbl_City");

            migrationBuilder.DropTable(
                name: "Tbl_Property");

            migrationBuilder.DropTable(
                name: "Tbl_Permission");

            migrationBuilder.DropTable(
                name: "Tbl_Role");

            migrationBuilder.DropTable(
                name: "Tbl_User");

            migrationBuilder.DropTable(
                name: "Tbl_Province");

            migrationBuilder.DropTable(
                name: "Tbl_ProductComment");

            migrationBuilder.DropTable(
                name: "Tbl_ProductPicture");

            migrationBuilder.DropTable(
                name: "Tbl_Product");

            migrationBuilder.DropTable(
                name: "Tbl_Category");
        }
    }
}
