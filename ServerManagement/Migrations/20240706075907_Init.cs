using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServerManagement.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "Id", "City", "IsOnline", "Name" },
                values: new object[,]
                {
                    { 1, "Tokyo", true, "Nebula" },
                    { 2, "Berlin", true, "QuantumCore" },
                    { 3, "London", true, "Phoenix" },
                    { 4, "Sydney", true, "TitanX" },
                    { 5, "Tokyo", true, "CyberWave" },
                    { 6, "London", true, "Hyperion" },
                    { 7, "Paris", false, "Aether" },
                    { 8, "Singapore", false, "Vortex" },
                    { 9, "Shanghai", true, "Pulsar" },
                    { 10, "Singapore", true, "Zenith" },
                    { 11, "Shanghai", false, "Stratos" },
                    { 12, "Berlin", true, "Aurora" },
                    { 13, "Tokyo", false, "Nimbus" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
