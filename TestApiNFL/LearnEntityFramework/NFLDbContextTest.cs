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

            // init some data
        }

        
    }
}
