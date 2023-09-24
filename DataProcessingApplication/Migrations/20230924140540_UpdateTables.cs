using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataProcessingApplication.Migrations
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Indicator",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeFrom",
                table: "Indicator",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeTo",
                table: "Indicator",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "SymbolId",
                table: "Parameter",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name", table: "Indicator");

            migrationBuilder.DropColumn(
                name: "TimeFrom", table: "Indicator");

            migrationBuilder.DropColumn(
                name: "TimeTo", table: "Indicator");

            migrationBuilder.DropColumn(
                name: "SymbolId", table: "Parameter");
        }
    }
}