using Microsoft.EntityFrameworkCore.Migrations;

namespace HarrysGroceryStore.Migrations
{
    public partial class completeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "FirstName", "LastName", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { 2, "588 Alington Place", "Pearland", "Christian", "Walcot", "281-789-1201", "Texas", 10, "77394" },
                    { 3, "12145 South Loop West", "Houston", "Ngozi", "Offodile", "281-213-0090", "Texas", 11, "77092" },
                    { 4, "10612 Barker Street", "Katy", "Adaobi", "Eze", "713-356-2190", "Texas", 12, "77492" },
                    { 5, "1239 Katy Lane #2512", "Crypress", "Tichelle", "Miller", "713-214-3345", "Texas", 13, "77041" },
                    { 6, "10612 Holly Spring Ln", "Katy", "Christian", "Biden", "713-756-5412", "Texas", 14, "77125" },
                    { 7, "612 Allan Street", "Houston", "Mary", "Jaden", "281-789-1854", "Texas", 15, "77754" },
                    { 8, "1612 London Circle", "Richmond Hills", "Jude", "Oladipo", "281-451-1201", "Texas", 16, "77203" },
                    { 9, "5647 Smith Street", "Spring", "Chioma", "Branch", "281-789-0254", "Texas", 17, "77785" },
                    { 10, "8963 Houston Street", "Houston", "Jude", "Offodile", "281-784-8901", "Texas", 18, "77251" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "City", "FirstName", "HireDate", "LastName", "PhoneNumber", "State", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { 8, "89065 Small Lan", "Cinco", "Austin", "07/01/2016", "Capstone", "281-741-1032", "Texas", 8, "77510" },
                    { 7, "12786 Galley Lane #456", "Richmond", "Israel", "06/01/2016", "Ruiz", "713-854-8741", "Texas", 7, "77879" },
                    { 6, "'23145 Richmond Avenue", "Sugarland", "Harry", "05/01/2016", "Porter", "281-785-7842", "Texas", 6, "77244" },
                    { 3, "30213 Oliver Ln", "Crypress", "Claire", "02/01/2016", "Jonnas", "281-203-1204", "Texas", 3, "77901" },
                    { 4, "23156 Hills Street #123", "Richmond", "Smith", "03/01/2016", "Johnson", "713-897-9087", "Texas", 4, "77874" },
                    { 2, "7865 Swine Street #214", "Houston", "Michael", "12/01/2015", "Chan", "713-623-3212", "Texas", 2, "77043" },
                    { 5, "14562 Holly Spring Cir", "Cinco", "Voke", "04/01/2016", "Oluwafemi", "281-985-6675", "Texas", 5, "77523" }
                });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 1,
                columns: new[] { "Quantity", "UnitPrice" },
                values: new object[] { (short)5, 10m });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 8, 10008, 8, (short)4, 16m },
                    { 10, 10010, 10, (short)3, 20m },
                    { 9, 10009, 9, (short)3, 8m },
                    { 7, 10007, 7, (short)4, 11m },
                    { 3, 10003, 3, (short)2, 20m },
                    { 5, 10005, 5, (short)7, 10m },
                    { 4, 10004, 4, (short)6, 10m },
                    { 2, 10002, 2, (short)3, 10m },
                    { 6, 10006, 6, (short)4, 20m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "Price", "ProductName", "SupplierId" },
                values: new object[,]
                {
                    { 13, "Pantry", 11m, "BetterBody Foods Pure Avocado Oil", 2 },
                    { 20, "Beverages", 15m, "Pepsi Soda (2 pack)", 3 },
                    { 19, "Dairy", 13m, "Dole Fruit Bowls Variety Pack", 1 },
                    { 18, "Breakfast & Cereal", 8m, "Kellogg's Corn Flakes pack of 2", 2 },
                    { 17, "Pantry", 11m, "Mahatma Enriched Extra Long Grain", 2 },
                    { 16, "Beverages", 20m, "Ocean Spray 100% Orange Juice", 3 },
                    { 15, "Pantry", 10m, "Barilla Classic Blue Box Pasta", 2 },
                    { 14, "Breakfast & Cereal", 9m, "Quaker Grits pack of 2", 2 },
                    { 12, "Beverages", 10m, "Coffee Mate Pack of 2", 3 },
                    { 8, "Beverages", 16m, "Vita Coco Coconut Water", 3 },
                    { 10, "Breakfast & Cereal", 20m, "Butternut Mountain 100% Farm Syrup", 2 },
                    { 9, "Pantry", 8m, "6 Pack Hormel Compleats Spaghetti", 2 },
                    { 2, "Pantry", 10m, "Hawaiian Bread", 2 },
                    { 7, "Breakfast & Cereal", 11m, "Betty Crocker Bisquick Shake Pancakes", 2 },
                    { 6, "Pantry", 20m, "Velveeta Shells & Cheese", 2 },
                    { 5, "Beverages", 10m, "Evian Natural Spring Water", 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "Price", "ProductName", "SupplierId" },
                values: new object[,]
                {
                    { 4, "Snacks", 10m, "Nabisco Sweet Treats Cookie", 1 },
                    { 3, "Dairy", 20m, "H-E-B Original Apple Sauce", 1 },
                    { 11, "Dairy", 6m, "Egg-Land Best Organic Egg", 1 }
                });

            migrationBuilder.InsertData(
                table: "SalesOrders",
                columns: new[] { "OrderId", "CustomerId", "EmployeeId", "OrderDate", "OrderDetailId", "SalesAmount", "ShipAddress", "ShipCity", "ShippedDate", "State", "Zipcode" },
                values: new object[,]
                {
                    { 10010, 10, 4, "02/21/2021", 10, 60m, "8963 Houston Street", "Houston", "02/22/2021", "Texas", "77786" },
                    { 10009, 9, 5, "02/21/2021", 9, 24m, "5647 Smith Street", "Spring", "02/22/2021", "Texas", "77786" },
                    { 10008, 8, 6, "02/21/2021", 8, 64m, "1612 London Circle", "Richmond Hills", "02/22/2021", "Texas", "77786" },
                    { 10007, 7, 7, "02/21/2021", 7, 44m, "612 Allan Street", "Houston", "02/22/2021", "Texas", "77786" },
                    { 10005, 5, 4, "02/21/2021", 5, 70m, "1239 Katy Lane #2512", "Crypress", "02/22/2021", "Texas", "77786" },
                    { 10004, 4, 5, "02/21/2021", 4, 60m, "10612 Barker Street", "Katy", "02/22/2021", "Texas", "77786" },
                    { 10003, 3, 6, "02/21/2021", 3, 40m, "12145 South Loop West", "Houston", "02/22/2021", "Texas", "77786" },
                    { 10002, 2, 7, "02/21/2021", 2, 30m, "588 Alington Place", "Pearland", "02/22/2021", "Texas", "77786" },
                    { 10006, 6, 8, "02/21/2021", 6, 80m, "10612 Holly Spring Ln", "Katy", "02/22/2021", "Texas", "77786" }
                });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 1,
                column: "ContactName",
                value: "Cameron, Harry");

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "CompanyName", "ContactEmail", "ContactName", "ContactPhone" },
                values: new object[,]
                {
                    { 2, "Josh Brothers", "doyle.Judy@joshbrothers.net", "Doyle Judy", "281-453-0976" },
                    { 3, "Jimmy Wholesale Food", "marie.herz@jimmywholesalefood.com", "Marie, Herz", "281-745-894" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12,
                column: "Email",
                value: "adaobieze@gmail.com");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "PassWord" },
                values: new object[,]
                {
                    { 13, "tichellemiller@aol.com", "ada2020!" },
                    { 14, "christainbiden@yahoo.com", "ada2020!" },
                    { 15, "maryjaden@outlook.com", "ada2020!" },
                    { 16, "judeoladipo@outlook.com", "ada2020!" },
                    { 17, "chioma.branch@aol.com", "ada2020!" },
                    { 18, "judeoffodile@yahoo.com", "ada2020!" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SalesOrders",
                keyColumn: "OrderId",
                keyValue: 10002);

            migrationBuilder.DeleteData(
                table: "SalesOrders",
                keyColumn: "OrderId",
                keyValue: 10003);

            migrationBuilder.DeleteData(
                table: "SalesOrders",
                keyColumn: "OrderId",
                keyValue: 10004);

            migrationBuilder.DeleteData(
                table: "SalesOrders",
                keyColumn: "OrderId",
                keyValue: 10005);

            migrationBuilder.DeleteData(
                table: "SalesOrders",
                keyColumn: "OrderId",
                keyValue: 10006);

            migrationBuilder.DeleteData(
                table: "SalesOrders",
                keyColumn: "OrderId",
                keyValue: 10007);

            migrationBuilder.DeleteData(
                table: "SalesOrders",
                keyColumn: "OrderId",
                keyValue: 10008);

            migrationBuilder.DeleteData(
                table: "SalesOrders",
                keyColumn: "OrderId",
                keyValue: 10009);

            migrationBuilder.DeleteData(
                table: "SalesOrders",
                keyColumn: "OrderId",
                keyValue: 10010);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 1,
                columns: new[] { "Quantity", "UnitPrice" },
                values: new object[] { (short)4, 25m });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 1,
                column: "ContactName",
                value: "Cameron Harry");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12,
                column: "Email",
                value: "adaobieze@yahoo.com");
        }
    }
}
