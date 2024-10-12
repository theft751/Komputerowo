using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Certyficate",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Connectors",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Efficiency",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaximalPower",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PowerSupplyProtectorsFeatures",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Certyficate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Connectors",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Efficiency",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MaximalPower",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PowerSupplyProtectorsFeatures",
                table: "Products");
        }
    }
}
