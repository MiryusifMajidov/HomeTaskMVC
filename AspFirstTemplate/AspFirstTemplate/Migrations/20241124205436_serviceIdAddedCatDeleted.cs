using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspFirstTemplate.Migrations
{
    /// <inheritdoc />
    public partial class serviceIdAddedCatDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cat",
                table: "Works");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Works",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Works_ServiceId",
                table: "Works",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Services_ServiceId",
                table: "Works",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Services_ServiceId",
                table: "Works");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Works_ServiceId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Works");

            migrationBuilder.AddColumn<string>(
                name: "Cat",
                table: "Works",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
