using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryApp.Repository.Migrations
{
    public partial class updateOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurants_RestaurantId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RestaurantId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ReciviedTime",
                table: "Orders",
                newName: "ReceivedTime");

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
                value: "9a9db3ed-55f7-4fcb-92cf-cad37a9a08f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f335c780-0fb1-43cd-8cf8-f71751c51fbb");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ReceivedTime",
                table: "Orders",
                newName: "ReciviedTime");

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "2726a3b0-2d33-4099-b4b1-7d885b8fa981");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "dc15d528-4be1-4962-a9b7-4700ec665b7b");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RestaurantId",
                table: "Orders",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurants_RestaurantId",
                table: "Orders",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }
    }
}
