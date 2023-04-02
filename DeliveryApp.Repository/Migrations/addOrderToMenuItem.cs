#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryApp.Repository.Migrations;

public partial class addOrderToMenuItem : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            "FK_MenuItems_Orders_OrdersId",
            "MenuItems");

        migrationBuilder.DropIndex(
            "IX_MenuItems_OrdersId",
            "MenuItems");

        migrationBuilder.DropColumn(
            "OrdersId",
            "MenuItems");

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
            "a6566c79-8ca0-40eb-b1a4-f5addb5d0543");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            2,
            "ConcurrencyStamp",
            "7056883c-7e94-469f-9ce3-7e1df7711a31");

        migrationBuilder.CreateIndex(
            "IX_MenuItemsOrders_OrdersId",
            "MenuItemsOrders",
            "OrdersId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "MenuItemsOrders");

        migrationBuilder.AddColumn<Guid>(
            "OrdersId",
            "MenuItems",
            "uniqueidentifier",
            nullable: true);

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            1,
            "ConcurrencyStamp",
            "d4d2c455-1c3a-409f-819a-7e3144f37722");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            2,
            "ConcurrencyStamp",
            "d588dc2a-830e-469a-8fd6-4c2e635df142");

        migrationBuilder.CreateIndex(
            "IX_MenuItems_OrdersId",
            "MenuItems",
            "OrdersId");

        migrationBuilder.AddForeignKey(
            "FK_MenuItems_Orders_OrdersId",
            "MenuItems",
            "OrdersId",
            "Orders",
            principalColumn: "Id");
    }
}