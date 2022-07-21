using ApiNFL.Model.Orm;
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

            modelBuilder.Entity<Match>()
                .HasOne(m => m.TeamHome)
                .WithMany(t => t.MatchesHome);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.TeamAway)
                .WithMany(t => t.MatchesAway);
        }

        public DbSet<Team> Teams { get; set; }
        
        public DbSet<Player> Players { get; set; }

        public DbSet<Match> Matches { get; set; }

        // public DbSet<Stadium> Stadiums { get; set; }    
    }
}
