using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagementAPI.Migrations
{
    public partial class onCascadeSetNullToEmployeeIdInSeat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Employees_EmployeeId",
                table: "Seats");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Employees_EmployeeId",
                table: "Seats",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Employees_EmployeeId",
                table: "Seats");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Employees_EmployeeId",
                table: "Seats",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }
    }
}
