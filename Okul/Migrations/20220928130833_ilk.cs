using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Okul.Migrations
{
    public partial class ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dersler",
                columns: table => new
                {
                    DersID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dersler", x => x.DersID);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenciler",
                columns: table => new
                {
                    OgrenciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OgrenciTcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    OgrenciDogumTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OgrenciSinif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenciler", x => x.OgrenciID);
                });

            migrationBuilder.CreateTable(
                name: "Ogretmenler",
                columns: table => new
                {
                    OgretmenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgretmenName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OgretmenTcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    OgretmenDogumTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DersID = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmenler", x => x.OgretmenID);
                    table.ForeignKey(
                        name: "FK_Ogretmenler_Dersler_DersID",
                        column: x => x.DersID,
                        principalTable: "Dersler",
                        principalColumn: "DersID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ogretmenler_DersID",
                table: "Ogretmenler",
                column: "DersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ogrenciler");

            migrationBuilder.DropTable(
                name: "Ogretmenler");

            migrationBuilder.DropTable(
                name: "Dersler");
        }
    }
}
