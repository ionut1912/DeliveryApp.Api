#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryApp.Repository.Migrations;

public partial class configNew : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<double>(
            "NumberOfCaloriesConsumed",
            "UserConfigs",
            "float",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AlterColumn<double>(
            "NumberOfCaloriesAllowed",
            "UserConfigs",
            "float",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            1,
            "ConcurrencyStamp",
            "b460f9d6-d4a1-411d-a1f1-216f20eb41a9");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            2,
            "ConcurrencyStamp",
            "f05b568d-70fc-4324-b683-7ab0dfa732c0");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<int>(
            "NumberOfCaloriesConsumed",
            "UserConfigs",
            "int",
            nullable: false,
            oldClrType: typeof(double),
            oldType: "float");

        migrationBuilder.AlterColumn<int>(
            "NumberOfCaloriesAllowed",
            "UserConfigs",
            "int",
            nullable: false,
            oldClrType: typeof(double),
            oldType: "float");

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
}