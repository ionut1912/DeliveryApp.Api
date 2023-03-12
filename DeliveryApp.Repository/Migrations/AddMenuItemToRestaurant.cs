using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryApp.Repository.Migrations
{
    public partial class AddMenuItemToRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "FinalPrice",
                table: "Orders",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantsId",
                table: "MenuItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c7fca2c3-76a7-47ea-a497-97f270268fa1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f97e79eb-e0e8-4aa5-9828-a0b78a70a0df");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_RestaurantsId",
                table: "MenuItems",
                column: "RestaurantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Restaurants_RestaurantsId",
                table: "MenuItems",
                column: "RestaurantsId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Restaurants_RestaurantsId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_RestaurantsId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "RestaurantsId",
                table: "MenuItems");

            migrationBuilder.AlterColumn<float>(
                name: "FinalPrice",
                table: "Orders",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "190d5aa2-5f02-4359-991a-3aa8f165f1df");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "6f375714-8dc3-4cd6-a970-8107d32ce8d3");
        }
    }
}
