using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imaginary_Dealer.Migrations
{
    /// <inheritdoc />
    public partial class Cheack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandF_K",
                table: "Models");

            migrationBuilder.RenameColumn(
                name: "BrandF_K",
                table: "Models",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Models_BrandF_K",
                table: "Models",
                newName: "IX_Models_BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Models",
                newName: "BrandF_K");

            migrationBuilder.RenameIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                newName: "IX_Models_BrandF_K");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandF_K",
                table: "Models",
                column: "BrandF_K",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
