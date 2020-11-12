using Microsoft.EntityFrameworkCore.Migrations;

namespace ComandaDigitalBaresERestaurantes.Aplicacao.Migrations
{
    public partial class AlterOrderIten : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderIten_IdProduct",
                table: "OrderIten");

            migrationBuilder.CreateIndex(
                name: "IX_OrderIten_IdProduct",
                table: "OrderIten",
                column: "IdProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderIten_IdProduct",
                table: "OrderIten");

            migrationBuilder.CreateIndex(
                name: "IX_OrderIten_IdProduct",
                table: "OrderIten",
                column: "IdProduct",
                unique: true);
        }
    }
}
