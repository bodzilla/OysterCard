using Microsoft.EntityFrameworkCore.Migrations;

namespace OysterCard.Persistence.Migrations
{
    public partial class AddVerifiedToOystersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "Oysters",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Verified",
                table: "Oysters");
        }
    }
}
