using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect.Migrations
{
    public partial class NumeProducator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProducatorName",
                table: "Producator");

            migrationBuilder.AddColumn<string>(
                name: "NumeProducator",
                table: "Producator",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeProducator",
                table: "Producator");

            migrationBuilder.AddColumn<string>(
                name: "ProducatorName",
                table: "Producator",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
