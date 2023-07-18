using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentReview.Data.Migrations
{
    public partial class Removedtenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Reviews",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reviews",
                newName: "TenantId");

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });
        }
    }
}
