using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMine.Data.Migrations
{
    /// <inheritdoc />
    public partial class feat_add_unique_into_invoice_number : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PurchasInvoices_InvoiceNumber",
                table: "PurchasInvoices",
                column: "InvoiceNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PurchasInvoices_InvoiceNumber",
                table: "PurchasInvoices");
        }
    }
}
