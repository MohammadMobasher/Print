using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class add_services_item_to_subproject_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasBinding",
                table: "SubProject",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasCover",
                table: "SubProject",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasCut",
                table: "SubProject",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasDeliver",
                table: "SubProject",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasPrint",
                table: "SubProject",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasBinding",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "HasCover",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "HasCut",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "HasDeliver",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "HasPrint",
                table: "SubProject");
        }
    }
}
