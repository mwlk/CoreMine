using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMine.Data.Migrations
{
    /// <inheritdoc />
    public partial class feat_add_modelYear_code : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelYear",
                table: "Repairs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelYear",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Products");
        }
    }
}
