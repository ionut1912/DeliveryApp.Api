using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryApp.Repository.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotosForUser_MenuItems_MenuItemsId",
                table: "PhotosForUser");

            migrationBuilder.DropIndex(
                name: "IX_PhotosForUser_MenuItemsId",
                table: "PhotosForUser");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "PhotosForUser");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "PhotosForUser");

            migrationBuilder.DropColumn(
                name: "MenuItemsId",
                table: "PhotosForUser");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "PhotosForUser");

            migrationBuilder.CreateTable(
                name: "PhotosForMenuItem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    MenuItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotosForMenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotosForMenuItem_MenuItems_MenuItemsId",
                        column: x => x.MenuItemsId,
                        principalTable: "MenuItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantPhotos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantPhotos", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "aaf5e15a-8875-4874-b974-52c9b7b76728");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "6e534def-ff58-464d-b336-fa93d9213535");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosForMenuItem_MenuItemsId",
                table: "PhotosForMenuItem",
                column: "MenuItemsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotosForMenuItem");

            migrationBuilder.DropTable(
                name: "RestaurantPhotos");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "PhotosForUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "MenuItemId",
                table: "PhotosForUser",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MenuItemsId",
                table: "PhotosForUser",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "PhotosForUser",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d6c49717-0bb1-4dc0-ab8c-b60a51679c70");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "15b702c3-30f3-4c5b-869c-7e4d287abe3f");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosForUser_MenuItemsId",
                table: "PhotosForUser",
                column: "MenuItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotosForUser_MenuItems_MenuItemsId",
                table: "PhotosForUser",
                column: "MenuItemsId",
                principalTable: "MenuItems",
                principalColumn: "Id");
        }
    }
}
