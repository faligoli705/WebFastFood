using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastFood.DataLayer.Migrations
{
    public partial class FastFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoreInvoicingDetails",
                columns: table => new
                {
                    InvoicingDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoicingId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LaborCustomerItem = table.Column<int>(type: "int", nullable: false),
                    InvoicingDetailCreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoicingDetailUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoicingDetailDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoicingDetailStatus = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreInvoicingDetails", x => x.InvoicingDetailId);
                });

            migrationBuilder.CreateTable(
                name: "StoreInvoicings",
                columns: table => new
                {
                    InvoicingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    InvoicingDetailId = table.Column<int>(type: "int", nullable: false),
                    StoreInvoicingCreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StoreInvoicingUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StoreInvoicingDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StoreInvoicingStatus = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreInvoicings", x => x.InvoicingId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    NumberOfOrders = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductPreparationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductCreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductPicUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    StoreInvoicingDetailsInvoicingDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_StoreInvoicingDetails_StoreInvoicingDetailsInvoicingDetailId",
                        column: x => x.StoreInvoicingDetailsInvoicingDetailId,
                        principalTable: "StoreInvoicingDetails",
                        principalColumn: "InvoicingDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    StatusCustomer = table.Column<int>(type: "int", nullable: false),
                    PasswordCustomer = table.Column<int>(type: "int", nullable: false),
                    CustomerCreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    StoreInvoicingInvoicingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_StoreInvoicings_StoreInvoicingInvoicingId",
                        column: x => x.StoreInvoicingInvoicingId,
                        principalTable: "StoreInvoicings",
                        principalColumn: "InvoicingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreInvoicingStoreInvoicingDetails",
                columns: table => new
                {
                    StoreInvoicingDetailsInvoicingDetailId = table.Column<int>(type: "int", nullable: false),
                    StoreInvoicingsInvoicingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreInvoicingStoreInvoicingDetails", x => new { x.StoreInvoicingDetailsInvoicingDetailId, x.StoreInvoicingsInvoicingId });
                    table.ForeignKey(
                        name: "FK_StoreInvoicingStoreInvoicingDetails_StoreInvoicingDetails_StoreInvoicingDetailsInvoicingDetailId",
                        column: x => x.StoreInvoicingDetailsInvoicingDetailId,
                        principalTable: "StoreInvoicingDetails",
                        principalColumn: "InvoicingDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreInvoicingStoreInvoicingDetails_StoreInvoicings_StoreInvoicingsInvoicingId",
                        column: x => x.StoreInvoicingsInvoicingId,
                        principalTable: "StoreInvoicings",
                        principalColumn: "InvoicingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CategoryCreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryDeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ProductsProductID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Categories_Products_ProductsProductID",
                        column: x => x.ProductsProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductsProductID",
                table: "Categories",
                column: "ProductsProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_StoreInvoicingInvoicingId",
                table: "Customers",
                column: "StoreInvoicingInvoicingId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreInvoicingDetailsInvoicingDetailId",
                table: "Products",
                column: "StoreInvoicingDetailsInvoicingDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreInvoicingStoreInvoicingDetails_StoreInvoicingsInvoicingId",
                table: "StoreInvoicingStoreInvoicingDetails",
                column: "StoreInvoicingsInvoicingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "StoreInvoicingStoreInvoicingDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "StoreInvoicings");

            migrationBuilder.DropTable(
                name: "StoreInvoicingDetails");
        }
    }
}
