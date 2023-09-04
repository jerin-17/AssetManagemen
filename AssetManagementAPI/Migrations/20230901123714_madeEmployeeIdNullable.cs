using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagementAPI.Migrations
{
    public partial class madeEmployeeIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Employees_EmployeeId",
                table: "Seats");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Seats",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Employees_EmployeeId",
                table: "Seats",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Employees_EmployeeId",
                table: "Seats");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Employees_EmployeeId",
                table: "Seats",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
