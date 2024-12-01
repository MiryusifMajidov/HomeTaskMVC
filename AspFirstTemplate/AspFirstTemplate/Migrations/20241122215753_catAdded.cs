using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspFirstTemplate.Migrations
{
    /// <inheritdoc />
    public partial class catAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cat",
                table: "Works",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cat",
                table: "Works");
        }
    }
}
