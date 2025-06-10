using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMine.Data.Migrations
{
    /// <inheritdoc />
    public partial class fix_table_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceDetails_PurchasInvoices_PurchaseInvoiceId",
                table: "PurchaseInvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasInvoices_Suppliers_SupplierId",
                table: "PurchasInvoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasInvoices",
                table: "PurchasInvoices");

            migrationBuilder.RenameTable(
                name: "PurchasInvoices",
                newName: "PurchaseInvoices");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasInvoices_SupplierId",
                table: "PurchaseInvoices",
                newName: "IX_PurchaseInvoices_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasInvoices_InvoiceNumber",
                table: "PurchaseInvoices",
                newName: "IX_PurchaseInvoices_InvoiceNumber");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasInvoices_Id",
                table: "PurchaseInvoices",
                newName: "IX_PurchaseInvoices_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseInvoices",
                table: "PurchaseInvoices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceDetails_PurchaseInvoices_PurchaseInvoiceId",
                table: "PurchaseInvoiceDetails",
                column: "PurchaseInvoiceId",
                principalTable: "PurchaseInvoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoices_Suppliers_SupplierId",
                table: "PurchaseInvoices",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceDetails_PurchaseInvoices_PurchaseInvoiceId",
                table: "PurchaseInvoiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoices_Suppliers_SupplierId",
                table: "PurchaseInvoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseInvoices",
                table: "PurchaseInvoices");

            migrationBuilder.RenameTable(
                name: "PurchaseInvoices",
                newName: "PurchasInvoices");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseInvoices_SupplierId",
                table: "PurchasInvoices",
                newName: "IX_PurchasInvoices_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseInvoices_InvoiceNumber",
                table: "PurchasInvoices",
                newName: "IX_PurchasInvoices_InvoiceNumber");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseInvoices_Id",
                table: "PurchasInvoices",
                newName: "IX_PurchasInvoices_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasInvoices",
                table: "PurchasInvoices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceDetails_PurchasInvoices_PurchaseInvoiceId",
                table: "PurchaseInvoiceDetails",
                column: "PurchaseInvoiceId",
                principalTable: "PurchasInvoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasInvoices_Suppliers_SupplierId",
                table: "PurchasInvoices",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
