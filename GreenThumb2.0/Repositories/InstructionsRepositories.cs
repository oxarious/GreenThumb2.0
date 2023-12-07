using GreenThumb2._0.Data;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb2._0.Repositories
{
    internal class InstructionRepository<T> where T : class
    {


        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;


        public InstructionRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {

        }
        public void Delete(int id)
        {
            T? entityToDelete = _dbSet.Find(id);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }

}

