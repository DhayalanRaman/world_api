using Microsoft.EntityFrameworkCore;
using World.Api.Modals;

namespace World.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
        }
        
        public DbSet<Country> Countries { get; set; }
        public DbSet<States> States { get; set; }
    }
}
