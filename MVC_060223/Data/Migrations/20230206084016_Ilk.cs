using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_060223.Data.Migrations
{
    public partial class Ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Yil = table.Column<int>(type: "int", nullable: false),
                    Puan = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmler", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Filmler",
                columns: new[] { "Id", "Ad", "Puan", "Yil" },
                values: new object[,]
                {
                    { 1, "Fight Club", 8.7m, 1999 },
                    { 2, "Inception", 8.7m, 2010 },
                    { 3, "The Matrix", 8.7m, 1999 },
                    { 4, "Joker", 8.3m, 2019 },
                    { 5, "Die Hard", 8.2m, 1988 },
                    { 6, "Green Book", 8.2m, 2018 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmler");
        }
    }
}
