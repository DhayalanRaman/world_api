using Microsoft.EntityFrameworkCore;
using World.Api.Data;
using World.Api.Modals;
using World.Api.Repository.IRepository;

namespace World.Api.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository 
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public async Task Update(Country entity)
        {
            _context.Countries.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
