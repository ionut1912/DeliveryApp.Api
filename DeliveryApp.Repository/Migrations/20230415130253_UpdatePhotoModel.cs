using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryApp.Repository.Migrations
{
    public partial class UpdatePhotoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotosForRestaurant_Restaurants_RestaurantsId",
                table: "PhotosForRestaurant");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "PhotosForRestaurant");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantsId",
                table: "PhotosForRestaurant",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "72ef480c-ff43-4e4c-a050-fd0473745e2a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "08d0f139-e7fa-44a3-a73b-29209ef95982");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotosForRestaurant_Restaurants_RestaurantsId",
                table: "PhotosForRestaurant",
                column: "RestaurantsId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotosForRestaurant_Restaurants_RestaurantsId",
                table: "PhotosForRestaurant");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantsId",
                table: "PhotosForRestaurant",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "PhotosForRestaurant",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "619b54a5-a77f-439a-adcb-36fd9de5b87f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "abfe94a2-6629-4987-81e5-639014e35fda");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotosForRestaurant_Restaurants_RestaurantsId",
                table: "PhotosForRestaurant",
                column: "RestaurantsId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }
    }
}
