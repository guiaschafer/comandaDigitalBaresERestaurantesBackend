using Microsoft.EntityFrameworkCore.Migrations;

namespace ComandaDigitalBaresERestaurantes.Aplicacao.Migrations
{
    public partial class UrlCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Category",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Category");
        }
    }
}
