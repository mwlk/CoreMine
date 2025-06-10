using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMine.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixremoveColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockLevels_Locations_LocationId1",
                table: "StockLevels");

            migrationBuilder.DropIndex(
                name: "IX_StockLevels_LocationId1",
                table: "StockLevels");

            migrationBuilder.DropColumn(
                name: "LocationId1",
                table: "StockLevels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId1",
                table: "StockLevels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockLevels_LocationId1",
                table: "StockLevels",
                column: "LocationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StockLevels_Locations_LocationId1",
                table: "StockLevels",
                column: "LocationId1",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
