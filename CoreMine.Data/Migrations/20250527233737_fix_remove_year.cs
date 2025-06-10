using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMine.Data.Migrations
{
    /// <inheritdoc />
    public partial class fix_remove_year : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelYear",
                table: "Repairs");

            migrationBuilder.AddColumn<int>(
                name: "ModelYear",
                table: "Machines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelYear",
                table: "Machines");

            migrationBuilder.AddColumn<int>(
                name: "ModelYear",
                table: "Repairs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
