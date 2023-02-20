using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWatchDb.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SimilairFilms");

            migrationBuilder.AddColumn<int>(
                name: "FilmGenreFilmId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilmGenreGenreId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_FilmGenreFilmId_FilmGenreGenreId",
                table: "Genres",
                columns: new[] { "FilmGenreFilmId", "FilmGenreGenreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_FilmGenres_FilmGenreFilmId_FilmGenreGenreId",
                table: "Genres",
                columns: new[] { "FilmGenreFilmId", "FilmGenreGenreId" },
                principalTable: "FilmGenres",
                principalColumns: new[] { "FilmId", "GenreId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_FilmGenres_FilmGenreFilmId_FilmGenreGenreId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_FilmGenreFilmId_FilmGenreGenreId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "FilmGenreFilmId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "FilmGenreGenreId",
                table: "Genres");

            migrationBuilder.CreateTable(
                name: "SimilairFilms",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    SimilairFilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimilairFilms", x => new { x.FilmId, x.SimilairFilmId });
                    table.ForeignKey(
                        name: "FK_SimilairFilms_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SimilairFilms_Films_SimilairFilmId",
                        column: x => x.SimilairFilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SimilairFilms_SimilairFilmId",
                table: "SimilairFilms",
                column: "SimilairFilmId");
        }
    }
}
