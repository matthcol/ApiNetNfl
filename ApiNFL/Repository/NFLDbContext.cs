using ApiNFL.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiNFL.Repository
{
    public class NFLDbContext : DbContext
    {
        public NFLDbContext(DbContextOptions<NFLDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Team>().
            //    HasKey(t => t.Identification);

            modelBuilder.Entity<Match>().
                HasKey(m => new { m.TeamHomeId, m.TeamAwayId });
        }

        public DbSet<Team> Teams { get; set; }
        
        public DbSet<Player> Players { get; set; }

        public DbSet<Match> Matches { get; set; }

    }
}
