using AssetManagementAPI.DTO;
using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Api
{
    public class SeatAllocationApi : IAllocationProvider
    {
        private string _base = EndPointLookUp.GetEndPoint(EndPoint.Seat);
        public void Allocate(AllocateDTO allocateDTO)
        {
           var allocateApi = new ApiCall<AllocateDTO>($"{_base}/Allocate");
            allocateApi.PatchData(allocateDTO);
        }

        public void Deallocate(DeallocateDTO deallocateDTO)
        {
            var deallocateApi = new ApiCall<DeallocateDTO>($"{_base}/DeAllocate");
            deallocateApi.PatchData(deallocateDTO);
        }
    }
}
