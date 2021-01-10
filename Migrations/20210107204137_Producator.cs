using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect.Migrations
{
    public partial class Producator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDProducator",
                table: "Telefon",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProducatorID",
                table: "Telefon",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Producator",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProducatorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producator", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefon_ProducatorID",
                table: "Telefon",
                column: "ProducatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefon_Producator_ProducatorID",
                table: "Telefon",
                column: "ProducatorID",
                principalTable: "Producator",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefon_Producator_ProducatorID",
                table: "Telefon");

            migrationBuilder.DropTable(
                name: "Producator");

            migrationBuilder.DropIndex(
                name: "IX_Telefon_ProducatorID",
                table: "Telefon");

            migrationBuilder.DropColumn(
                name: "IDProducator",
                table: "Telefon");

            migrationBuilder.DropColumn(
                name: "ProducatorID",
                table: "Telefon");
        }
    }
}
