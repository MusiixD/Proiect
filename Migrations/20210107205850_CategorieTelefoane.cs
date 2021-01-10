using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect.Migrations
{
    public partial class CategorieTelefoane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieTelefoane",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDTelefon = table.Column<int>(nullable: false),
                    TelefonID = table.Column<int>(nullable: true),
                    IDCategorie = table.Column<int>(nullable: false),
                    CategorieID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieTelefoane", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieTelefoane_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategorieTelefoane_Telefon_TelefonID",
                        column: x => x.TelefonID,
                        principalTable: "Telefon",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieTelefoane_CategorieID",
                table: "CategorieTelefoane",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieTelefoane_TelefonID",
                table: "CategorieTelefoane",
                column: "TelefonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieTelefoane");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
