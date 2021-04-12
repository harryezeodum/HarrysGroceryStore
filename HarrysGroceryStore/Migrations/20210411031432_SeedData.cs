using Microsoft.EntityFrameworkCore.Migrations;

namespace HarrysGroceryStore.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConfirmPassword", "Email", "FirstName", "LastName", "PassWord", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "John2020!", "john.doe@aol.com", "John", "Doe", "John2020!", "7134021336" },
                    { 2, "Mike2020!", "michael.chan@gmail.com", "Michael", "Chan", "Mike2020!", "7135243201" },
                    { 3, "beauty", "claire4real@aol.com", "Clarie", "Ramirez", "beauty", "7134278974" },
                    { 4, "smitty1989!", "smithJohnson@outlook.com.com", "Smith", "Johnson", "smitty1989!", "2105412031" },
                    { 5, "voke1900!", "voke.oluwafemi@aol.com", "Voke", "Oluwafemi", "voke1900!", "7138795214" },
                    { 6, "Porterisgood!", "harryporter@aol.com", "Harry", "Porter", "Porterisgood!", "7137852140" },
                    { 7, "Realsoccer!", "israelruiz@yahoo.com", "Israel", "Ruiz", "Realsoccer!", "7133020145" },
                    { 8, "capstone!", "austin.capstone@outlook.com", "Austin", "Capstone", "capstone!", "2103625479" },
                    { 9, "baller21!", "genesishoward@aol.com", "Genesis", "Howard", "baller21!", "2104021336" },
                    { 10, "christian2005!", "christianwalcot@aol.com", "Christian", "Walcot", "christian2005!", "7134025241" },
                    { 11, "ngozi2021!", "ngozi.Offodile@gmail.com", "Ngozi", "Offodile", "ngozi2021!", "7134042035" },
                    { 12, "ada2020!", "adaobieze@yahoo.com", "Adaobi", "Chukwueze", "ada2020!", "2104021336" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12);
        }
    }
}
