using Microsoft.EntityFrameworkCore.Migrations;

namespace OysterCard.Persistence.Migrations
{
    public partial class RemoveVerifiedAndAddOysterStateToOystersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Verified",
                table: "Oysters");

            migrationBuilder.AddColumn<int>(
                name: "OysterState",
                table: "Oysters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OysterState",
                table: "Oysters");

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "Oysters",
                nullable: false,
                defaultValue: false);
        }
    }
}
