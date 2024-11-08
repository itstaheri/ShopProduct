using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class auditchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActionDate",
                table: "AuditLogs",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<long>(
                name: "ProductInventoryModelId",
                table: "Tbl_Product",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AuditLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ProductInventories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    InventoryItemId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Color",
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
                    table.PrimaryKey("PK_Tbl_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_InventoryItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    ColorId = table.Column<long>(type: "bigint", nullable: false),
                    InventoryId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    ProductInventoryModelId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_InventoryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_InventoryItem_ProductInventories_ProductInventoryModelId",
                        column: x => x.ProductInventoryModelId,
                        principalTable: "ProductInventories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tbl_InventoryItem_Tbl_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Tbl_Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_InventoryItem_Tbl_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Tbl_Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_InventoryItem_Tbl_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Tbl_Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Product_ProductInventoryModelId",
                table: "Tbl_Product",
                column: "ProductInventoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_InventoryItem_ColorId",
                table: "Tbl_InventoryItem",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_InventoryItem_InventoryId",
                table: "Tbl_InventoryItem",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_InventoryItem_ProductId",
                table: "Tbl_InventoryItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_InventoryItem_ProductInventoryModelId",
                table: "Tbl_InventoryItem",
                column: "ProductInventoryModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Product_ProductInventories_ProductInventoryModelId",
                table: "Tbl_Product",
                column: "ProductInventoryModelId",
                principalTable: "ProductInventories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Product_ProductInventories_ProductInventoryModelId",
                table: "Tbl_Product");

            migrationBuilder.DropTable(
                name: "Tbl_InventoryItem");

            migrationBuilder.DropTable(
                name: "ProductInventories");

            migrationBuilder.DropTable(
                name: "Tbl_Color");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Product_ProductInventoryModelId",
                table: "Tbl_Product");

            migrationBuilder.DropColumn(
                name: "ProductInventoryModelId",
                table: "Tbl_Product");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AuditLogs");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "AuditLogs",
                newName: "ActionDate");
        }
    }
}
