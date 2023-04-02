#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryApp.Repository.Migrations;

public partial class addOrderToUser : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
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
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            1,
            "ConcurrencyStamp",
            "9a9db3ed-55f7-4fcb-92cf-cad37a9a08f3");

        migrationBuilder.UpdateData(
            "AspNetRoles",
            "Id",
            2,
            "ConcurrencyStamp",
            "f335c780-0fb1-43cd-8cf8-f71751c51fbb");
    }
}