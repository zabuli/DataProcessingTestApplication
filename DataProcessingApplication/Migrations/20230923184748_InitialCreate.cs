using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataProcessingApplication.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Indicator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Execution = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Symbol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                    TimeFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column15 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parameter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SymbolId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndicatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parameter_Indicator_IndicatorId",
                        column: x => x.IndicatorId,
                        principalTable: "Indicator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parameter_IndicatorId",
                table: "Parameter",
                column: "IndicatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parameter");

            migrationBuilder.DropTable(
                name: "Symbol");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Indicator");
        }
    }
}
