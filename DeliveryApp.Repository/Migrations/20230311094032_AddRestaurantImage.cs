using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryApp.Repository.Migrations
{
    public partial class AddRestaurantImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Orders_Ordersid",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferMenuItems_MenuItems_menuItemId",
                table: "OfferMenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferMenuItems_Offers_offerId",
                table: "OfferMenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_userId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurants_restaurantid",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantAddresses_Restaurants_restaurantId",
                table: "RestaurantAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_AspNetUsers_userId",
                table: "UserAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserConfigs_AspNetUsers_userId",
                table: "UserConfigs");

            migrationBuilder.DropTable(
                name: "PhotosForMenuItem");

            migrationBuilder.RenameColumn(
                name: "weight",
                table: "UserConfigs",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "UserConfigs",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "UserConfigs",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "sex",
                table: "UserConfigs",
                newName: "Sex");

            migrationBuilder.RenameColumn(
                name: "height",
                table: "UserConfigs",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "UserConfigs",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserConfigs",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_UserConfigs_userId",
                table: "UserConfigs",
                newName: "IX_UserConfigs_UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "UserAddresses",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "UserAddresses",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "postalCode",
                table: "UserAddresses",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "UserAddresses",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "UserAddresses",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "addressId",
                table: "UserAddresses",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddresses_userId",
                table: "UserAddresses",
                newName: "IX_UserAddresses_UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Restaurants",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "RestaurantAddresses",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "restaurantId",
                table: "RestaurantAddresses",
                newName: "RestaurantId");

            migrationBuilder.RenameColumn(
                name: "postalCode",
                table: "RestaurantAddresses",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "RestaurantAddresses",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "RestaurantAddresses",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "addressId",
                table: "RestaurantAddresses",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantAddresses_restaurantId",
                table: "RestaurantAddresses",
                newName: "IX_RestaurantAddresses_RestaurantId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Orders",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "restaurantid",
                table: "Orders",
                newName: "RestaurantId");

            migrationBuilder.RenameColumn(
                name: "reciviedTime",
                table: "Orders",
                newName: "ReciviedTime");

            migrationBuilder.RenameColumn(
                name: "finalPrice",
                table: "Orders",
                newName: "FinalPrice");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_userId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_restaurantid",
                table: "Orders",
                newName: "IX_Orders_RestaurantId");

            migrationBuilder.RenameColumn(
                name: "discount",
                table: "Offers",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "dateActiveTo",
                table: "Offers",
                newName: "DateActiveTo");

            migrationBuilder.RenameColumn(
                name: "dateActiveFrom",
                table: "Offers",
                newName: "DateActiveFrom");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "Offers",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Offers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "menuItemId",
                table: "OfferMenuItems",
                newName: "MenuItemId");

            migrationBuilder.RenameColumn(
                name: "offerId",
                table: "OfferMenuItems",
                newName: "OfferId");

            migrationBuilder.RenameIndex(
                name: "IX_OfferMenuItems_menuItemId",
                table: "OfferMenuItems",
                newName: "IX_OfferMenuItems_MenuItemId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "MenuItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "MenuItems",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "itemName",
                table: "MenuItems",
                newName: "ItemName");

            migrationBuilder.RenameColumn(
                name: "ingredients",
                table: "MenuItems",
                newName: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "MenuItems",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "MenuItems",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Ordersid",
                table: "MenuItems",
                newName: "OrdersId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "MenuItems",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_Ordersid",
                table: "MenuItems",
                newName: "IX_MenuItems_OrdersId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "UserConfigs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "UserConfigs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "RestaurantAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "RestaurantAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "RestaurantAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "RestaurantAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "PhotosForUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ingredients",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                name: "FK_MenuItems_Orders_OrdersId",
                table: "MenuItems",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferMenuItems_MenuItems_MenuItemId",
                table: "OfferMenuItems",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferMenuItems_Offers_OfferId",
                table: "OfferMenuItems",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurants_RestaurantId",
                table: "Orders",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotosForUser_MenuItems_MenuItemsId",
                table: "PhotosForUser",
                column: "MenuItemsId",
                principalTable: "MenuItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantAddresses_Restaurants_RestaurantId",
                table: "RestaurantAddresses",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_AspNetUsers_UserId",
                table: "UserAddresses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserConfigs_AspNetUsers_UserId",
                table: "UserConfigs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Orders_OrdersId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferMenuItems_MenuItems_MenuItemId",
                table: "OfferMenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferMenuItems_Offers_OfferId",
                table: "OfferMenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurants_RestaurantId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotosForUser_MenuItems_MenuItemsId",
                table: "PhotosForUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantAddresses_Restaurants_RestaurantId",
                table: "RestaurantAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_AspNetUsers_UserId",
                table: "UserAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserConfigs_AspNetUsers_UserId",
                table: "UserConfigs");

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

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "UserConfigs",
                newName: "weight");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "UserConfigs",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserConfigs",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "UserConfigs",
                newName: "sex");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "UserConfigs",
                newName: "height");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "UserConfigs",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserConfigs",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_UserConfigs_UserId",
                table: "UserConfigs",
                newName: "IX_UserConfigs_userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserAddresses",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "UserAddresses",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "UserAddresses",
                newName: "postalCode");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "UserAddresses",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "UserAddresses",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "UserAddresses",
                newName: "addressId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses",
                newName: "IX_UserAddresses_userId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Restaurants",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "RestaurantAddresses",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "RestaurantAddresses",
                newName: "restaurantId");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "RestaurantAddresses",
                newName: "postalCode");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "RestaurantAddresses",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "RestaurantAddresses",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "RestaurantAddresses",
                newName: "addressId");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantAddresses_RestaurantId",
                table: "RestaurantAddresses",
                newName: "IX_RestaurantAddresses_restaurantId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Orders",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Orders",
                newName: "restaurantid");

            migrationBuilder.RenameColumn(
                name: "ReciviedTime",
                table: "Orders",
                newName: "reciviedTime");

            migrationBuilder.RenameColumn(
                name: "FinalPrice",
                table: "Orders",
                newName: "finalPrice");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_RestaurantId",
                table: "Orders",
                newName: "IX_Orders_restaurantid");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Offers",
                newName: "discount");

            migrationBuilder.RenameColumn(
                name: "DateActiveTo",
                table: "Offers",
                newName: "dateActiveTo");

            migrationBuilder.RenameColumn(
                name: "DateActiveFrom",
                table: "Offers",
                newName: "dateActiveFrom");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Offers",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Offers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "MenuItemId",
                table: "OfferMenuItems",
                newName: "menuItemId");

            migrationBuilder.RenameColumn(
                name: "OfferId",
                table: "OfferMenuItems",
                newName: "offerId");

            migrationBuilder.RenameIndex(
                name: "IX_OfferMenuItems_MenuItemId",
                table: "OfferMenuItems",
                newName: "IX_OfferMenuItems_menuItemId");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "MenuItems",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "MenuItems",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "MenuItems",
                newName: "Ordersid");

            migrationBuilder.RenameColumn(
                name: "ItemName",
                table: "MenuItems",
                newName: "itemName");

            migrationBuilder.RenameColumn(
                name: "Ingredients",
                table: "MenuItems",
                newName: "ingredients");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "MenuItems",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "MenuItems",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MenuItems",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_OrdersId",
                table: "MenuItems",
                newName: "IX_MenuItems_Ordersid");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "UserConfigs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "sex",
                table: "UserConfigs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "street",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "postalCode",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "number",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "street",
                table: "RestaurantAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "postalCode",
                table: "RestaurantAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "number",
                table: "RestaurantAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "RestaurantAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "PhotosForUser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "restaurantid",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "itemName",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ingredients",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "category",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PhotosForMenuItem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    menuItemsid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotosForMenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotosForMenuItem_MenuItems_menuItemsid",
                        column: x => x.menuItemsid,
                        principalTable: "MenuItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f4246d9c-34f3-49d6-991c-c92040b39fd6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "92e89725-04a5-4948-a6f7-8796a8e872cc");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosForMenuItem_menuItemsid",
                table: "PhotosForMenuItem",
                column: "menuItemsid");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Orders_Ordersid",
                table: "MenuItems",
                column: "Ordersid",
                principalTable: "Orders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferMenuItems_MenuItems_menuItemId",
                table: "OfferMenuItems",
                column: "menuItemId",
                principalTable: "MenuItems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferMenuItems_Offers_offerId",
                table: "OfferMenuItems",
                column: "offerId",
                principalTable: "Offers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_userId",
                table: "Orders",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurants_restaurantid",
                table: "Orders",
                column: "restaurantid",
                principalTable: "Restaurants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantAddresses_Restaurants_restaurantId",
                table: "RestaurantAddresses",
                column: "restaurantId",
                principalTable: "Restaurants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_AspNetUsers_userId",
                table: "UserAddresses",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserConfigs_AspNetUsers_userId",
                table: "UserConfigs",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
