using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Interface
{
    
        public interface IApiCall<T> where T : class
        {
            int PostData(T data);

            List<T> GetData();
        List<int> PostData(List<T> entity);

           T GetDataById(int id);

            void PatchData(T data);
        }

}
