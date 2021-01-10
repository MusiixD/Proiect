using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect.Migrations
{
    public partial class DataLansarii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishingDate",
                table: "Telefon");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataLansarii",
                table: "Telefon",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataLansarii",
                table: "Telefon");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishingDate",
                table: "Telefon",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
