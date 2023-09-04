using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagementConsole.Interface;

namespace AssetManagementConsole.Api
{
    public class EntityApi<T> : IEntityManager<T> where T : class
    {
        private readonly IApiCall<T> _apiCall;
        public EntityApi(string endPoint)
        {
            _apiCall = new ApiCall<T>(endPoint);
        }
        public int Create(T entity)
        {
            return _apiCall.PostData(entity);
        }

       

        public List<T> GetAll()
        {
            return _apiCall.GetData();
        }

        public T GetById(int id)
        {
            return _apiCall.GetDataById(id);
        }

        public List<int> CreateBatch(List<T> entity)
        {
            return _apiCall.PostData(entity);
        }
    }
}
