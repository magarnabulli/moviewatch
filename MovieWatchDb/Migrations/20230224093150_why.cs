using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieWatchDb.Migrations
{
    /// <inheritdoc />
    public partial class why : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Realeased",
                table: "Films",
                newName: "Released");

            migrationBuilder.CreateTable(
                name: "SimilarFilms",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    SimilarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimilarFilms", x => new { x.FilmId, x.SimilarId });
                    table.ForeignKey(
                        name: "FK_SimilarFilms_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SimilarFilms_Films_SimilarId",
                        column: x => x.SimilarId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Gore Verbinski" });

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                column: "FilmUrl",
                value: "https://www.youtube-nocookie.com/embed/6Q6gQbrEKyU");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2,
                column: "FilmUrl",
                value: "https://www.youtube.com/embed/7WAzFWu2tVw");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FilmUrl", "Title" },
                values: new object[] { "https://www.youtube.com/embed/KwPTIEWTYEI", "Dune" });

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 4,
                column: "FilmUrl",
                value: "https://www.youtube.com/embed/iszwuX1AK6A");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 5,
                column: "FilmUrl",
                value: "https://www.youtube.com/embed/5iaYLCiq5RM");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 6,
                column: "FilmUrl",
                value: "https://www.youtube.com/embed/imm6OR605UI");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 7,
                column: "FilmUrl",
                value: "https://www.youtube.com/embed/wuBRcfe4bSo");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 8,
                column: "FilmUrl",
                value: "https://www.youtube.com/embed/n9gFKHAFG94");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 9,
                column: "FilmUrl",
                value: "https://www.youtube.com/embed/J-NSyMTpkYI");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 10,
                column: "FilmUrl",
                value: "https://www.youtube.com/embed/ByXuk9QqQkk");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 11,
                column: "FilmUrl",
                value: "https://www.youtube.com/embed/WJC1qciW_3k");

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "DirectorId", "FilmUrl", "Free", "ImgUrl", "Released", "Title" },
                values: new object[] { 12, "When an unconfident young woman is cursed with an old body by a spiteful witch, her only chance of breaking the spell lies with a self-indulgent yet insecure young wizard and his companions in his legged, walking castle.", 5, "https://www.youtube.com/embed/iwROgK94zcM", false, "/images/HowlsMovingCastle.jpg", new DateTime(1988, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Howls Moving Castle" });

            migrationBuilder.InsertData(
                table: "SimilarFilms",
                columns: new[] { "FilmId", "SimilarId" },
                values: new object[,]
                {
                    { 7, 8 },
                    { 7, 9 },
                    { 8, 7 },
                    { 8, 9 },
                    { 9, 7 },
                    { 9, 8 },
                    { 10, 11 },
                    { 11, 10 }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "DirectorId", "FilmUrl", "Free", "ImgUrl", "Released", "Title" },
                values: new object[] { 14, "Blacksmith Will Turner teams up with eccentric pirate \"Captain\" Jack Sparrow to save his love, the governor's daughter, from Jack's former pirate allies, who are now undead.", 6, "https://www.youtube.com/embed/-9HT0l9HV4c", false, "/images/PiratesOfTheCaribbeanCurseOfThePearl.jpg", new DateTime(2003, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pirates of the Caribbean: The Curse of the Black Pearl" });

            migrationBuilder.InsertData(
                table: "SimilarFilms",
                columns: new[] { "FilmId", "SimilarId" },
                values: new object[,]
                {
                    { 10, 12 },
                    { 11, 12 },
                    { 12, 10 },
                    { 12, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SimilarFilms_SimilarId",
                table: "SimilarFilms",
                column: "SimilarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SimilarFilms");

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.RenameColumn(
                name: "Released",
                table: "Films",
                newName: "Realeased");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                column: "FilmUrl",
                value: "https://www.youtube.com/watch?v=6Q6gQbrEKyU");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2,
                column: "FilmUrl",
                value: "https://www.youtube.com/watch?v=7WAzFWu2tVw");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FilmUrl", "Title" },
                values: new object[] { "https://www.youtube.com/watch?v=KwPTIEWTYEI", "Eraserhead" });

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 4,
                column: "FilmUrl",
                value: "https://www.youtube.com/watch?v=iszwuX1AK6A");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 5,
                column: "FilmUrl",
                value: "https://www.youtube.com/watch?v=5iaYLCiq5RM");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 6,
                column: "FilmUrl",
                value: "https://www.youtube.com/watch?v=imm6OR605UI");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 7,
                column: "FilmUrl",
                value: "https://www.youtube.com/watch?v=wuBRcfe4bSo");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 8,
                column: "FilmUrl",
                value: "https://www.youtube.com/watch?v=n9gFKHAFG94");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 9,
                column: "FilmUrl",
                value: "https://www.youtube.com/watch?v=J-NSyMTpkYI");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 10,
                column: "FilmUrl",
                value: "https://www.youtube.com/watch?v=ByXuk9QqQkk");

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 11,
                column: "FilmUrl",
                value: "https://www.youtube.com/watch?v=WJC1qciW_3k");
        }
    }
}
