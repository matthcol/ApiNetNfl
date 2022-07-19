using ApiNFL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
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

            }
        }

        [Fact]
        public void TestUpdate()
        {

        }

        [Fact]
        public void TestDelete()
        {

        }

        [Fact]
        public void TestReadById()
        {

        }

    }
}
