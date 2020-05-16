using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class add_NumOf_Binding_Covering_Printing_for_subproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumOfBinding",
                table: "SubProject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumOfCovering",
                table: "SubProject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumOfPrinting",
                table: "SubProject",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumOfBinding",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "NumOfCovering",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "NumOfPrinting",
                table: "SubProject");
        }
    }
}
