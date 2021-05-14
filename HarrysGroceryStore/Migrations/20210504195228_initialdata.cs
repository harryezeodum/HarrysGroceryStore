using Microsoft.EntityFrameworkCore.Migrations;

namespace HarrysGroceryStore.Migrations
{
    public partial class initialdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HireDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SalesAmount = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    OrderDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "FirstName", "LastName", "PhoneNumber", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "10612 Smith Street", "Pasadena", "Genesis", "Howard", "281-789-1201", "Texas", "77786" },
                    { 2, "588 Alington Place", "Pearland", "Christian", "Walcot", "281-789-1201", "Texas", "77394" },
                    { 3, "12145 South Loop West", "Houston", "Ngozi", "Offodile", "281-213-0090", "Texas", "77092" },
                    { 4, "10612 Barker Street", "Katy", "Adaobi", "Eze", "713-356-2190", "Texas", "77492" },
                    { 5, "1239 Katy Lane #2512", "Crypress", "Tichelle", "Miller", "713-214-3345", "Texas", "77041" },
                    { 6, "10612 Holly Spring Ln", "Katy", "Christian", "Biden", "713-756-5412", "Texas", "77125" },
                    { 7, "612 Allan Street", "Houston", "Mary", "Jaden", "281-789-1854", "Texas", "77754" },
                    { 8, "1612 London Circle", "Richmond Hills", "Jude", "Oladipo", "281-451-1201", "Texas", "77203" },
                    { 9, "5647 Smith Street", "Spring", "Chioma", "Branch", "281-789-0254", "Texas", "77785" },
                    { 10, "8963 Houston Street", "Houston", "Jude", "Offodile", "281-784-8901", "Texas", "77251" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "City", "FirstName", "HireDate", "LastName", "PhoneNumber", "State", "ZipCode" },
                values: new object[,]
                {
                    { 8, "89065 Small Lan", "Cinco", "Austin", "07/01/2016", "Capstone", "281-741-1032", "Texas", "77510" },
                    { 7, "12786 Galley Lane #456", "Richmond", "Israel", "06/01/2016", "Ruiz", "713-854-8741", "Texas", "77879" },
                    { 6, "'23145 Richmond Avenue", "Sugarland", "Harry", "05/01/2016", "Porter", "281-785-7842", "Texas", "77244" },
                    { 5, "14562 Holly Spring Cir", "Cinco", "Voke", "04/01/2016", "Oluwafemi", "281-985-6675", "Texas", "77523" },
                    { 1, "2314 GrandVille Pkwy", "Sugarland", "John", "11/01/2015", "Doe", "281-216-9087", "Texas", "77201" },
                    { 3, "30213 Oliver Ln", "Crypress", "Claire", "02/01/2016", "Jonnas", "281-203-1204", "Texas", "77901" },
                    { 2, "7865 Swine Street #214", "Houston", "Michael", "12/01/2015", "Chan", "713-623-3212", "Texas", "77043" },
                    { 4, "23156 Hills Street #123", "Richmond", "Smith", "03/01/2016", "Johnson", "713-897-9087", "Texas", "77874" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "CompanyName", "ContactEmail", "ContactName", "ContactPhone" },
                values: new object[,]
                {
                    { 2, "Josh Brothers", "doyle.Judy@joshbrothers.net", "Doyle Judy", "281-453-0976" },
                    { 1, "Amingo Inc.", "cameron.harry@amingo.com", "Cameron, Harry", "713-520-2103" },
                    { 3, "Jimmy Wholesale Food", "marie.herz@jimmywholesalefood.com", "Marie, Herz", "281-745-894" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "EmployeeId", "OrderDate", "SalesAmount", "ShipAddress", "ShipCity", "ShippedDate", "State", "Zipcode" },
                values: new object[,]
                {
                    { 10006, 6, 8, "02/21/2021", 80m, "10612 Holly Spring Ln", "Katy", "02/22/2021", "Texas", "77786" },
                    { 10001, 1, 8, "02/21/2021", 50m, "10612 Smith Street", "Pasadena", "02/22/2021", "Texas", "77786" },
                    { 10007, 7, 7, "02/21/2021", 44m, "612 Allan Street", "Houston", "02/22/2021", "Texas", "77786" },
                    { 10002, 2, 7, "02/21/2021", 30m, "588 Alington Place", "Pearland", "02/22/2021", "Texas", "77786" },
                    { 10008, 8, 6, "02/21/2021", 64m, "1612 London Circle", "Richmond Hills", "02/22/2021", "Texas", "77786" },
                    { 10003, 3, 6, "02/21/2021", 40m, "12145 South Loop West", "Houston", "02/22/2021", "Texas", "77786" },
                    { 10009, 9, 5, "02/21/2021", 24m, "5647 Smith Street", "Spring", "02/22/2021", "Texas", "77786" },
                    { 10004, 4, 5, "02/21/2021", 60m, "10612 Barker Street", "Katy", "02/22/2021", "Texas", "77786" },
                    { 10005, 5, 4, "02/21/2021", 70m, "1239 Katy Lane #2512", "Crypress", "02/22/2021", "Texas", "77786" },
                    { 10010, 10, 4, "02/21/2021", 60m, "8963 Houston Street", "Houston", "02/22/2021", "Texas", "77786" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "Price", "ProductName", "SupplierId" },
                values: new object[,]
                {
                    { 13, "Pantry", 11m, "BetterBody Foods Pure Avocado Oil", 2 },
                    { 2, "Pantry", 10m, "Hawaiian Bread", 2 },
                    { 14, "Breakfast & Cereal", 9m, "Quaker Grits pack of 2", 2 },
                    { 15, "Pantry", 10m, "Barilla Classic Blue Box Pasta", 2 },
                    { 17, "Pantry", 11m, "Mahatma Enriched Extra Long Grain", 2 },
                    { 18, "Breakfast & Cereal", 8m, "Kellogg's Corn Flakes pack of 2", 2 },
                    { 5, "Beverages", 10m, "Evian Natural Spring Water", 3 },
                    { 8, "Beverages", 16m, "Vita Coco Coconut Water", 3 },
                    { 12, "Beverages", 10m, "Coffee Mate Pack of 2", 3 },
                    { 9, "Pantry", 8m, "6 Pack Hormel Compleats Spaghetti", 2 },
                    { 7, "Breakfast & Cereal", 11m, "Betty Crocker Bisquick Shake Pancakes", 2 },
                    { 6, "Pantry", 20m, "Velveeta Shells & Cheese", 2 },
                    { 10, "Breakfast & Cereal", 20m, "Butternut Mountain 100% Farm Syrup", 2 },
                    { 19, "Dairy", 13m, "Dole Fruit Bowls Variety Pack", 1 },
                    { 20, "Beverages", 15m, "Pepsi Soda (2 pack)", 3 },
                    { 4, "Snacks", 10m, "Nabisco Sweet Treats Cookie", 1 },
                    { 3, "Dairy", 20m, "H-E-B Original Apple Sauce", 1 },
                    { 1, "Snacks", 10m, "Doritos Chips", 1 },
                    { 16, "Beverages", 20m, "Ocean Spray 100% Orange Juice", 3 },
                    { 11, "Dairy", 6m, "Egg-Land Best Organic Egg", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CustomerId", "Email", "PassWord" },
                values: new object[,]
                {
                    { 10, 10, "judeoffodile@yahoo.com", "ada2020!" },
                    { 9, 9, "chioma.branch@aol.com", "ada2020!" },
                    { 8, 8, "judeoladipo@outlook.com", "ada2020!" },
                    { 7, 7, "maryjaden@outlook.com", "ada2020!" },
                    { 6, 6, "christainbiden@yahoo.com", "ada2020!" },
                    { 5, 5, "tichellemiller@aol.com", "ada2020!" },
                    { 4, 4, "adaobieze@gmail.com", "ada2020!" },
                    { 3, 3, "ngozi.Offodile@gmail.com", "ngozi2021!" },
                    { 2, 2, "christianwalcot@aol.com", "christian2005!" },
                    { 1, 1, "genesishoward@aol.com", "baller21!" }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 10001, 10001, 1, 5, 10m },
                    { 10003, 10003, 3, 2, 20m },
                    { 10004, 10004, 4, 6, 10m },
                    { 10002, 10002, 2, 3, 10m },
                    { 10006, 10006, 6, 4, 20m },
                    { 10007, 10007, 7, 4, 11m },
                    { 10009, 10009, 9, 3, 8m },
                    { 10010, 10010, 10, 3, 20m },
                    { 10005, 10005, 5, 7, 10m },
                    { 10008, 10008, 8, 4, 16m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CustomerId",
                table: "Users",
                column: "CustomerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
