using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryApp.Repository.Migrations
{
    public partial class addOrderToMenuItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Orders_OrdersId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_OrdersId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "MenuItems");

            migrationBuilder.CreateTable(
                name: "MenuItemsOrders",
                columns: table => new
                {
                    MenuItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemsOrders", x => new { x.MenuItemsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_MenuItemsOrders_MenuItems_MenuItemsId",
                        column: x => x.MenuItemsId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemsOrders_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a6566c79-8ca0-40eb-b1a4-f5addb5d0543");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7056883c-7e94-469f-9ce3-7e1df7711a31");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemsOrders_OrdersId",
                table: "MenuItemsOrders",
                column: "OrdersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItemsOrders");

            migrationBuilder.AddColumn<Guid>(
                name: "OrdersId",
                table: "MenuItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d4d2c455-1c3a-409f-819a-7e3144f37722");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d588dc2a-830e-469a-8fd6-4c2e635df142");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_OrdersId",
                table: "MenuItems",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Orders_OrdersId",
                table: "MenuItems",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
