using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWashSystem.Migrations
{
    /// <inheritdoc />
    public partial class CarOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarModel",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarModel",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CarNumber",
                table: "Orders");
        }
    }
}
