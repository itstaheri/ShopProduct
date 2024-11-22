using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_DeliveryMethod",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryId = table.Column<long>(type: "bigint", nullable: false),
                    SendingCapasity = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_DeliveryMethod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_DeliveryMethod_Tbl_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Tbl_Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Discount",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPrice = table.Column<long>(type: "bigint", nullable: false),
                    MinPrice = table.Column<long>(type: "bigint", nullable: false),
                    MaxPrice = table.Column<long>(type: "bigint", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Discount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserCart",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ColorId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_UserCart_Tbl_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Tbl_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_UserCart_Tbl_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserFavorite",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserFavorite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_UserFavorite_Tbl_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Tbl_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_UserFavorite_Tbl_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_DeliveryMethodTerm",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryMethodId = table.Column<long>(type: "bigint", nullable: false),
                    Weekdays = table.Column<int>(type: "int", nullable: false),
                    FromTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    ToTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    SendingCapasity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_DeliveryMethodTerm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_DeliveryMethodTerm_Tbl_DeliveryMethod_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "Tbl_DeliveryMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Order",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    UserAddressId = table.Column<long>(type: "bigint", nullable: false),
                    TrckingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryMethodId = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryMethodTermId = table.Column<long>(type: "bigint", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Order_Tbl_Address_UserAddressId",
                        column: x => x.UserAddressId,
                        principalTable: "Tbl_Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tbl_Order_Tbl_DeliveryMethodTerm_DeliveryMethodTermId",
                        column: x => x.DeliveryMethodTermId,
                        principalTable: "Tbl_DeliveryMethodTerm",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tbl_Order_Tbl_DeliveryMethod_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "Tbl_DeliveryMethod",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tbl_Order_Tbl_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Tbl_Discount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tbl_Order_Tbl_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Tbl_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_OrderIthem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ColorId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DiscountPrice = table.Column<long>(type: "bigint", nullable: false),
                    TotalPrice = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_OrderIthem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_OrderIthem_Tbl_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Tbl_Color",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tbl_OrderIthem_Tbl_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Tbl_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_OrderIthem_Tbl_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Tbl_Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_DeliveryMethod_InventoryId",
                table: "Tbl_DeliveryMethod",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_DeliveryMethodTerm_DeliveryMethodId",
                table: "Tbl_DeliveryMethodTerm",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Order_DeliveryMethodId",
                table: "Tbl_Order",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Order_DeliveryMethodTermId",
                table: "Tbl_Order",
                column: "DeliveryMethodTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Order_DiscountId",
                table: "Tbl_Order",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Order_UserAddressId",
                table: "Tbl_Order",
                column: "UserAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Order_UserId",
                table: "Tbl_Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_OrderIthem_ColorId",
                table: "Tbl_OrderIthem",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_OrderIthem_OrderId",
                table: "Tbl_OrderIthem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_OrderIthem_ProductId",
                table: "Tbl_OrderIthem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserCart_ProductId",
                table: "Tbl_UserCart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserCart_UserId",
                table: "Tbl_UserCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserFavorite_ProductId",
                table: "Tbl_UserFavorite",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserFavorite_UserId",
                table: "Tbl_UserFavorite",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_OrderIthem");

            migrationBuilder.DropTable(
                name: "Tbl_UserCart");

            migrationBuilder.DropTable(
                name: "Tbl_UserFavorite");

            migrationBuilder.DropTable(
                name: "Tbl_Order");

            migrationBuilder.DropTable(
                name: "Tbl_DeliveryMethodTerm");

            migrationBuilder.DropTable(
                name: "Tbl_Discount");

            migrationBuilder.DropTable(
                name: "Tbl_DeliveryMethod");
        }
    }
}
