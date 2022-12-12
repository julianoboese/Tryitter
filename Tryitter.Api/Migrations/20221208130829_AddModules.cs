using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tryitter.Api.Migrations
{
    public partial class AddModules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "ModuleId", "Name" },
                values: new object[,]
                {
                    { 1, "Fundamentos" },
                    { 2, "Front-end" },
                    { 3, "Back-end" },
                    { 4, "Ciência da Computação" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ModuleId",
                keyValue: 4);
        }
    }
}
