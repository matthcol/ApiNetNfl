using ApiNFL.Enumeration;
using ApiNFL.Model;
using ApiNFL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApiNFL.LearnEntityFramework
{
    public class NFLDbContextTest
    {
        protected DbContextOptions<NFLDbContext> ContextOptions { get; set; }

        protected NFLDbContextTest(DbContextOptions<NFLDbContext> contextOptions)
        {
            ContextOptions = contextOptions;

            InitData();
        }

        private void InitData()
        {
            using (var dbContext = new NFLDbContext(ContextOptions))
            {
                IEnumerable<Team> teams = new List<Team>() {
                     new Team { Name = "Patriots", City = "New England", Conference = ConferenceEnum.West },
                     new Team { Name = "49ers", City = "San Francisco", Conference = ConferenceEnum.East }
                     };
                dbContext.AddRange(teams);
                dbContext.SaveChanges();
            }
        }

        
    }
}
