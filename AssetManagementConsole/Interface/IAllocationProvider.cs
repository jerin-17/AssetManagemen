using AssetManagementAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Interface
{
    public interface IAllocationProvider
    {
        void Allocate(AllocateDTO allocatDTO);
        void Deallocate(DeallocateDTO deallocateDTO);
    }

   
}
