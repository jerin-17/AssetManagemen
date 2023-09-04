using AssetManagementAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using AssetManagementAPI.Model;

namespace AssetManagementAPI
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly AssetDbContext _context;
        private readonly DbSet<T> _entities;

        public EFRepository(AssetDbContext context) {
            this._context = context;
            this._entities = context.Set<T>();
        }
        public void Add(T entity)
        {
             _entities.Add(entity);
        }

        public void  Delete(T entity)
        {
             _entities.Remove(entity);
        }

        public DbSet<T> GetAll()
        {
            return  _entities;   
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Save()
        {
           _context.SaveChanges();
        }

    }
}
