using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movies.Migrations
{
    /// <inheritdoc />
    public partial class reset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Test2",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "Gender", "MovieId", "Name", "Picture" },
                values: new object[,]
                {
                    { 1, "George", "Monki", null, "Fred", ":)" },
                    { 2, "Shtark", "Female", null, "Sean Stark", "x(" },
                    { 3, "Meme.gif", "I have no damn clue", null, "YarYar", "====)" },
                    { 4, "Fred", "Monki", null, "George", ":)" }
                });

            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "They're still good despite scuffed author", "Harry... Potter..." },
                    { 2, "Actually best moovis", "Sagan om ringen" },
                    { 3, "Oh. Oh dear...", "Star Wars" }
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
        }
    }
}
