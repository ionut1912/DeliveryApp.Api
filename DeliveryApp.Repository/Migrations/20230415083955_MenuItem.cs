using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryApp.Repository.Migrations
{
    public partial class MenuItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MenuItemsRestaurants",
                columns: table => new
                {
                    MenuItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemsRestaurants", x => new { x.MenuItemsId, x.RestaurantsId });
                    table.ForeignKey(
                        name: "FK_MenuItemsRestaurants_MenuItems_MenuItemsId",
                        column: x => x.MenuItemsId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemsRestaurants_Restaurants_RestaurantsId",
                        column: x => x.RestaurantsId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "619b54a5-a77f-439a-adcb-36fd9de5b87f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "abfe94a2-6629-4987-81e5-639014e35fda");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemsRestaurants_RestaurantsId",
                table: "MenuItemsRestaurants",
                column: "RestaurantsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItemsRestaurants");

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
                value: "fe4d7810-da47-4a98-83f8-0bc53925eb48");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "2f145c5c-b625-4790-a020-47df39cbdc42");

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
    }
}
