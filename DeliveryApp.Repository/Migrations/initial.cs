#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryApp.Repository.Migrations;

public partial class initial : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "AspNetRoles",
            table => new
            {
                Id = table.Column<int>("int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedName = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                ConcurrencyStamp = table.Column<string>("nvarchar(max)", nullable: true)
            },
            constraints: table => { table.PrimaryKey("PK_AspNetRoles", x => x.Id); });

        migrationBuilder.CreateTable(
            "AspNetUsers",
            table => new
            {
                Id = table.Column<int>("int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                UserName = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedUserName = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                Email = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedEmail = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                EmailConfirmed = table.Column<bool>("bit", nullable: false),
                PasswordHash = table.Column<string>("nvarchar(max)", nullable: true),
                SecurityStamp = table.Column<string>("nvarchar(max)", nullable: true),
                ConcurrencyStamp = table.Column<string>("nvarchar(max)", nullable: true),
                PhoneNumber = table.Column<string>("nvarchar(max)", nullable: true),
                PhoneNumberConfirmed = table.Column<bool>("bit", nullable: false),
                TwoFactorEnabled = table.Column<bool>("bit", nullable: false),
                LockoutEnd = table.Column<DateTimeOffset>("datetimeoffset", nullable: true),
                LockoutEnabled = table.Column<bool>("bit", nullable: false),
                AccessFailedCount = table.Column<int>("int", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_AspNetUsers", x => x.Id); });

        migrationBuilder.CreateTable(
            "Offers",
            table => new
            {
                id = table.Column<Guid>("uniqueidentifier", nullable: false),
                dateActiveFrom = table.Column<DateTime>("datetime2", nullable: false),
                dateActiveTo = table.Column<DateTime>("datetime2", nullable: false),
                discount = table.Column<int>("int", nullable: false),
                active = table.Column<bool>("bit", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Offers", x => x.id); });

        migrationBuilder.CreateTable(
            "Restaurants",
            table => new
            {
                id = table.Column<Guid>("uniqueidentifier", nullable: false),
                Name = table.Column<string>("nvarchar(max)", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Restaurants", x => x.id); });

        migrationBuilder.CreateTable(
            "AspNetRoleClaims",
            table => new
            {
                Id = table.Column<int>("int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                RoleId = table.Column<int>("int", nullable: false),
                ClaimType = table.Column<string>("nvarchar(max)", nullable: true),
                ClaimValue = table.Column<string>("nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                table.ForeignKey(
                    "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                    x => x.RoleId,
                    "AspNetRoles",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "AspNetUserClaims",
            table => new
            {
                Id = table.Column<int>("int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                UserId = table.Column<int>("int", nullable: false),
                ClaimType = table.Column<string>("nvarchar(max)", nullable: true),
                ClaimValue = table.Column<string>("nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                table.ForeignKey(
                    "FK_AspNetUserClaims_AspNetUsers_UserId",
                    x => x.UserId,
                    "AspNetUsers",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "AspNetUserLogins",
            table => new
            {
                LoginProvider = table.Column<string>("nvarchar(450)", nullable: false),
                ProviderKey = table.Column<string>("nvarchar(450)", nullable: false),
                ProviderDisplayName = table.Column<string>("nvarchar(max)", nullable: true),
                UserId = table.Column<int>("int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                table.ForeignKey(
                    "FK_AspNetUserLogins_AspNetUsers_UserId",
                    x => x.UserId,
                    "AspNetUsers",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "AspNetUserRoles",
            table => new
            {
                UserId = table.Column<int>("int", nullable: false),
                RoleId = table.Column<int>("int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                table.ForeignKey(
                    "FK_AspNetUserRoles_AspNetRoles_RoleId",
                    x => x.RoleId,
                    "AspNetRoles",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_AspNetUserRoles_AspNetUsers_UserId",
                    x => x.UserId,
                    "AspNetUsers",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "AspNetUserTokens",
            table => new
            {
                UserId = table.Column<int>("int", nullable: false),
                LoginProvider = table.Column<string>("nvarchar(450)", nullable: false),
                Name = table.Column<string>("nvarchar(450)", nullable: false),
                Value = table.Column<string>("nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                table.ForeignKey(
                    "FK_AspNetUserTokens_AspNetUsers_UserId",
                    x => x.UserId,
                    "AspNetUsers",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "PhotosForUser",
            table => new
            {
                Id = table.Column<string>("nvarchar(450)", nullable: false),
                Url = table.Column<string>("nvarchar(max)", nullable: true),
                IsMain = table.Column<bool>("bit", nullable: false),
                UsersId = table.Column<int>("int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PhotosForUser", x => x.Id);
                table.ForeignKey(
                    "FK_PhotosForUser_AspNetUsers_UsersId",
                    x => x.UsersId,
                    "AspNetUsers",
                    "Id");
            });

        migrationBuilder.CreateTable(
            "UserAddresses",
            table => new
            {
                addressId = table.Column<Guid>("uniqueidentifier", nullable: false),
                userId = table.Column<int>("int", nullable: false),
                street = table.Column<string>("nvarchar(max)", nullable: false),
                number = table.Column<string>("nvarchar(max)", nullable: false),
                city = table.Column<string>("nvarchar(max)", nullable: false),
                postalCode = table.Column<string>("nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserAddresses", x => x.addressId);
                table.ForeignKey(
                    "FK_UserAddresses_AspNetUsers_userId",
                    x => x.userId,
                    "AspNetUsers",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "UserConfigs",
            table => new
            {
                id = table.Column<Guid>("uniqueidentifier", nullable: false),
                userId = table.Column<int>("int", nullable: false),
                username = table.Column<string>("nvarchar(max)", nullable: false),
                weight = table.Column<float>("real", nullable: false),
                height = table.Column<int>("int", nullable: false),
                age = table.Column<int>("int", nullable: false),
                sex = table.Column<string>("nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserConfigs", x => x.id);
                table.ForeignKey(
                    "FK_UserConfigs_AspNetUsers_userId",
                    x => x.userId,
                    "AspNetUsers",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "Orders",
            table => new
            {
                id = table.Column<Guid>("uniqueidentifier", nullable: false),
                reciviedTime = table.Column<DateTime>("datetime2", nullable: false),
                finalPrice = table.Column<float>("real", nullable: false),
                status = table.Column<string>("nvarchar(max)", nullable: false),
                userId = table.Column<int>("int", nullable: false),
                restaurantid = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Orders", x => x.id);
                table.ForeignKey(
                    "FK_Orders_AspNetUsers_userId",
                    x => x.userId,
                    "AspNetUsers",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_Orders_Restaurants_restaurantid",
                    x => x.restaurantid,
                    "Restaurants",
                    "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "RestaurantAddresses",
            table => new
            {
                addressId = table.Column<Guid>("uniqueidentifier", nullable: false),
                restaurantId = table.Column<Guid>("uniqueidentifier", nullable: false),
                street = table.Column<string>("nvarchar(max)", nullable: false),
                number = table.Column<string>("nvarchar(max)", nullable: false),
                city = table.Column<string>("nvarchar(max)", nullable: false),
                postalCode = table.Column<string>("nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RestaurantAddresses", x => x.addressId);
                table.ForeignKey(
                    "FK_RestaurantAddresses_Restaurants_restaurantId",
                    x => x.restaurantId,
                    "Restaurants",
                    "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "MenuItems",
            table => new
            {
                id = table.Column<Guid>("uniqueidentifier", nullable: false),
                itemName = table.Column<string>("nvarchar(max)", nullable: false),
                category = table.Column<string>("nvarchar(max)", nullable: false),
                ingredients = table.Column<string>("nvarchar(max)", nullable: false),
                price = table.Column<float>("real", nullable: false),
                quantity = table.Column<int>("int", nullable: false),
                active = table.Column<bool>("bit", nullable: false),
                Ordersid = table.Column<Guid>("uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MenuItems", x => x.id);
                table.ForeignKey(
                    "FK_MenuItems_Orders_Ordersid",
                    x => x.Ordersid,
                    "Orders",
                    "id");
            });

        migrationBuilder.CreateTable(
            "OfferMenuItems",
            table => new
            {
                offerId = table.Column<Guid>("uniqueidentifier", nullable: false),
                menuItemId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OfferMenuItems", x => new { x.offerId, x.menuItemId });
                table.ForeignKey(
                    "FK_OfferMenuItems_MenuItems_menuItemId",
                    x => x.menuItemId,
                    "MenuItems",
                    "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_OfferMenuItems_Offers_offerId",
                    x => x.offerId,
                    "Offers",
                    "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "PhotosForMenuItem",
            table => new
            {
                Id = table.Column<string>("nvarchar(450)", nullable: false),
                Url = table.Column<string>("nvarchar(max)", nullable: false),
                IsMain = table.Column<bool>("bit", nullable: false),
                menuItemsid = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PhotosForMenuItem", x => x.Id);
                table.ForeignKey(
                    "FK_PhotosForMenuItem_MenuItems_menuItemsid",
                    x => x.menuItemsid,
                    "MenuItems",
                    "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            "AspNetRoles",
            new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            new object[] { 1, "f4246d9c-34f3-49d6-991c-c92040b39fd6", "Member", "MEMBER" });

        migrationBuilder.InsertData(
            "AspNetRoles",
            new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            new object[] { 2, "92e89725-04a5-4948-a6f7-8796a8e872cc", "Admin", "ADMIN" });

        migrationBuilder.CreateIndex(
            "IX_AspNetRoleClaims_RoleId",
            "AspNetRoleClaims",
            "RoleId");

        migrationBuilder.CreateIndex(
            "RoleNameIndex",
            "AspNetRoles",
            "NormalizedName",
            unique: true,
            filter: "[NormalizedName] IS NOT NULL");

        migrationBuilder.CreateIndex(
            "IX_AspNetUserClaims_UserId",
            "AspNetUserClaims",
            "UserId");

        migrationBuilder.CreateIndex(
            "IX_AspNetUserLogins_UserId",
            "AspNetUserLogins",
            "UserId");

        migrationBuilder.CreateIndex(
            "IX_AspNetUserRoles_RoleId",
            "AspNetUserRoles",
            "RoleId");

        migrationBuilder.CreateIndex(
            "EmailIndex",
            "AspNetUsers",
            "NormalizedEmail");

        migrationBuilder.CreateIndex(
            "UserNameIndex",
            "AspNetUsers",
            "NormalizedUserName",
            unique: true,
            filter: "[NormalizedUserName] IS NOT NULL");

        migrationBuilder.CreateIndex(
            "IX_MenuItems_Ordersid",
            "MenuItems",
            "Ordersid");

        migrationBuilder.CreateIndex(
            "IX_OfferMenuItems_menuItemId",
            "OfferMenuItems",
            "menuItemId");

        migrationBuilder.CreateIndex(
            "IX_Orders_restaurantid",
            "Orders",
            "restaurantid");

        migrationBuilder.CreateIndex(
            "IX_Orders_userId",
            "Orders",
            "userId");

        migrationBuilder.CreateIndex(
            "IX_PhotosForMenuItem_menuItemsid",
            "PhotosForMenuItem",
            "menuItemsid");

        migrationBuilder.CreateIndex(
            "IX_PhotosForUser_UsersId",
            "PhotosForUser",
            "UsersId");

        migrationBuilder.CreateIndex(
            "IX_RestaurantAddresses_restaurantId",
            "RestaurantAddresses",
            "restaurantId",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_UserAddresses_userId",
            "UserAddresses",
            "userId",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_UserConfigs_userId",
            "UserConfigs",
            "userId",
            unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "AspNetRoleClaims");

        migrationBuilder.DropTable(
            "AspNetUserClaims");

        migrationBuilder.DropTable(
            "AspNetUserLogins");

        migrationBuilder.DropTable(
            "AspNetUserRoles");

        migrationBuilder.DropTable(
            "AspNetUserTokens");

        migrationBuilder.DropTable(
            "OfferMenuItems");

        migrationBuilder.DropTable(
            "PhotosForMenuItem");

        migrationBuilder.DropTable(
            "PhotosForUser");

        migrationBuilder.DropTable(
            "RestaurantAddresses");

        migrationBuilder.DropTable(
            "UserAddresses");

        migrationBuilder.DropTable(
            "UserConfigs");

        migrationBuilder.DropTable(
            "AspNetRoles");

        migrationBuilder.DropTable(
            "Offers");

        migrationBuilder.DropTable(
            "MenuItems");

        migrationBuilder.DropTable(
            "Orders");

        migrationBuilder.DropTable(
            "AspNetUsers");

        migrationBuilder.DropTable(
            "Restaurants");
    }
}