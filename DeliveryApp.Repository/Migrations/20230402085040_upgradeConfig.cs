using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryApp.Repository.Migrations
{
    public partial class upgradeConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfCaloriesAllowed",
                table: "UserConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfCaloriesConsumed",
                table: "UserConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfCalories",
                table: "MenuItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a52c26ff-6e7d-40f3-aae9-79c571b14cf7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8d16c80a-156b-4dfe-8195-ce64885f14e3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfCaloriesAllowed",
                table: "UserConfigs");

            migrationBuilder.DropColumn(
                name: "NumberOfCaloriesConsumed",
                table: "UserConfigs");

            migrationBuilder.DropColumn(
                name: "NumberOfCalories",
                table: "MenuItems");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "df19313d-4bfd-49d6-a464-1d9efceb3cb7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9a7976ae-6e4a-4858-9285-09d5a0e976bb");
        }
    }
}
