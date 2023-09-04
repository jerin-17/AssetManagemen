using AssetManagementAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Interface
{
    public interface IReportProvider<T> where T : class
    {
        List<T> GetReport();

    }
}
