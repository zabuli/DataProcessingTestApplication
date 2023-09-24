using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataProcessingApplication.Migrations
{
    public partial class IndicatorRemoveSymbolId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SymbolId",
                table: "Indicator");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SymbolId",
                table: "Indicator",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
