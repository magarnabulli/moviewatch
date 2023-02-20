using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWatchDb.Migrations
{
    /// <inheritdoc />
    public partial class img : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmGenres_Films_FilmId",
                table: "FilmGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmGenres_Genres_GenreId",
                table: "FilmGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_FilmGenres_FilmGenreFilmId_FilmGenreGenreId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_FilmGenreFilmId_FilmGenreGenreId",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmGenres",
                table: "FilmGenres");

            migrationBuilder.DropIndex(
                name: "IX_FilmGenres_GenreId",
                table: "FilmGenres");

            migrationBuilder.DropColumn(
                name: "FilmGenreFilmId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "FilmGenreGenreId",
                table: "Genres");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmGenres",
                table: "FilmGenres",
                columns: new[] { "GenreId", "FilmId" });

            migrationBuilder.CreateTable(
                name: "FilmGenre",
                columns: table => new
                {
                    FilmGenresId = table.Column<int>(type: "int", nullable: false),
                    FilmGenresId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenre", x => new { x.FilmGenresId, x.FilmGenresId1 });
                    table.ForeignKey(
                        name: "FK_FilmGenre_Films_FilmGenresId",
                        column: x => x.FilmGenresId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmGenre_Genres_FilmGenresId1",
                        column: x => x.FilmGenresId1,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenre_FilmGenresId1",
                table: "FilmGenre",
                column: "FilmGenresId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmGenres",
                table: "FilmGenres");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Films");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmGenres",
                table: "FilmGenres",
                columns: new[] { "FilmId", "GenreId" });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_FilmGenreFilmId_FilmGenreGenreId",
                table: "Genres",
                columns: new[] { "FilmGenreFilmId", "FilmGenreGenreId" });

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenres_GenreId",
                table: "FilmGenres",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmGenres_Films_FilmId",
                table: "FilmGenres",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmGenres_Genres_GenreId",
                table: "FilmGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_FilmGenres_FilmGenreFilmId_FilmGenreGenreId",
                table: "Genres",
                columns: new[] { "FilmGenreFilmId", "FilmGenreGenreId" },
                principalTable: "FilmGenres",
                principalColumns: new[] { "FilmId", "GenreId" });
        }
    }
}
