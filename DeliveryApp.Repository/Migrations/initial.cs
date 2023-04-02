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
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                DateActiveFrom = table.Column<DateTime>("datetime2", nullable: false),
                DateActiveTo = table.Column<DateTime>("datetime2", nullable: false),
                Discount = table.Column<int>("int", nullable: false),
                Active = table.Column<bool>("bit", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Offers", x => x.Id); });

        migrationBuilder.CreateTable(
            "Restaurants",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                Name = table.Column<string>("nvarchar(max)", nullable: true)
            },
            constraints: table => { table.PrimaryKey("PK_Restaurants", x => x.Id); });

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
                AddressId = table.Column<Guid>("uniqueidentifier", nullable: false),
                UserId = table.Column<int>("int", nullable: false),
                Street = table.Column<string>("nvarchar(max)", nullable: true),
                Number = table.Column<string>("nvarchar(max)", nullable: true),
                City = table.Column<string>("nvarchar(max)", nullable: true),
                PostalCode = table.Column<string>("nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserAddresses", x => x.AddressId);
                table.ForeignKey(
                    "FK_UserAddresses_AspNetUsers_UserId",
                    x => x.UserId,
                    "AspNetUsers",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "UserConfigs",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                UserId = table.Column<int>("int", nullable: false),
                Username = table.Column<string>("nvarchar(max)", nullable: true),
                Weight = table.Column<float>("real", nullable: false),
                Height = table.Column<int>("int", nullable: false),
                Age = table.Column<int>("int", nullable: false),
                Sex = table.Column<string>("nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserConfigs", x => x.Id);
                table.ForeignKey(
                    "FK_UserConfigs_AspNetUsers_UserId",
                    x => x.UserId,
                    "AspNetUsers",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "Orders",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                ReciviedTime = table.Column<DateTime>("datetime2", nullable: false),
                FinalPrice = table.Column<double>("float", nullable: false),
                Status = table.Column<string>("nvarchar(max)", nullable: true),
                UserId = table.Column<int>("int", nullable: true),
                RestaurantId = table.Column<Guid>("uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Orders", x => x.Id);
                table.ForeignKey(
                    "FK_Orders_AspNetUsers_UserId",
                    x => x.UserId,
                    "AspNetUsers",
                    "Id");
                table.ForeignKey(
                    "FK_Orders_Restaurants_RestaurantId",
                    x => x.RestaurantId,
                    "Restaurants",
                    "Id");
            });

        migrationBuilder.CreateTable(
            "PhotosForRestaurant",
            table => new
            {
                Id = table.Column<string>("nvarchar(450)", nullable: false),
                Url = table.Column<string>("nvarchar(max)", nullable: true),
                IsMain = table.Column<bool>("bit", nullable: false),
                RestaurantId = table.Column<Guid>("uniqueidentifier", nullable: false),
                RestaurantsId = table.Column<Guid>("uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PhotosForRestaurant", x => x.Id);
                table.ForeignKey(
                    "FK_PhotosForRestaurant_Restaurants_RestaurantsId",
                    x => x.RestaurantsId,
                    "Restaurants",
                    "Id");
            });

        migrationBuilder.CreateTable(
            "RestaurantAddresses",
            table => new
            {
                AddressId = table.Column<Guid>("uniqueidentifier", nullable: false),
                RestaurantId = table.Column<Guid>("uniqueidentifier", nullable: false),
                Street = table.Column<string>("nvarchar(max)", nullable: true),
                Number = table.Column<string>("nvarchar(max)", nullable: true),
                City = table.Column<string>("nvarchar(max)", nullable: true),
                PostalCode = table.Column<string>("nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RestaurantAddresses", x => x.AddressId);
                table.ForeignKey(
                    "FK_RestaurantAddresses_Restaurants_RestaurantId",
                    x => x.RestaurantId,
                    "Restaurants",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ReviewForRestaurants",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                ReviewTitle = table.Column<string>("nvarchar(max)", nullable: true),
                ReviewDescription = table.Column<string>("nvarchar(max)", nullable: true),
                NumberOfStars = table.Column<int>("int", nullable: false),
                UserId = table.Column<int>("int", nullable: true),
                RestaurantsId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ReviewForRestaurants", x => x.Id);
                table.ForeignKey(
                    "FK_ReviewForRestaurants_AspNetUsers_UserId",
                    x => x.UserId,
                    "AspNetUsers",
                    "Id");
                table.ForeignKey(
                    "FK_ReviewForRestaurants_Restaurants_RestaurantsId",
                    x => x.RestaurantsId,
                    "Restaurants",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "MenuItems",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                ItemName = table.Column<string>("nvarchar(max)", nullable: true),
                Category = table.Column<string>("nvarchar(max)", nullable: true),
                Ingredients = table.Column<string>("nvarchar(max)", nullable: true),
                Price = table.Column<float>("real", nullable: false),
                Quantity = table.Column<int>("int", nullable: false),
                Active = table.Column<bool>("bit", nullable: false),
                OrdersId = table.Column<Guid>("uniqueidentifier", nullable: true),
                RestaurantsId = table.Column<Guid>("uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MenuItems", x => x.Id);
                table.ForeignKey(
                    "FK_MenuItems_Orders_OrdersId",
                    x => x.OrdersId,
                    "Orders",
                    "Id");
                table.ForeignKey(
                    "FK_MenuItems_Restaurants_RestaurantsId",
                    x => x.RestaurantsId,
                    "Restaurants",
                    "Id");
            });

        migrationBuilder.CreateTable(
            "OfferMenuItems",
            table => new
            {
                OfferId = table.Column<Guid>("uniqueidentifier", nullable: false),
                MenuItemId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OfferMenuItems", x => new { x.OfferId, x.MenuItemId });
                table.ForeignKey(
                    "FK_OfferMenuItems_MenuItems_MenuItemId",
                    x => x.MenuItemId,
                    "MenuItems",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_OfferMenuItems_Offers_OfferId",
                    x => x.OfferId,
                    "Offers",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "PhotosForMenuItem",
            table => new
            {
                Id = table.Column<string>("nvarchar(450)", nullable: false),
                Url = table.Column<string>("nvarchar(max)", nullable: true),
                IsMain = table.Column<bool>("bit", nullable: false),
                MenuItemId = table.Column<Guid>("uniqueidentifier", nullable: false),
                MenuItemsId = table.Column<Guid>("uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PhotosForMenuItem", x => x.Id);
                table.ForeignKey(
                    "FK_PhotosForMenuItem_MenuItems_MenuItemsId",
                    x => x.MenuItemsId,
                    "MenuItems",
                    "Id");
            });

        migrationBuilder.CreateTable(
            "ReviewForMenuItems",
            table => new
            {
                Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                ReviewTitle = table.Column<string>("nvarchar(max)", nullable: true),
                ReviewDescription = table.Column<string>("nvarchar(max)", nullable: true),
                NumberOfStars = table.Column<int>("int", nullable: false),
                UserId = table.Column<int>("int", nullable: true),
                MenuItemsId = table.Column<Guid>("uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ReviewForMenuItems", x => x.Id);
                table.ForeignKey(
                    "FK_ReviewForMenuItems_AspNetUsers_UserId",
                    x => x.UserId,
                    "AspNetUsers",
                    "Id");
                table.ForeignKey(
                    "FK_ReviewForMenuItems_MenuItems_MenuItemsId",
                    x => x.MenuItemsId,
                    "MenuItems",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            "AspNetRoles",
            new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            new object[] { 1, "2726a3b0-2d33-4099-b4b1-7d885b8fa981", "Member", "MEMBER" });

        migrationBuilder.InsertData(
            "AspNetRoles",
            new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            new object[] { 2, "dc15d528-4be1-4962-a9b7-4700ec665b7b", "Admin", "ADMIN" });

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
            "IX_MenuItems_OrdersId",
            "MenuItems",
            "OrdersId");

        migrationBuilder.CreateIndex(
            "IX_MenuItems_RestaurantsId",
            "MenuItems",
            "RestaurantsId");

        migrationBuilder.CreateIndex(
            "IX_OfferMenuItems_MenuItemId",
            "OfferMenuItems",
            "MenuItemId");

        migrationBuilder.CreateIndex(
            "IX_Orders_RestaurantId",
            "Orders",
            "RestaurantId");

        migrationBuilder.CreateIndex(
            "IX_Orders_UserId",
            "Orders",
            "UserId");

        migrationBuilder.CreateIndex(
            "IX_PhotosForMenuItem_MenuItemsId",
            "PhotosForMenuItem",
            "MenuItemsId");

        migrationBuilder.CreateIndex(
            "IX_PhotosForRestaurant_RestaurantsId",
            "PhotosForRestaurant",
            "RestaurantsId");

        migrationBuilder.CreateIndex(
            "IX_PhotosForUser_UsersId",
            "PhotosForUser",
            "UsersId");

        migrationBuilder.CreateIndex(
            "IX_RestaurantAddresses_RestaurantId",
            "RestaurantAddresses",
            "RestaurantId",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_ReviewForMenuItems_MenuItemsId",
            "ReviewForMenuItems",
            "MenuItemsId");

        migrationBuilder.CreateIndex(
            "IX_ReviewForMenuItems_UserId",
            "ReviewForMenuItems",
            "UserId");

        migrationBuilder.CreateIndex(
            "IX_ReviewForRestaurants_RestaurantsId",
            "ReviewForRestaurants",
            "RestaurantsId");

        migrationBuilder.CreateIndex(
            "IX_ReviewForRestaurants_UserId",
            "ReviewForRestaurants",
            "UserId");

        migrationBuilder.CreateIndex(
            "IX_UserAddresses_UserId",
            "UserAddresses",
            "UserId",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_UserConfigs_UserId",
            "UserConfigs",
            "UserId",
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
            "PhotosForRestaurant");

        migrationBuilder.DropTable(
            "PhotosForUser");

        migrationBuilder.DropTable(
            "RestaurantAddresses");

        migrationBuilder.DropTable(
            "ReviewForMenuItems");

        migrationBuilder.DropTable(
            "ReviewForRestaurants");

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