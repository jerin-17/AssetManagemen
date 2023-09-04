using AssetManagementAPI.DTO;
using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Managers
{
    public class AllocationManager : IAllocateManager
    {
        private readonly IInputProvider<AllocateDTO> _allocateInput;
        private readonly IInputProvider<DeallocateDTO> _deallocateInput;
        private readonly IAllocationProvider _allocationProvider;

        public AllocationManager(IInputProvider<AllocateDTO> allocateInput,IInputProvider<DeallocateDTO> deallocateInput,
            IAllocationProvider allocationProvider)
        {
           this._allocateInput = allocateInput;
            this._deallocateInput = deallocateInput;
            this._allocationProvider = allocationProvider;
        }

        public void Allocate()
        {
            AllocateDTO allocateDTO = _allocateInput.GetInput();
            _allocationProvider.Allocate(allocateDTO);
        }

        public void DeAllocate()
        {
            DeallocateDTO deAllocateDTO = _deallocateInput.GetInput();
            _allocationProvider.Deallocate(deAllocateDTO);
        }
    }
}
