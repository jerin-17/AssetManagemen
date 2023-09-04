using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.Interface
{
    public interface IEntityManager<T> where T : class 
    {
        List<T> GetAll();
        T GetById(int id);
        int Create(T entity);

        List<int> CreateBatch(List<T> entity);
    }
    
}
