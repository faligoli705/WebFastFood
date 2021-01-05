using Microsoft.EntityFrameworkCore.Migrations;

namespace FastFood.DataLayer.Migrations
{
    public partial class fastfood1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_ProductsProductID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_StoreInvoicings_StoreInvoicingInvoicingId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_StoreInvoicingDetails_StoreInvoicingDetailsInvoicingDetailId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreInvoicingStoreInvoicingDetails_StoreInvoicingDetails_StoreInvoicingDetailsInvoicingDetailId",
                table: "StoreInvoicingStoreInvoicingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreInvoicingStoreInvoicingDetails_StoreInvoicings_StoreInvoicingsInvoicingId",
                table: "StoreInvoicingStoreInvoicingDetails");

            migrationBuilder.RenameColumn(
                name: "StoreInvoicingsInvoicingId",
                table: "StoreInvoicingStoreInvoicingDetails",
                newName: "StoreInvoicingsId");

            migrationBuilder.RenameColumn(
                name: "StoreInvoicingDetailsInvoicingDetailId",
                table: "StoreInvoicingStoreInvoicingDetails",
                newName: "StoreInvoicingDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreInvoicingStoreInvoicingDetails_StoreInvoicingsInvoicingId",
                table: "StoreInvoicingStoreInvoicingDetails",
                newName: "IX_StoreInvoicingStoreInvoicingDetails_StoreInvoicingsId");

            migrationBuilder.RenameColumn(
                name: "InvoicingId",
                table: "StoreInvoicings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "InvoicingDetailId",
                table: "StoreInvoicingDetails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StoreInvoicingDetailsInvoicingDetailId",
                table: "Products",
                newName: "StoreInvoicingDetailsId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_StoreInvoicingDetailsInvoicingDetailId",
                table: "Products",
                newName: "IX_Products_StoreInvoicingDetailsId");

            migrationBuilder.RenameColumn(
                name: "StoreInvoicingInvoicingId",
                table: "Customers",
                newName: "StoreInvoicingId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_StoreInvoicingInvoicingId",
                table: "Customers",
                newName: "IX_Customers_StoreInvoicingId");

            migrationBuilder.RenameColumn(
                name: "ProductsProductID",
                table: "Categories",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ProductsProductID",
                table: "Categories",
                newName: "IX_Categories_ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_ProductsId",
                table: "Categories",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_StoreInvoicings_StoreInvoicingId",
                table: "Customers",
                column: "StoreInvoicingId",
                principalTable: "StoreInvoicings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_StoreInvoicingDetails_StoreInvoicingDetailsId",
                table: "Products",
                column: "StoreInvoicingDetailsId",
                principalTable: "StoreInvoicingDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreInvoicingStoreInvoicingDetails_StoreInvoicingDetails_StoreInvoicingDetailsId",
                table: "StoreInvoicingStoreInvoicingDetails",
                column: "StoreInvoicingDetailsId",
                principalTable: "StoreInvoicingDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreInvoicingStoreInvoicingDetails_StoreInvoicings_StoreInvoicingsId",
                table: "StoreInvoicingStoreInvoicingDetails",
                column: "StoreInvoicingsId",
                principalTable: "StoreInvoicings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_ProductsId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_StoreInvoicings_StoreInvoicingId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_StoreInvoicingDetails_StoreInvoicingDetailsId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreInvoicingStoreInvoicingDetails_StoreInvoicingDetails_StoreInvoicingDetailsId",
                table: "StoreInvoicingStoreInvoicingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreInvoicingStoreInvoicingDetails_StoreInvoicings_StoreInvoicingsId",
                table: "StoreInvoicingStoreInvoicingDetails");

            migrationBuilder.RenameColumn(
                name: "StoreInvoicingsId",
                table: "StoreInvoicingStoreInvoicingDetails",
                newName: "StoreInvoicingsInvoicingId");

            migrationBuilder.RenameColumn(
                name: "StoreInvoicingDetailsId",
                table: "StoreInvoicingStoreInvoicingDetails",
                newName: "StoreInvoicingDetailsInvoicingDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreInvoicingStoreInvoicingDetails_StoreInvoicingsId",
                table: "StoreInvoicingStoreInvoicingDetails",
                newName: "IX_StoreInvoicingStoreInvoicingDetails_StoreInvoicingsInvoicingId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StoreInvoicings",
                newName: "InvoicingId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StoreInvoicingDetails",
                newName: "InvoicingDetailId");

            migrationBuilder.RenameColumn(
                name: "StoreInvoicingDetailsId",
                table: "Products",
                newName: "StoreInvoicingDetailsInvoicingDetailId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_StoreInvoicingDetailsId",
                table: "Products",
                newName: "IX_Products_StoreInvoicingDetailsInvoicingDetailId");

            migrationBuilder.RenameColumn(
                name: "StoreInvoicingId",
                table: "Customers",
                newName: "StoreInvoicingInvoicingId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_StoreInvoicingId",
                table: "Customers",
                newName: "IX_Customers_StoreInvoicingInvoicingId");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "Categories",
                newName: "ProductsProductID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ProductsId",
                table: "Categories",
                newName: "IX_Categories_ProductsProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_ProductsProductID",
                table: "Categories",
                column: "ProductsProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_StoreInvoicings_StoreInvoicingInvoicingId",
                table: "Customers",
                column: "StoreInvoicingInvoicingId",
                principalTable: "StoreInvoicings",
                principalColumn: "InvoicingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_StoreInvoicingDetails_StoreInvoicingDetailsInvoicingDetailId",
                table: "Products",
                column: "StoreInvoicingDetailsInvoicingDetailId",
                principalTable: "StoreInvoicingDetails",
                principalColumn: "InvoicingDetailId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreInvoicingStoreInvoicingDetails_StoreInvoicingDetails_StoreInvoicingDetailsInvoicingDetailId",
                table: "StoreInvoicingStoreInvoicingDetails",
                column: "StoreInvoicingDetailsInvoicingDetailId",
                principalTable: "StoreInvoicingDetails",
                principalColumn: "InvoicingDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreInvoicingStoreInvoicingDetails_StoreInvoicings_StoreInvoicingsInvoicingId",
                table: "StoreInvoicingStoreInvoicingDetails",
                column: "StoreInvoicingsInvoicingId",
                principalTable: "StoreInvoicings",
                principalColumn: "InvoicingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
