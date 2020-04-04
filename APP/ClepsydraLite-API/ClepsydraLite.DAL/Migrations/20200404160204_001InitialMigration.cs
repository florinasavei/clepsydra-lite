using Microsoft.EntityFrameworkCore.Migrations;

namespace ClepsydraLite.DAL.Migrations
{
    public partial class _001InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers_Core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers_Core", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers_ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    SupplierCoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_ProductCategories_Suppliers_Core_SupplierCoreId",
                        column: x => x.SupplierCoreId,
                        principalTable: "Suppliers_Core",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers_ProductOffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    SupplierProductCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers_ProductOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_ProductOffers_Suppliers_ProductCategories_SupplierProductCategoryId",
                        column: x => x.SupplierProductCategoryId,
                        principalTable: "Suppliers_ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers_ProductOfferPrices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceType = table.Column<int>(nullable: false),
                    PriceValue = table.Column<decimal>(nullable: false),
                    SupplierProductOfferId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers_ProductOfferPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_ProductOfferPrices_Suppliers_ProductOffers_SupplierProductOfferId",
                        column: x => x.SupplierProductOfferId,
                        principalTable: "Suppliers_ProductOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ProductCategories_SupplierCoreId",
                table: "Suppliers_ProductCategories",
                column: "SupplierCoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ProductOfferPrices_SupplierProductOfferId",
                table: "Suppliers_ProductOfferPrices",
                column: "SupplierProductOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ProductOffers_SupplierProductCategoryId",
                table: "Suppliers_ProductOffers",
                column: "SupplierProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suppliers_ProductOfferPrices");

            migrationBuilder.DropTable(
                name: "Suppliers_ProductOffers");

            migrationBuilder.DropTable(
                name: "Suppliers_ProductCategories");

            migrationBuilder.DropTable(
                name: "Suppliers_Core");
        }
    }
}
