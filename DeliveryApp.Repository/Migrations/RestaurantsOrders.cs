#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryApp.Repository.Migrations;

public partial class RestaurantsOrders : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            "FK_Restaurants_Orders_OrdersId",
            "Restaurants");

        migrationBuilder.DropIndex(
            "IX_Restaurants_OrdersId",
            "Restaurants");

        migrationBuilder.DropColumn(
            "OrdersId",
            "Restaurants");

        migrationBuilder.CreateTable(
            "OrdersRestaurants",
            table => new
            {
                OrdersId = table.Column<Guid>("uniqueidentifier", nullable: false),
                RestaurantsId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OrdersRestaurants", x => new { x.OrdersId, x.RestaurantsId });
                table.ForeignKey(
                    "FK_OrdersRestaurants_Orders_OrdersId",
                    x => x.OrdersId,
                    "Orders",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_OrdersRestaurants_Restaurants_RestaurantsId",
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
            "fe4d7810-da47-4a98-83f8-0bc53925eb48");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            2,
            "ConcurrencyStamp",
            "2f145c5c-b625-4790-a020-47df39cbdc42");

        migrationBuilder.CreateIndex(
            "IX_OrdersRestaurants_RestaurantsId",
            "OrdersRestaurants",
            "RestaurantsId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "OrdersRestaurants");

        migrationBuilder.AddColumn<Guid>(
            "OrdersId",
            "Restaurants",
            "uniqueidentifier",
            nullable: true);

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

        migrationBuilder.CreateIndex(
            "IX_Restaurants_OrdersId",
            "Restaurants",
            "OrdersId");

        migrationBuilder.AddForeignKey(
            "FK_Restaurants_Orders_OrdersId",
            "Restaurants",
            "OrdersId",
            "Orders",
            principalColumn: "Id");
    }
}