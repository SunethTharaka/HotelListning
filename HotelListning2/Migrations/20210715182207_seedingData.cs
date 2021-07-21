using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelListning2.Migrations
{
    public partial class seedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 1, "Sri Lanka", "SL" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 2, "Singapore", "SI" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 3, "New Zealand", "NZ" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "2, Galle Road, Kollupitiya, 00100 Colombo, Sri Lanka", 1, "Galle Face Hotel", 5.0 },
                    { 2, "1 Galle Face, Colombo 02 , 00200 Colombo, Sri Lanka", 1, "Shangri-La", 5.0 },
                    { 3, "590 Marine Drive, 00300 Colombo, Sri Lanka ", 1, "Marino Beach Colombo", 5.0 },
                    { 4, "86 East Coast Road, Katong, 428788 Singapore, Singapore", 2, "Hotel Indigo Singapore Katong", 5.0 },
                    { 5, "1 Farrer Park Station Road, Farrer Park, 217562 Singapore, Singapore", 2, "One Farrer Hotel", 5.0 },
                    { 6, "3 Upper Pickering Street, Chinatown, 058289 Singapore, Singapore", 2, "PARKROYAL COLLECTION Pickering", 5.0 },
                    { 7, "83 Symonds Street, 1140 Auckland, New Zealand", 3, "Cordis, Auckland by Langham Hospitality Group", 5.0 },
                    { 8, "58-60 Queen Street, 1001 Auckland, New Zealand ", 3, "Hotel Grand Windsor MGallery by Sofitel", 5.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
