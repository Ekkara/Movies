using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.Migrations
{
    /// <inheritdoc />
    public partial class hiddenLinkingTableRemade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Movies_MovieId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_MovieId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Characters");

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

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovie_MovieId",
                table: "CharacterMovie",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovie");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_MovieId",
                table: "Characters",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Movies_MovieId",
                table: "Characters",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
