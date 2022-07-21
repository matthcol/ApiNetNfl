using ApiNFL.Enumeration;
using ApiNFL.Model.Orm;
using ApiNFL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace TestApiNFL.LearnEntityFramework
{
    public class TeamCrudTest: NFLDbContextTest
    {
        public TeamCrudTest() : base(
            new DbContextOptionsBuilder<NFLDbContext>()
            .UseInMemoryDatabase("dbnfltest1")
            .Options
        )
        {
        }

        [Theory]
        [InlineData("Seahawks")]
        [InlineData("Sea")]
        public void TestSave(string name)
        {
            using (var dbContext = new NFLDbContext(ContextOptions))
            {
                var team = new Team { Name = name, City = "Seattle", CreationDate = new DateTime(1910, 2, 12) };
                dbContext.Teams.Add(team);
                dbContext.SaveChanges(); // synchro EF => DB : INSERT INTO Team ....
                Assert.NotNull(team.Id);
                // read data from EF
                var teamsRead = dbContext.Teams.Where(t => t.Name == name).ToList();
                Assert.Equal(1, teamsRead.Count);
            }
        }

        [Fact]
        public void TestUpdate()
        {
            using (var dbContext = new NFLDbContext(ContextOptions))
            {
                var team = dbContext.Teams.Where(t => t.Conference == ConferenceEnum.West).First();
                // update
                team.Conference = ConferenceEnum.East;
                dbContext.SaveChanges();
                // verify
                var teamVerify = dbContext.Teams
                    .Where(t => t.Conference == ConferenceEnum.East)
                    .Where(t => t.Id == team.Id)
                    .Single(); // assert only one result
            }
        }

        [Fact]
        public void TestDelete()
        {
            using (var dbContext = new NFLDbContext(ContextOptions))
            {
                var team = new Team { Name = "Carolina Panthers" };
                dbContext.Teams.Add(team);
                dbContext.SaveChanges();
                dbContext.Teams.Remove(team);
                dbContext.SaveChanges();
                var teamVerify = dbContext.Teams.Find(team.Id);
                Assert.Null(teamVerify);
            }
        }

            [Fact]
        public void TestReadById()
        {
       
        }

    }
}
