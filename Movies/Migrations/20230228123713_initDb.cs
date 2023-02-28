using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movies.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Franchises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FranchiseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Franchises_Franchises_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Test2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ASD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FranchiseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Franchises_FranchiseID",
                        column: x => x.FranchiseID,
                        principalTable: "Franchises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMovie",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovie", x => new { x.CharacterId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "Gender", "MovieId", "Name", "Picture" },
                values: new object[,]
                {
                    { 1, "George", "Monki", 1, "Fred", ":)" },
                    { 2, "Shtark", "Female", 2, "Sean Stark", "x(" },
                    { 3, "Meme.gif", "I have no damn clue", 3, "YarYar", "====)" },
                    { 4, "Fred", "Monki", 1, "George", ":)" }
                });

            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "Id", "Description", "FranchiseId", "Name" },
                values: new object[,]
                {
                    { 1, "They're still good despite scuffed author", null, "Harry... Potter..." },
                    { 2, "Actually best moovis", null, "Sagan om ringen" },
                    { 3, "Oh. Oh dear...", null, "Star Wars" }
                });

            migrationBuilder.InsertData(
                table: "Test2",
                columns: new[] { "Id", "ASD", "Name" },
                values: new object[] { 1, "ada", "s" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseID", "Genre", "Picture", "ReleaseYear", "Title", "Trailer" },
                values: new object[,]
                {
                    { 1, "ChrisCol", 1, "Fantasy", "Pic", 2001, "Harry Potter", "Ex-Smelly-Armpits" },
                    { 2, "Mikael Niazi", 2, "Fantasy", "Pic", 2002, "Lord of the Rings", "ISENGARD" },
                    { 3, "Xyz", 3, "SciFi", "Daddy", 1974, "Star Wars", "Pic" },
                    { 4, "ChrisCol", 1, "Fantasy", "Pic", 2019, "Harry Potter 2", "Ex-Smelly-Armpits" },
                    { 5, "Mikael Niazi", 2, "Fantasy", "presshush", 2069, "Honungens Återkomst", "ISENGARD" }
                });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 2, 2 },
                    { 2, 5 },
                    { 3, 3 },
                    { 4, 1 },
                    { 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovie_MovieId",
                table: "CharacterMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Franchises_FranchiseId",
                table: "Franchises",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_FranchiseID",
                table: "Movies",
                column: "FranchiseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovie");

            migrationBuilder.DropTable(
                name: "Test2");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Franchises");
        }
    }
}
