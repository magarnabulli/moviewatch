using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWatchDb.Migrations
{
    /// <inheritdoc />
    public partial class similars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimilarFilms_Films_FilmId",
                table: "SimilarFilms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_SimilarFilms_Films_FilmId",
                table: "SimilarFilms",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
