using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okul.Migrations
{
    public partial class mig_deletedtime_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Ogretmenler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Ogrenciler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Dersler",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Dersler",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Ogretmenler");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Dersler");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Dersler");
        }
    }
}
