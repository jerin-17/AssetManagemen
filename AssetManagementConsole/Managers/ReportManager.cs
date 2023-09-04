using AssetManagementConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Managers
{
    public class ReportManager<T> : IReportManager<T> where T : class
    {
        private readonly IReportProvider<T> _reportProvider;
        public ReportManager(IReportProvider<T> reportProvider)
        {
            this._reportProvider = reportProvider;
        }
        public List<T> GenerateReport()
        {
            return _reportProvider.GetReport();
        }

        public List<T> Filter(List<T> entities, string abbr, Func<T,string> filterParam)
        {
           return entities.Where(a => filterParam(a)== abbr).ToList();
        }
    }
}
