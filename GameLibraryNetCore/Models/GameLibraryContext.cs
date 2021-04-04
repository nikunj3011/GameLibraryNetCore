using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameLibraryNetCore.Models
{
    public class GameLibraryContext:DbContext
    {
        public DbSet<GameLibrary> GameLibrary { get; set; }
        public DbSet<GameSystem> GameSystems { get; set; }

        public GameLibraryContext(DbContextOptions<GameLibraryContext> con) : base(con)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameLibrary>().ToTable("GameLibrary");
            modelBuilder.Entity<GameSystem>().ToTable("GameSystem");
        }

    }

}
