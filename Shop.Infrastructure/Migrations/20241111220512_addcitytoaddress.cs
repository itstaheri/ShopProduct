using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcitytoaddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Address_Tbl_Province_ProvinceId1",
                table: "Tbl_Address");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Address_ProvinceId1",
                table: "Tbl_Address");

            migrationBuilder.DropColumn(
                name: "IsMarried",
                table: "Tbl_UserInformation");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Tbl_Address");

            migrationBuilder.DropColumn(
                name: "ProvinceId1",
                table: "Tbl_Address");

            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "Tbl_Address",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Address_CityId",
                table: "Tbl_Address",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Address_Tbl_City_CityId",
                table: "Tbl_Address",
                column: "CityId",
                principalTable: "Tbl_City",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Address_Tbl_City_CityId",
                table: "Tbl_Address");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Address_CityId",
                table: "Tbl_Address");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Tbl_Address");

            migrationBuilder.AddColumn<bool>(
                name: "IsMarried",
                table: "Tbl_UserInformation",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Tbl_Address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ProvinceId1",
                table: "Tbl_Address",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Address_ProvinceId1",
                table: "Tbl_Address",
                column: "ProvinceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Address_Tbl_Province_ProvinceId1",
                table: "Tbl_Address",
                column: "ProvinceId1",
                principalTable: "Tbl_Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
