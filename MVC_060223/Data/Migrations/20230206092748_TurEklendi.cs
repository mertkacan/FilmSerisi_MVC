using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_060223.Data.Migrations
{
    public partial class TurEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmTur",
                columns: table => new
                {
                    FilmlerId = table.Column<int>(type: "int", nullable: false),
                    TurlerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmTur", x => new { x.FilmlerId, x.TurlerId });
                    table.ForeignKey(
                        name: "FK_FilmTur_Filmler_FilmlerId",
                        column: x => x.FilmlerId,
                        principalTable: "Filmler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmTur_Turler_TurlerId",
                        column: x => x.TurlerId,
                        principalTable: "Turler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Turler",
                columns: new[] { "Id", "Ad" },
                values: new object[,]
                {
                    { 1, "Aksiyon" },
                    { 2, "Macera" },
                    { 3, "Animasyon" },
                    { 4, "Biyografi" },
                    { 5, "Komedi" },
                    { 6, "Suç" },
                    { 7, "Drama" },
                    { 8, "Aile" },
                    { 9, "Fantastik" },
                    { 10, "Siyah Beyaz" },
                    { 11, "Tarih" },
                    { 12, "Korku" },
                    { 13, "Müzik" },
                    { 14, "Müzikal" },
                    { 15, "Gizem" },
                    { 16, "Romantik" },
                    { 17, "Bilim Kurgu" },
                    { 18, "Gerilim" },
                    { 19, "Savaş" },
                    { 20, "Batı" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmTur_TurlerId",
                table: "FilmTur",
                column: "TurlerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmTur");

            migrationBuilder.DropTable(
                name: "Turler");
        }
    }
}
