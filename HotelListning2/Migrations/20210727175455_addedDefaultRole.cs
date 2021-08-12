using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelListning2.Migrations
{
    public partial class addedDefaultRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e6ba7af-4537-404a-ba5e-50dd4d276db1", "63bbbf46-b64f-4fd2-abaf-77ae3f6ed52a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "173a224d-e13e-4e13-b7ed-15072228e31e", "fa6e4b0f-70d8-408c-81df-350767a59754", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "173a224d-e13e-4e13-b7ed-15072228e31e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e6ba7af-4537-404a-ba5e-50dd4d276db1");
        }
    }
}
