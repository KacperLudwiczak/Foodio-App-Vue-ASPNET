using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDataImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "images/tiramisu.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "images/tiramisu.avif");
        }
    }
}
