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
                // clean up : TODO must be improved
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();

                // teams
                var team1 = new Team { Name = "Patriots", City = "New England", Conference = ConferenceEnum.West, TrophyCount =10 };
                var team2 = new Team { Name = "49ers", City = "San Francisco", Conference = ConferenceEnum.East, TrophyCount =3 };
                var team3 = new Team { Name = "Cow Boys", City = "Dallas", Conference = ConferenceEnum.East, TrophyCount = 7 };
                var team4 = new Team { Name = "Buccaneers", City = "Tampa Bay", Conference = ConferenceEnum.West, TrophyCount = 4 };

                dbContext.AddRange(team1, team2, team3, team4);
                dbContext.SaveChanges();

                // players
                var player1 = new Player { FirstName = "Brian", LastName = "Hoyer", Position = PositionEnum.QB }; //, Team = team1 };
                var player2 = new Player { FirstName = "Damien", LastName = "Harris", Position = PositionEnum.WideReceiver }; // Team = team1 };
                var player3 = new Player { FirstName = "Jimmy", LastName = "Garoppolo", Position = PositionEnum.QB }; //, Team = team1 };
                var player4 = new Player { FirstName = "Dee", LastName = "Ford", Position = PositionEnum.RunningBack }; //, Team = team2 };
                var player5 = new Player { FirstName = "Ben", LastName = "DiNucci", Position = PositionEnum.QB }; //, Team = team2 };    
                var player6 = new Player { FirstName = "Tom", LastName = "Brady", Position = PositionEnum.QB }; //, Team = team2 };

                team1.Players.Add(player1);
                team1.Players.Add(player2);
                team2.Players.Add(player3);
                team2.Players.Add(player4);
                team3.Players.Add(player5);
                team4.Players.Add(player6);
                //dbContext.AddRange(teams);
                dbContext.SaveChanges();

                // Matches
                var match = new Match { TeamHome = team1, TeamAway = team2, Day = 2, ScoreHome = 43, ScoreAway = 27 };
                dbContext.Matches.Add(match);
                dbContext.SaveChanges();


            }
        }

        
    }
}
