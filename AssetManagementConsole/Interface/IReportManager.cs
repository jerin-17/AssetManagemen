using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Interface
{
    public interface IReportManager<T> where T : class
    {
        List<T> GenerateReport();
        List<T> Filter(List<T> entities, string abbr, Func<T, string> filterParam);
    }
}
