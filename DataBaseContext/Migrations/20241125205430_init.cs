using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voivodeship = table.Column<int>(type: "int", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfBuilding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainProductImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    AdressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Adresses_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    GuarantyTime = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainImageId = table.Column<int>(type: "int", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: true),
                    MotherBoardFormats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PowerSupplyFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseType = table.Column<int>(type: "int", nullable: true),
                    DiskSize = table.Column<int>(type: "int", nullable: true),
                    ReadSpeed = table.Column<int>(type: "int", nullable: true),
                    WriteSpeed = table.Column<int>(type: "int", nullable: true),
                    DiskDriveType = table.Column<int>(type: "int", nullable: true),
                    DiskDriveInterface = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gpu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraphicCardSerie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConnectorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutputTypes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemorySize = table.Column<int>(type: "int", nullable: true),
                    MemoryBus = table.Column<int>(type: "int", nullable: true),
                    CoreColck = table.Column<int>(type: "int", nullable: true),
                    MemoryClock = table.Column<int>(type: "int", nullable: true),
                    Litghting = table.Column<bool>(type: "bit", nullable: true),
                    RayTracing = table.Column<bool>(type: "bit", nullable: true),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessorSocket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chipset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalSockets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalSockets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupportedMemoryTypes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupportedMemoryTypesOC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcesorArchitecture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupportedProcessorFamilies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RamSlots = table.Column<int>(type: "int", nullable: true),
                    MaximalPower = table.Column<int>(type: "int", nullable: true),
                    Certyficate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PowerSupplyFormat1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efficiency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Connectors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PowerSupplyProtectorsFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cores = table.Column<int>(type: "int", nullable: true),
                    Threads = table.Column<int>(type: "int", nullable: true),
                    Frequency = table.Column<int>(type: "int", nullable: true),
                    CacheSize = table.Column<int>(type: "int", nullable: true),
                    IntegratedGpu = table.Column<bool>(type: "bit", nullable: true),
                    hasCoolerIncluded = table.Column<bool>(type: "bit", nullable: true),
                    ProcessorSocket1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessorSerie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizePerChips = table.Column<int>(type: "int", nullable: true),
                    ChipsAmount = table.Column<int>(type: "int", nullable: true),
                    Ram_Frequency = table.Column<int>(type: "int", nullable: true),
                    Ligthing = table.Column<bool>(type: "bit", nullable: true),
                    RamType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Processor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesktopComputer_Chipset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesktopComputer_Gpu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GpuMemoryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GpuMemorySize = table.Column<int>(type: "int", nullable: true),
                    DesktopComputer_RamType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RamSize = table.Column<int>(type: "int", nullable: true),
                    DiskType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesktopComputer_DiskSize = table.Column<int>(type: "int", nullable: true),
                    ExternalPorts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternalPorts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PowerSupply = table.Column<int>(type: "int", nullable: true),
                    OperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laptop_Processor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laptop_RamSize = table.Column<int>(type: "int", nullable: true),
                    Laptop_RamType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laptop_DiskSize = table.Column<int>(type: "int", nullable: true),
                    Laptop_DiskType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laptop_Gpu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatteryCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laptop_ExternalPorts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreenDiagonal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ScreenType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laptop_OperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackCamera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrontCamera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Smartphone_Resolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Smartphone_ScreenDiagonal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ScreenRefreshRate = table.Column<int>(type: "int", nullable: true),
                    Smartphone_Processor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Smartphone_RamSize = table.Column<int>(type: "int", nullable: true),
                    EmbeddedMemorySize = table.Column<int>(type: "int", nullable: true),
                    Smartphone_OperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Smartphone_ExternalPorts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Smartphone_BatteryCapacity = table.Column<int>(type: "int", nullable: true),
                    Nfc = table.Column<bool>(type: "bit", nullable: true),
                    FingPrinterReader = table.Column<bool>(type: "bit", nullable: true),
                    Televisor_Resolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Televisor_ScreenDiagonal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Televisor_ScreenRefreshRate = table.Column<int>(type: "int", nullable: true),
                    Televisor_ExternalPorts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hasSmartTv = table.Column<bool>(type: "bit", nullable: true),
                    Televisor_OperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_MainProductImages_MainImageId",
                        column: x => x.MainImageId,
                        principalTable: "MainProductImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AdressId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Adresses_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BonusProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonusProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonusProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AdressId", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "UserType" },
                values: new object[] { 1, null, "admin", "Admin", "Admin", "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=", "000000000", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BonusProductImages_ProductId",
                table: "BonusProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AdressId",
                table: "Orders",
                column: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MainImageId",
                table: "Products",
                column: "MainImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProducerId",
                table: "Products",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AdressId",
                table: "Users",
                column: "AdressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BonusProductImages");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MainProductImages");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Adresses");
        }
    }
}
