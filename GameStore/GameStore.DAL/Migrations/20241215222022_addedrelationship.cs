using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_games_GameId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_GameId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "comments");

            migrationBuilder.CreateIndex(
                name: "IX_comments_ProductId",
                table: "comments",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_games_ProductId",
                table: "comments",
                column: "ProductId",
                principalTable: "games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_games_ProductId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_ProductId",
                table: "comments");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_comments_GameId",
                table: "comments",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_games_GameId",
                table: "comments",
                column: "GameId",
                principalTable: "games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
