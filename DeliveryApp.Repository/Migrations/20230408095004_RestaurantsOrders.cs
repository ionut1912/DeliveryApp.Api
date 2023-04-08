using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryApp.Repository.Migrations
{
    public partial class RestaurantsOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Orders_OrdersId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_OrdersId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "Restaurants");

            migrationBuilder.CreateTable(
                name: "OrdersRestaurants",
                columns: table => new
                {
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersRestaurants", x => new { x.OrdersId, x.RestaurantsId });
                    table.ForeignKey(
                        name: "FK_OrdersRestaurants_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersRestaurants_Restaurants_RestaurantsId",
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
                value: "fe4d7810-da47-4a98-83f8-0bc53925eb48");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "2f145c5c-b625-4790-a020-47df39cbdc42");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersRestaurants_RestaurantsId",
                table: "OrdersRestaurants",
                column: "RestaurantsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersRestaurants");

            migrationBuilder.AddColumn<Guid>(
                name: "OrdersId",
                table: "Restaurants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b460f9d6-d4a1-411d-a1f1-216f20eb41a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f05b568d-70fc-4324-b683-7ab0dfa732c0");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_OrdersId",
                table: "Restaurants",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Orders_OrdersId",
                table: "Restaurants",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
