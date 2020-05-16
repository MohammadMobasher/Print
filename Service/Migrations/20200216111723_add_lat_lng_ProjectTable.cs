using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class add_lat_lng_ProjectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "lat",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "lng",
                table: "Project",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lat",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "lng",
                table: "Project");
        }
    }
}
