using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketingSystem.Migrations
{
    public partial class PointValSprintNumOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PointVals",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointVals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SprintNums",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprintNums", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PointVals",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "55", "55" },
                    { "34", "34" },
                    { "21", "21" },
                    { "13", "13" },
                    { "89", "89" },
                    { "5", "5" },
                    { "3", "3" },
                    { "2", "2" },
                    { "8", "8" }
                });

            migrationBuilder.InsertData(
                table: "SprintNums",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "9", "9" },
                    { "1", "1" },
                    { "2", "2" },
                    { "3", "3" },
                    { "4", "4" },
                    { "5", "5" },
                    { "6", "6" },
                    { "7", "7" },
                    { "8", "8" },
                    { "10", "10" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointVals");

            migrationBuilder.DropTable(
                name: "SprintNums");
        }
    }
}
