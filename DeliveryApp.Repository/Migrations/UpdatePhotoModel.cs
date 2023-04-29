#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryApp.Repository.Migrations;

public partial class UpdatePhotoModel : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            "FK_PhotosForRestaurant_Restaurants_RestaurantsId",
            "PhotosForRestaurant");

        migrationBuilder.DropColumn(
            "RestaurantId",
            "PhotosForRestaurant");

        migrationBuilder.AlterColumn<Guid>(
            "RestaurantsId",
            "PhotosForRestaurant",
            "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier",
            oldNullable: true);

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            1,
            "ConcurrencyStamp",
            "72ef480c-ff43-4e4c-a050-fd0473745e2a");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            2,
            "ConcurrencyStamp",
            "08d0f139-e7fa-44a3-a73b-29209ef95982");

        migrationBuilder.AddForeignKey(
            "FK_PhotosForRestaurant_Restaurants_RestaurantsId",
            "PhotosForRestaurant",
            "RestaurantsId",
            "Restaurants",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            "FK_PhotosForRestaurant_Restaurants_RestaurantsId",
            "PhotosForRestaurant");

        migrationBuilder.AlterColumn<Guid>(
            "RestaurantsId",
            "PhotosForRestaurant",
            "uniqueidentifier",
            nullable: true,
            oldClrType: typeof(Guid),
            oldType: "uniqueidentifier");

        migrationBuilder.AddColumn<Guid>(
            "RestaurantId",
            "PhotosForRestaurant",
            "uniqueidentifier",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            1,
            "ConcurrencyStamp",
            "619b54a5-a77f-439a-adcb-36fd9de5b87f");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            2,
            "ConcurrencyStamp",
            "abfe94a2-6629-4987-81e5-639014e35fda");

        migrationBuilder.AddForeignKey(
            "FK_PhotosForRestaurant_Restaurants_RestaurantsId",
            "PhotosForRestaurant",
            "RestaurantsId",
            "Restaurants",
            principalColumn: "Id");
    }
}