using ApiNFL.Model.Orm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNFL.Repository.Impl
{
    public class TeamRepository: ITeamRepository
    {
        private readonly NFLDbContext _dbContext;

        public TeamRepository(NFLDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Team> Get(int id)
        {
            return await _dbContext.Teams
                .Where(t => t.Id == id)
                .Include(t => t.Players)
                .SingleOrDefaultAsync();
        }

        public async Task<Team> Save(Team team)
        {
            await _dbContext.Teams
                .AddAsync(team);
            await _dbContext.SaveChangesAsync();
            return team;
        }
    }
}
