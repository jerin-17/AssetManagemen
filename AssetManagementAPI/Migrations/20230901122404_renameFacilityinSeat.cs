using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagementAPI.Migrations
{
    public partial class renameFacilityinSeat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaciityId",
                table: "Seats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FaciityId",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
