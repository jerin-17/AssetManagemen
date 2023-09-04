using AssetManagementAPI.Model;
using AssetManagementConsole.Interface;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Api
{
    public class ReportApi<T> : IReportProvider<T> where T : class
    {
        private readonly IApiCall<T> _entityApiCall;
        
        public ReportApi()
        { 
            string endpoint = string.Empty; 
            if(typeof(T) == typeof(VAllocatedSeat)) {
                endpoint = EndPointLookUp.GetEndPoint(EndPoint.AllocateReport);
            }
            else
            {
                endpoint = EndPointLookUp.GetEndPoint(EndPoint.DeAllocateReport);
            }
            this._entityApiCall = new ApiCall<T>(endpoint);
        }

        public List<T> GetReport()
        {
            return _entityApiCall.GetData();
        }


    }
}
