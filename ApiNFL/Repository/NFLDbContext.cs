using ApiNFL.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiNFL.Repository
{
    public class NFLDbContext : DbContext
    {
        public NFLDbContext(DbContextOptions<NFLDbContext> options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        
        // public DbSet<Player> Players { get; set; }
    }
}
