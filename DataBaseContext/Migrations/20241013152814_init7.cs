using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Chipset",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalSockets",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Format",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InternalSockets",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesorArchitecture",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcessorSocket1",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RamSlots",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SuportedMemoryTypesOC",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupportedMemoryTypes",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupportedProcessorFamilies",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chipset",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ExternalSockets",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Format",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InternalSockets",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProcesorArchitecture",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProcessorSocket1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RamSlots",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SuportedMemoryTypesOC",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SupportedMemoryTypes",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SupportedProcessorFamilies",
                table: "Products");
        }
    }
}
