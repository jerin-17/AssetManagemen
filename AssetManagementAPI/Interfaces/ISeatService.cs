using AssetManagementAPI.DTO;
using AssetManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementAPI.Interfaces
{
    public interface ISeatService
    {
        List<Seat> GetSeats();
        int CreateSeat(SeatDTO seat);

        void AllocateSeat(int SeatId,int employeeId);
        void DeallocateSeat(int SeatId);


    }
}
