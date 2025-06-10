using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMine.Data.Migrations
{
    /// <inheritdoc />
    public partial class feat_add_invoices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchasInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IngresedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasInvoices_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseInvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceDetails_PurchasInvoices_PurchaseInvoiceId",
                        column: x => x.PurchaseInvoiceId,
                        principalTable: "PurchasInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceDetails_Id",
                table: "PurchaseInvoiceDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceDetails_ProductId",
                table: "PurchaseInvoiceDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceDetails_PurchaseInvoiceId",
                table: "PurchaseInvoiceDetails",
                column: "PurchaseInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasInvoices_Id",
                table: "PurchasInvoices",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasInvoices_SupplierId",
                table: "PurchasInvoices",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseInvoiceDetails");

            migrationBuilder.DropTable(
                name: "PurchasInvoices");
        }
    }
}
