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

        //Accepts any number of strings as paramenters. With this I can call the functions even if there are no paramenters. 
        //
        public List<T> GetAll(params string[] includeProperties)
        {
            //Initates an Iqueryable to allow using LINQ on my _bdSet.
            IQueryable<T> query = _dbSet;
            //Inludes any property passed to the function in my query. 
            foreach (var includeProperty in includeProperties)
            {
                //The info is in another table so need to Include it
                query = query.Include(includeProperty);
            }
            //returns the result as a list. 
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

        //Accepts a Lambda expression as a parameter, to allow the function to return a result based on a variety of conditions
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
