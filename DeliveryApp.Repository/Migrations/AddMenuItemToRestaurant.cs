#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryApp.Repository.Migrations;

public partial class AddMenuItemToRestaurant : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<double>(
            "FinalPrice",
            "Orders",
            "float",
            nullable: false,
            oldClrType: typeof(float),
            oldType: "real");

        migrationBuilder.AddColumn<Guid>(
            "RestaurantsId",
            "MenuItems",
            "uniqueidentifier",
            nullable: true);

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            1,
            "ConcurrencyStamp",
            "c7fca2c3-76a7-47ea-a497-97f270268fa1");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            2,
            "ConcurrencyStamp",
            "f97e79eb-e0e8-4aa5-9828-a0b78a70a0df");

        migrationBuilder.CreateIndex(
            "IX_MenuItems_RestaurantsId",
            "MenuItems",
            "RestaurantsId");

        migrationBuilder.AddForeignKey(
            "FK_MenuItems_Restaurants_RestaurantsId",
            "MenuItems",
            "RestaurantsId",
            "Restaurants",
            principalColumn: "Id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            "FK_MenuItems_Restaurants_RestaurantsId",
            "MenuItems");

        migrationBuilder.DropIndex(
            "IX_MenuItems_RestaurantsId",
            "MenuItems");

        migrationBuilder.DropColumn(
            "RestaurantsId",
            "MenuItems");

        migrationBuilder.AlterColumn<float>(
            "FinalPrice",
            "Orders",
            "real",
            nullable: false,
            oldClrType: typeof(double),
            oldType: "float");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            1,
            "ConcurrencyStamp",
            "190d5aa2-5f02-4359-991a-3aa8f165f1df");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            2,
            "ConcurrencyStamp",
            "6f375714-8dc3-4cd6-a970-8107d32ce8d3");
    }
}