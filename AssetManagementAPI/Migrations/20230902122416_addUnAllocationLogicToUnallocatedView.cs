using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagementAPI.Migrations
{
    public partial class addUnAllocationLogicToUnallocatedView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW UnAllocatedSeat AS
                     SELECT S.SeatId,C.CityAbbr, B.BuildingAbbr, F.FloorNumber, F.FacilityAbbr , S.SeatNumber 
                     FROM Facilities F 
                     JOIN Cities C
                     ON F.CityId = C.CityId
                     JOIN Buildings B
                     ON F.BuildingId = B.BuildingId
                     JOIN Seats S
                     ON F.FacilityId = S.FacilityId AND S.EmployeeId IS NULL
                     ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                        drop view UnAllocatedSeat;
                        ");
        }
    }
}
