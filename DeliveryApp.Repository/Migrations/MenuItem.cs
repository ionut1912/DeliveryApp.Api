#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryApp.Repository.Migrations;

public partial class MenuItem : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
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

        migrationBuilder.CreateTable(
            "MenuItemsRestaurants",
            table => new
            {
                MenuItemsId = table.Column<Guid>("uniqueidentifier", nullable: false),
                RestaurantsId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MenuItemsRestaurants", x => new { x.MenuItemsId, x.RestaurantsId });
                table.ForeignKey(
                    "FK_MenuItemsRestaurants_MenuItems_MenuItemsId",
                    x => x.MenuItemsId,
                    "MenuItems",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_MenuItemsRestaurants_Restaurants_RestaurantsId",
                    x => x.RestaurantsId,
                    "Restaurants",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            1,
            "ConcurrencyStamp",
            "619b54a5-a77f-439a-adcb-36fd9de5b87f");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            2,
            "ConcurrencyStamp",
            "abfe94a2-6629-4987-81e5-639014e35fda");

        migrationBuilder.CreateIndex(
            "IX_MenuItemsRestaurants_RestaurantsId",
            "MenuItemsRestaurants",
            "RestaurantsId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "MenuItemsRestaurants");

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
            "fe4d7810-da47-4a98-83f8-0bc53925eb48");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            2,
            "ConcurrencyStamp",
            "2f145c5c-b625-4790-a020-47df39cbdc42");

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
}