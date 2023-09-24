using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataProcessingApplication.Migrations
{
    public partial class UpdateTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SymbolId",
                table: "Parameter");

            migrationBuilder.AddColumn<int>(
                name: "SymbolId",
                table: "Indicator",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SymbolId",
                table: "Indicator");

            migrationBuilder.AddColumn<int>(
                name: "SymbolId",
                table: "Parameter",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
