using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using World.Api.Data;
using World.Api.Repository.IRepository;

namespace World.Api.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.AddAsync(entity);
            await Save();
        }

        public async Task Delete(T entity)
        {
            _context.Remove(entity);
            await Save();
        }

        public async Task<T> Get(int id)
        {
            //var country = await _context.Countries.FindAsync(id);
            var country = await _context.Set<T>().FindAsync(id);
            return country;
        }

        public async Task<List<T>> GetAll()
        {
            List<T> countries = await _context.Set<T>().ToListAsync();
            return countries;
        }

        public bool IsRecordExist(Expression<Func<T, bool>> condition)
        {
            var result = _context.Set<T>().AsSingleQuery().Where(condition).Any();
            return result;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
