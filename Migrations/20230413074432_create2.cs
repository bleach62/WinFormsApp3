using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinFormsApp3.Migrations
{
    /// <inheritdoc />
    public partial class create2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Client",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
