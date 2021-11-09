using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleWebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Харьков" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Киев" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Минск" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[] { 1, 1, "Иван Иванов" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[] { 2, 2, "Петров Петр" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[] { 3, 3, "Семен Семен" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
