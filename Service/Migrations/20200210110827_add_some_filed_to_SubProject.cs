using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class add_some_filed_to_SubProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BindingNumber",
                table: "SubProject",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BindingType",
                table: "SubProject",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookCover",
                table: "SubProject",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookCoverColor",
                table: "SubProject",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookCoverMaterial",
                table: "SubProject",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookOrSeet",
                table: "SubProject",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "SubProject",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "SubProject",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaperMaterial",
                table: "SubProject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "SubProject",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "SubProject",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SuggestedTime",
                table: "SubProject",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "SubProject",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BindingNumber",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "BindingType",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "BookCover",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "BookCoverColor",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "BookCoverMaterial",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "BookOrSeet",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "PaperMaterial",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "SuggestedTime",
                table: "SubProject");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "SubProject");
        }
    }
}
