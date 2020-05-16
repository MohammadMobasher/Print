using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class add_bill_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubProjectId = table.Column<int>(nullable: false),
                    PriceEachPage = table.Column<double>(nullable: true),
                    SumPriceEachPage = table.Column<double>(nullable: true),
                    NumberOfPage = table.Column<double>(nullable: true),
                    PriceEachCover = table.Column<double>(nullable: true),
                    SumPriceEachCover = table.Column<double>(nullable: true),
                    PriceDelivery = table.Column<double>(nullable: true),
                    SumPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill_SubProject_SubProjectId",
                        column: x => x.SubProjectId,
                        principalTable: "SubProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_SubProjectId",
                table: "Bill",
                column: "SubProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill");
        }
    }
}
