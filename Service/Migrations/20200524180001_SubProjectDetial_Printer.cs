using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class SubProjectDetial_Printer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Printer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubProjectDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubProjectId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    PrinterId = table.Column<int>(nullable: true),
                    StatusChageDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProjectDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubProjectDetails_Printer_PrinterId",
                        column: x => x.PrinterId,
                        principalTable: "Printer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubProjectDetails_SubProject_SubProjectId",
                        column: x => x.SubProjectId,
                        principalTable: "SubProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubProjectDetails_PrinterId",
                table: "SubProjectDetails",
                column: "PrinterId");

            migrationBuilder.CreateIndex(
                name: "IX_SubProjectDetails_SubProjectId",
                table: "SubProjectDetails",
                column: "SubProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubProjectDetails");

            migrationBuilder.DropTable(
                name: "Printer");
        }
    }
}
