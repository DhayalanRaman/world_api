using World.Api.Data;
using World.Api.Modals;
using World.Api.Repository.IRepository;

namespace World.Api.Repository
{
    public class StateRepository : GenericRepository<States>, IStateRepository
    {
        private readonly ApplicationDbContext _context;

        public StateRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Update(States entity)
        {
            _context.States.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
