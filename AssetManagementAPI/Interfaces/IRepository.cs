using Microsoft.EntityFrameworkCore;
using AssetManagementAPI.Model;

namespace AssetManagementAPI.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        DbSet<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
