#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryApp.Repository.Migrations;

public partial class modifyMenuItems : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "OrderMenuItem");

        migrationBuilder.CreateTable(
            "MenuItemsOrders",
            table => new
            {
                MenuItemsId = table.Column<Guid>("uniqueidentifier", nullable: false),
                OrdersId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MenuItemsOrders", x => new { x.MenuItemsId, x.OrdersId });
                table.ForeignKey(
                    "FK_MenuItemsOrders_MenuItems_MenuItemsId",
                    x => x.MenuItemsId,
                    "MenuItems",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_MenuItemsOrders_Orders_OrdersId",
                    x => x.OrdersId,
                    "Orders",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            1,
            "ConcurrencyStamp",
            "df19313d-4bfd-49d6-a464-1d9efceb3cb7");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            2,
            "ConcurrencyStamp",
            "9a7976ae-6e4a-4858-9285-09d5a0e976bb");

        migrationBuilder.CreateIndex(
            "IX_MenuItemsOrders_OrdersId",
            "MenuItemsOrders",
            "OrdersId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "MenuItemsOrders");

        migrationBuilder.CreateTable(
            "OrderMenuItem",
            table => new
            {
                OrderId = table.Column<Guid>("uniqueidentifier", nullable: false),
                MenuItemId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OrderMenuItem", x => new { x.OrderId, x.MenuItemId });
                table.ForeignKey(
                    "FK_OrderMenuItem_MenuItems_MenuItemId",
                    x => x.MenuItemId,
                    "MenuItems",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_OrderMenuItem_Orders_OrderId",
                    x => x.OrderId,
                    "Orders",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            1,
            "ConcurrencyStamp",
            "893d7e64-2b75-4fef-bfcc-0c5916c4c71c");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            2,
            "ConcurrencyStamp",
            "df508db8-0f0c-438d-a794-d71ffb14cd14");

        migrationBuilder.CreateIndex(
            "IX_OrderMenuItem_MenuItemId",
            "OrderMenuItem",
            "MenuItemId");
    }
}