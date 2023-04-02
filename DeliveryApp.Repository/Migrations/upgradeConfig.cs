#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryApp.Repository.Migrations;

public partial class upgradeConfig : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            "NumberOfCaloriesAllowed",
            "UserConfigs",
            "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            "NumberOfCaloriesConsumed",
            "UserConfigs",
            "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            "NumberOfCalories",
            "MenuItems",
            "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            1,
            "ConcurrencyStamp",
            "a52c26ff-6e7d-40f3-aae9-79c571b14cf7");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            2,
            "ConcurrencyStamp",
            "8d16c80a-156b-4dfe-8195-ce64885f14e3");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            "NumberOfCaloriesAllowed",
            "UserConfigs");

        migrationBuilder.DropColumn(
            "NumberOfCaloriesConsumed",
            "UserConfigs");

        migrationBuilder.DropColumn(
            "NumberOfCalories",
            "MenuItems");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            1,
            "ConcurrencyStamp",
            "df19313d-4bfd-49d6-a464-1d9efceb3cb7");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            2,
            "ConcurrencyStamp",
            "9a7976ae-6e4a-4858-9285-09d5a0e976bb");
    }
}