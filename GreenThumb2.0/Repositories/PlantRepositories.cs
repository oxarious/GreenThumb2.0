using GreenThumb2._0.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GreenThumb2._0.Repositories
{
    internal class PlantRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;


        public PlantRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public List<T> GetAll(params string[] includeProperties)
        {

            IQueryable<T> query = _dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.ToList();
        }
        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
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
