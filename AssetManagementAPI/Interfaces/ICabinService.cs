using AssetManagementAPI.DTO;
using AssetManagementAPI.Model;

namespace AssetManagementAPI.Interfaces
{
    public interface ICabinService
    {
        List<Cabin> GetCabins();
        int CreateCabin(CabinDTO seat);

        void AllocateCabin(int SeatId, int employeeId);
        void DeallocateCabin(int SeatId);
    }
}
