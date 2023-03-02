using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.Migrations
{
    /// <inheritdoc />
    public partial class FranchiseAddMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Franchises_Franchises_FranchiseId",
                table: "Franchises");

            migrationBuilder.DropIndex(
                name: "IX_Franchises_FranchiseId",
                table: "Franchises");

            migrationBuilder.DropColumn(
                name: "FranchiseId",
                table: "Franchises");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FranchiseId",
                table: "Franchises",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 1,
                column: "FranchiseId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 2,
                column: "FranchiseId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 3,
                column: "FranchiseId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Franchises_FranchiseId",
                table: "Franchises",
                column: "FranchiseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Franchises_Franchises_FranchiseId",
                table: "Franchises",
                column: "FranchiseId",
                principalTable: "Franchises",
                principalColumn: "Id");
        }
    }
}
