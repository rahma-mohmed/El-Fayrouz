using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fayroz.Migrations
{
    public partial class AddAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CityName", "DeliveryPrice" },
                values: new object[,]
                {
                    { 1, "Damietta", 20 },
                    { 2, "New Damietta", 20 },
                    { 3, "Ras El Bar", 20 },
                    { 4, "Kafr Saad", 20 },
                    { 5, "Faraskur", 10 },
                    { 6, "Zarqa", 25 },
                    { 7, "Kafr El-Battikh", 25 },
                    { 8, "El-Zarka", 25 },
                    { 9, "El-Sherbin", 25 },
                    { 10, "Azbet El-Borg", 25 },
                    { 11, "El-Zarka El Hamra", 25 },
                    { 12, "El-Nawawra", 25 },
                    { 13, "El-Shata", 25 },
                    { 14, "El-Tabloul", 25 },
                    { 15, "Kafr El-Dawwar", 25 },
                    { 16, "El-Bana", 25 },
                    { 17, "El-Sheikhy", 25 },
                    { 18, "Al-Galala", 25 },
                    { 19, "El-Azab", 25 },
                    { 20, "El-Haraqia", 25 },
                    { 21, "El-Negaila", 25 },
                    { 22, "El-Rahmaniya", 25 },
                    { 23, "Kafr El-Batikh El-Bahary", 25 },
                    { 24, "El-Qarya El-Bayda", 25 },
                    { 25, "El-Safha", 25 },
                    { 26, "El-Maghara", 25 },
                    { 27, "El-Harath", 25 },
                    { 28, "El-Sameil", 25 },
                    { 29, "El-Qasrayn", 25 },
                    { 30, "El-Mahgoubin", 25 },
                    { 31, "Kafr El-Meselha", 25 },
                    { 32, "El-Athar", 25 },
                    { 33, "El-Khashab", 25 },
                    { 34, "El-Seyouf", 25 },
                    { 35, "El-Gendi", 25 },
                    { 36, "El-Saadat", 25 },
                    { 37, "El-Hanout", 25 },
                    { 38, "El-Safira", 25 },
                    { 39, "El-Rouda", 25 },
                    { 40, "El-Mahamid", 25 },
                    { 41, "El-Dammara", 25 },
                    { 42, "El-Ameriya", 25 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CityName", "DeliveryPrice" },
                values: new object[,]
                {
                    { 43, "El-Manshiya", 25 },
                    { 44, "El-Dahab", 25 },
                    { 45, "El-Katiba", 25 },
                    { 46, "El-Qasas", 25 },
                    { 47, "El-Sawalha", 25 },
                    { 48, "El-Matareya", 25 },
                    { 49, "El-Qawafeer", 25 },
                    { 50, "El-Berkit", 25 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RePassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }
    }
}
