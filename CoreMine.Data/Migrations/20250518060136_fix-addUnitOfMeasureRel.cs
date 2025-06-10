using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMine.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixaddUnitOfMeasureRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitOfMeasereId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasereId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
