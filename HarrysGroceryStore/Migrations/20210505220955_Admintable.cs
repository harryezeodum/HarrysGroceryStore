using Microsoft.EntityFrameworkCore.Migrations;

namespace HarrysGroceryStore.Migrations
{
    public partial class Admintable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Admins_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "Email", "EmployeeId", "PassWord" },
                values: new object[,]
                {
                    { 1, "johndoe@aol.com", 1, "baller21!" },
                    { 2, "michaelchan@aol.com", 2, "christian2005!" },
                    { 3, "clairejonnas@gmail.com", 3, "ngozi2021!" },
                    { 4, "smith.johnson@gmail.com", 4, "ada2020!" },
                    { 5, "vokeoluwafemi@aol.com", 5, "ada2020!" },
                    { 6, "harryporter@yahoo.com", 6, "ada2020!" },
                    { 7, "israelruiz@outlook.com", 7, "ada2020!" },
                    { 8, "austin.capstone@outlook.com", 8, "ada2020!" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Email",
                table: "Admins",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_EmployeeId",
                table: "Admins",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
