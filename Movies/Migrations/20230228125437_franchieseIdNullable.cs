using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.Migrations
{
    /// <inheritdoc />
    public partial class franchieseIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Franchises_FranchiseID",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "FranchiseID",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Franchises_FranchiseID",
                table: "Movies",
                column: "FranchiseID",
                principalTable: "Franchises",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Franchises_FranchiseID",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "FranchiseID",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Franchises_FranchiseID",
                table: "Movies",
                column: "FranchiseID",
                principalTable: "Franchises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
