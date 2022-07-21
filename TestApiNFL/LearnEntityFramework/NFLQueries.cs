using ApiNFL.Enumeration;
using ApiNFL.Model;
using ApiNFL.Repository;
using ApiNFL.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace TestApiNFL.LearnEntityFramework
{
    public class NFLQueries : NFLDbContextTest
    {
        public NFLQueries() : base(
          new DbContextOptionsBuilder<NFLDbContext>()
          .UseInMemoryDatabase("dbnfltest2")
          .Options
        )
        {
        }

        [Fact]
        public void TestTeamWithPlayersEager()
        {
            using (var dbContext = new NFLDbContext(ContextOptions))
            {
                var team = dbContext.Teams
                    .Where(t => t.Name == "Patriots")
                    .Include(t => t.Players)
                    // .Include(t => t.Coach)
                    // .ThenInclude(p => p.Stats)
                    .Single();
                Assert.Equal(team.Players.Count, 2);
            }
        }

        [Fact]
        public void TestTeamWithPlayersExplicit()
        {
            using (var dbContext = new NFLDbContext(ContextOptions))
            {
                var team = dbContext.Teams
                    .Single(t => t.Name == "Patriots");

                // load associated objects after:

                dbContext.Entry(team)
                    .Collection(t => t.Players)
                    .Load();

                //dbContext.Entry(team)
                //    .Reference(t => t.Coach)
                //    .Load();

                Assert.Equal(team.Players.Count, 2);
            }
        }

        [Fact]
        public void TestPlayerQBConferenceWest()
        {
            using (var dbContext = new NFLDbContext(ContextOptions))
            {
                var players = dbContext.Players
                    .Where(p => p.Position == PositionEnum.QB)
                    .Include(p => p.Team)
                    .Where(p => p.Team.Conference == ConferenceEnum.West)
                    .ToList();

                // verify (with init data set !!!)
                Assert.Equal(2, players.Count);
                Assert.Equal(players[0].FirstName, "Brian");
                Assert.Equal(players[0].LastName, "Hoyer");

                // Assert.Null(players[0].Team); // with no include Team
                Assert.NotNull(players[0].Team); // with no include Team
            }
        }

        [Fact]
        public void TestTeamWithPlayerName()
        {
            using (var dbContext = new NFLDbContext(ContextOptions))
            {
                var teams = dbContext.Players
                    .Where(p => p.LastName == "Hoyer")
                    .Select(p => p.Team)
                    .Distinct()
                    .ToList();

                // verify (with our data)
                Assert.Equal(teams[0].Name, "Patriots");
            }
        }

        [Fact]
        public void TestMatch()
        {
            using (var dbContext = new NFLDbContext(ContextOptions))
            {
                var match = dbContext.Matches
                    .Include(m => m.TeamHome)
                    .Include(m => m.TeamAway)
                    .First();
                //var match = dbContext.Matches
                //    .Find(1, 2);
                Assert.NotEqual(match.TeamHomeId, 0);
                Assert.NotEqual(match.TeamAwayId, 0);
                Assert.Equal(match.TeamHome.Name, "Patriots");
                Assert.Equal(match.TeamAway.Name, "49ers");
            }
        }

        [Fact]
        public void TestMatchPlayers()
        {
            using (var dbContext = new NFLDbContext(ContextOptions))
            {
                // TODO: flatten players from both teams
                var playersLists = dbContext.Matches
                    .Where(m => m.Day == 2)
                     // .SelectMany(m => m.Teams.Select(t => t.Players))
                     .Select(m => new[] { m.TeamHome.Players, m.TeamAway.Players })
                    //.Select(m => m.TeamHome.Players)
                    .ToList();
                var players = playersLists
                    .SelectMany(l => l)
                    .SelectMany(l => l)
                    .ToList();
                Assert.Equal(4, players.Count);
            }
        }

        [Fact]
        public void TestPseudoSQL()
        {
            using (var dbContext = new NFLDbContext(ContextOptions))
            {
                var query = from p in dbContext.Players
                            where p.Position == PositionEnum.QB
                            select p;
                var players = query.ToList();
                Assert.Equal(4, players.Count);
            }
        }

        [Fact]
        public void TestRawSQL()
        {
            using (var dbContext = new NFLDbContext(ContextOptions))
            {
                var query = "select * from Players p " +
                            "where p.Position == 0 ";
                var players = dbContext.Players
                    .FromSqlRaw(query)
                    .ToList();
                Assert.Equal(4, players.Count);
            }
        }

        [Fact]
        public void TestTeamsByConference()
        {
            using (var dbContext = new NFLDbContext(ContextOptions))
            {
                var res = dbContext.Teams
                    .GroupBy(
                        t => t.Conference,
                        t => t.TrophyCount,
                        (c, tc) => new
                        {
                            Conference = c,
                            TrophySum = tc.Sum(),
                            TrophyMax = tc.Max()
                        })
                    .ToList();
            }
        }

        [Fact]
        public void TestHomeScoreByTeamId()
        {
            using (var dbContext = new NFLDbContext(ContextOptions))
            {
                var res = dbContext.Matches
                    .GroupBy(
                        m =>  m.TeamHomeId,
                        m => m.ScoreHome,
                        (t, sh) => new
                        {
                            TeamHomeId = t,
                            ScoreHome = sh.Sum()
                        }
                    )
                    .ToList();
            }
        }

        [Fact]
        public void TestHomeScoreByTeamName()
        {
            using (var dbContext = new NFLDbContext(ContextOptions))
            {
                var res = dbContext.Matches
                    .GroupBy(
                        m => m.TeamHome.Name,
                        m => m.ScoreHome,
                        (t, sh) => new
                        {
                            TeamHomeName = t,
                            ScoreHome = sh.Sum()
                        }
                    )
                    .ToList();
            }
        }

        // score total à la maison de chaque equipe
        [Fact]
        public void TestHomeScoreByTeamIdName()
        {
            using (var dbContext = new NFLDbContext(ContextOptions))
            {
                var res = dbContext.Matches
                    .GroupBy(
                        m => new
                        {
                            Id = m.TeamHomeId,
                            Name = m.TeamHome.Name
                        },
                        m => m.ScoreHome,
                        (t, sh) => new TeamStatisticsViewModel
                        {
                            Id = t.Id,
                            Name = t.Name,
                            ScoreHomeSum = sh.Sum()
                        }
                    )
                    .ToList();
            }
        }

        [Fact]
        public void TestTeamToMatches()
        {
            using (var dbContext = new NFLDbContext(ContextOptions)) {
                var team = dbContext.Teams
                    .Where(t => t.Name == "Patriots")
                    .Include(t => t.MatchesHome)
                    .Include(t => t.MatchesAway)
                    .Single();

                Assert.True(team.MatchesHome.Count() > 0);
                Assert.True(team.MatchesAway.Count() > 0);
            };

        }
    }
}
