using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "SumPrice",
                table: "Bill",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfPage",
                table: "Bill",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "SumPrice",
                table: "Bill",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "NumberOfPage",
                table: "Bill",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
