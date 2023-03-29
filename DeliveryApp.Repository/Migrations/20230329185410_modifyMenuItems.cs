using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryApp.Repository.Migrations
{
    public partial class modifyMenuItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderMenuItem");

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
                value: "df19313d-4bfd-49d6-a464-1d9efceb3cb7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9a7976ae-6e4a-4858-9285-09d5a0e976bb");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemsOrders_OrdersId",
                table: "MenuItemsOrders",
                column: "OrdersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItemsOrders");

            migrationBuilder.CreateTable(
                name: "OrderMenuItem",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMenuItem", x => new { x.OrderId, x.MenuItemId });
                    table.ForeignKey(
                        name: "FK_OrderMenuItem_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderMenuItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "893d7e64-2b75-4fef-bfcc-0c5916c4c71c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "df508db8-0f0c-438d-a794-d71ffb14cd14");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenuItem_MenuItemId",
                table: "OrderMenuItem",
                column: "MenuItemId");
        }
    }
}
