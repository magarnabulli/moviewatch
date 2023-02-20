using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieWatchDb.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Realeased = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DirectorId = table.Column<int>(type: "int", nullable: false),
                    Free = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmGenres",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenres", x => new { x.FilmId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_FilmGenres_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "David Lynch" },
                    { 2, "Martin Scorsese" },
                    { 3, "Steven Soderbergh" },
                    { 4, "Errol Morris" },
                    { 5, "Hayao Miyazaki" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Mystery" },
                    { 3, "Fantasy" },
                    { 4, "SciFi" },
                    { 5, "Drama" },
                    { 6, "Comedy" },
                    { 7, "Adventure" },
                    { 8, "Horror" },
                    { 9, "Thriller" },
                    { 10, "Crime" },
                    { 11, "Documentary" },
                    { 12, "Animation" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "DirectorId", "FilmUrl", "Free", "ImgUrl", "Realeased", "Title" },
                values: new object[,]
                {
                    { 1, "The discovery of a severed human ear found in a field leads a young man on an investigation related to a beautiful, mysterious nightclub singer and a group of psychopathic criminals who have kidnapped her child.", 1, "https://www.youtube.com/watch?v=6Q6gQbrEKyU", true, "/images/BlueVelvet.jpg", new DateTime(1986, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blue Velvet" },
                    { 2, "Henry Spencer tries to survive his industrial environment, his angry girlfriend, and the unbearable screams of his newly born mutant child.", 1, "https://www.youtube.com/watch?v=7WAzFWu2tVw", false, "/images/Eraserhead.jpg", new DateTime(1977, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eraserhead" },
                    { 3, "A Duke's son leads desert warriors against the galactic emperor and his father's evil nemesis to free their desert world from the emperor's rule.", 1, "https://www.youtube.com/watch?v=KwPTIEWTYEI", false, "/images/Dune.jpg", new DateTime(1984, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eraserhead" },
                    { 4, "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.", 2, "https://www.youtube.com/watch?v=iszwuX1AK6A", true, "/images/WolfOfWallStreet.jpg", new DateTime(2013, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Wolf of Wallstreet" },
                    { 5, "In 1954, a U.S. Marshal investigates the disappearance of a murderer who escaped from a hospital for the criminally insane.", 2, "https://www.youtube.com/watch?v=5iaYLCiq5RM", false, "/images/ShutterIsland.jpg", new DateTime(2010, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shutter Island" },
                    { 6, "Danny Ocean and his ten accomplices plan to rob three Las Vegas casinos simultaneously.", 3, "https://www.youtube.com/watch?v=imm6OR605UI", true, "/images/OceansEleven.jpg", new DateTime(2001, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oceans Eleven" },
                    { 7, "A widow investigates an insurance fraud, chasing leads to a pair of Panama City law partners exploiting the world's financial system.", 3, "https://www.youtube.com/watch?v=wuBRcfe4bSo", true, "/images/TheLaundromat.jpg", new DateTime(2019, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Laundromat" },
                    { 8, "An exploration of the careers of four unrelated professionals: a lion tamer, a robotics expert, a topiary gardener, and a naked mole rat specialist.", 4, "https://www.youtube.com/watch?v=n9gFKHAFG94", false, "/images/FastCheapOutOfControl.jpg", new DateTime(1997, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fast, Cheap & Out of Control" },
                    { 9, "Former United States Secretary of Defense, Donald Rumsfeld, discusses his career in Washington D.C. from his days as a congressman in the early 1960s to planning the invasion of Iraq in 2003", 4, "https://www.youtube.com/watch?v=J-NSyMTpkYI", true, "/images/UnknownKnown.jpg", new DateTime(2013, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Unkown Known" },
                    { 10, "During her family's move to the suburbs, a sullen 10-year-old girl wanders into a world ruled by gods, witches, and spirits, and where humans are changed into beasts.", 5, "https://www.youtube.com/watch?v=ByXuk9QqQkk", true, "/images/SpiritedAway.jpg", new DateTime(2001, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spirited Away" },
                    { 11, "When two girls move to the country to be near their ailing mother, they have adventures with the wondrous forest spirits who live nearby.", 5, "https://www.youtube.com/watch?v=WJC1qciW_3k", false, "/images/MyNeighbourTotoro.jpg", new DateTime(1988, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "My Neighbour Totoro" }
                });

            migrationBuilder.InsertData(
                table: "FilmGenres",
                columns: new[] { "FilmId", "GenreId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 5 },
                    { 1, 9 },
                    { 1, 10 },
                    { 2, 3 },
                    { 2, 8 },
                    { 3, 1 },
                    { 3, 4 },
                    { 3, 7 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 10 },
                    { 5, 2 },
                    { 5, 9 },
                    { 6, 9 },
                    { 6, 10 },
                    { 7, 5 },
                    { 7, 6 },
                    { 7, 10 },
                    { 8, 11 },
                    { 9, 11 },
                    { 10, 2 },
                    { 10, 3 },
                    { 10, 7 },
                    { 10, 12 },
                    { 11, 3 },
                    { 11, 6 },
                    { 11, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenres_GenreId",
                table: "FilmGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_DirectorId",
                table: "Films",
                column: "DirectorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmGenres");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
