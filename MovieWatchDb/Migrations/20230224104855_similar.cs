using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWatchDb.Migrations
{
    /// <inheritdoc />
    public partial class similar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimilarFilms_Films_FilmId",
                table: "SimilarFilms");

            migrationBuilder.DropForeignKey(
                name: "FK_SimilarFilms_Films_SimilarId",
                table: "SimilarFilms");

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarFilms_Films_FilmId",
                table: "SimilarFilms",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarFilms_Films_SimilarId",
                table: "SimilarFilms",
                column: "SimilarId",
                principalTable: "Films",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimilarFilms_Films_FilmId",
                table: "SimilarFilms");

            migrationBuilder.DropForeignKey(
                name: "FK_SimilarFilms_Films_SimilarId",
                table: "SimilarFilms");

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarFilms_Films_FilmId",
                table: "SimilarFilms",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarFilms_Films_SimilarId",
                table: "SimilarFilms",
                column: "SimilarId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
