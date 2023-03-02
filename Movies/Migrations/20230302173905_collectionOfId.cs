using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.Migrations
{
    /// <inheritdoc />
    public partial class collectionOfId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Franchises_FranchiseID",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_FranchiseID",
                table: "Movies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Movies_FranchiseID",
                table: "Movies",
                column: "FranchiseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Franchises_FranchiseID",
                table: "Movies",
                column: "FranchiseID",
                principalTable: "Franchises",
                principalColumn: "Id");
        }
    }
}
