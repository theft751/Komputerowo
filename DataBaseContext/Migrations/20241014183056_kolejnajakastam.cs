using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class kolejnajakastam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Products",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AddColumn<string>(
                name: "BackCamera",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatteryCapacity",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Chpset",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DesktopComputer_DiskSize",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DesktopComputer_RamType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiskType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmedebMemorySize",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalPorts",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FingPrinterReader",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontCamera",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gpu",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GpuMemorySize",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GpuMemoryType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InternalPorts",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Laptop_DiskSize",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Laptop_DiskType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Laptop_ExternalPorts",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Laptop_Gpu",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Laptop_OperatingSystem",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Laptop_Processor",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Laptop_RamSize",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Laptop_RamType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NFC",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperatingSystem",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PowerSupply",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Processor",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RamSize",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resolution",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ScreenDiagonal",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScreenRefreshRate",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScreenType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Smartphone_ExternalPorts",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Smartphone_OperatingSystem",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Smartphone_Processor",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Smartphone_RamSize",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Smartphone_Resolution",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Smartphone_ScreenDiagonal",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Televisor_ExternalPorts",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Televisor_OperatingSystem",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Televisor_Resolution",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Televisor_ScreenDiagonal",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Televisor_ScreenRefreshRate",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "hasSmartTv",
                table: "Products",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackCamera",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BatteryCapacity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Chpset",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DesktopComputer_DiskSize",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DesktopComputer_RamType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiskType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EmedebMemorySize",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ExternalPorts",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FingPrinterReader",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FrontCamera",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Gpu",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GpuMemorySize",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GpuMemoryType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InternalPorts",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Laptop_DiskSize",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Laptop_DiskType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Laptop_ExternalPorts",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Laptop_Gpu",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Laptop_OperatingSystem",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Laptop_Processor",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Laptop_RamSize",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Laptop_RamType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NFC",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OperatingSystem",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PowerSupply",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Processor",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RamSize",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Resolution",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ScreenDiagonal",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ScreenRefreshRate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ScreenType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Smartphone_ExternalPorts",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Smartphone_OperatingSystem",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Smartphone_Processor",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Smartphone_RamSize",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Smartphone_Resolution",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Smartphone_ScreenDiagonal",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Televisor_ExternalPorts",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Televisor_OperatingSystem",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Televisor_Resolution",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Televisor_ScreenDiagonal",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Televisor_ScreenRefreshRate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "hasSmartTv",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Products",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(21)",
                oldMaxLength: 21);
        }
    }
}
