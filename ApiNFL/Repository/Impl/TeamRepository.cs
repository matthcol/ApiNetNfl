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

        public Team Get(int id)
        {
            return _dbContext.Teams
                .Where(t => t.Id == id)
                .Include(t => t.Players)
                .SingleOrDefault();
        }

        public Team Save(Team team)
        {
            _dbContext.Teams
                .Add(team);
            _dbContext.SaveChanges();
            return team;
        }
    }
}
