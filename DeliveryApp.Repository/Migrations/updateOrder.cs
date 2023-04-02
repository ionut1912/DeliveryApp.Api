#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryApp.Repository.Migrations;

public partial class updateOrder : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            "FK_Orders_Restaurants_RestaurantId",
            "Orders");

        migrationBuilder.DropIndex(
            "IX_Orders_RestaurantId",
            "Orders");

        migrationBuilder.DropColumn(
            "RestaurantId",
            "Orders");

        migrationBuilder.RenameColumn(
            "ReciviedTime",
            "Orders",
            "ReceivedTime");

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
            "9a9db3ed-55f7-4fcb-92cf-cad37a9a08f3");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            2,
            "ConcurrencyStamp",
            "f335c780-0fb1-43cd-8cf8-f71751c51fbb");

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

    protected override void Down(MigrationBuilder migrationBuilder)
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

        migrationBuilder.RenameColumn(
            "ReceivedTime",
            "Orders",
            "ReciviedTime");

        migrationBuilder.AddColumn<Guid>(
            "RestaurantId",
            "Orders",
            "uniqueidentifier",
            nullable: true);

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            1,
            "ConcurrencyStamp",
            "2726a3b0-2d33-4099-b4b1-7d885b8fa981");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            2,
            "ConcurrencyStamp",
            "dc15d528-4be1-4962-a9b7-4700ec665b7b");

        migrationBuilder.CreateIndex(
            "IX_Orders_RestaurantId",
            "Orders",
            "RestaurantId");

        migrationBuilder.AddForeignKey(
            "FK_Orders_Restaurants_RestaurantId",
            "Orders",
            "RestaurantId",
            "Restaurants",
            principalColumn: "Id");
    }
}