using Microsoft.EntityFrameworkCore;
using World.Api.Data;
using World.Api.Modals;
using World.Api.Repository.IRepository;

namespace World.Api.Repository
{
    public class CoutryRepository : ICoutryRepository
    {
        private readonly ApplicationDbContext _context;

        public CoutryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Country entity)
        {
           await _context.Countries.AddAsync(entity);
           await Save();
        }

        public async Task Delete(Country entity)
        {
            _context.Countries.Remove(entity);
            await Save();

        }

        public async Task<List<Country>> GetAll()
        {
            List<Country> coutries = await _context.Countries.ToListAsync();
            return coutries;
        }

        public async Task<Country> GetCountryById(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            return country;
        }

        public bool IsCountryExist(string name)
        {
            var result = _context.Countries.AsSingleQuery().Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).Any();
            return result;

        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Update(Country entity)
        {
            _context.Countries.Update(entity);
            await Save();
        }        
    }
}
