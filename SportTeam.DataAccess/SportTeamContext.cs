using Microsoft.EntityFrameworkCore;
using SportTeam.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportTeam.DataAccess
{
    public class SportTeamContext : DbContext
    {
        private readonly string connectionString;

        public SportTeamContext(string connectionString)
        {
            this.connectionString = connectionString;
            Database.EnsureCreated();
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            var Teti = new Team { TeamName = "Teti" };
            var Contr = new Team { TeamName = "Contr" };

            builder.Entity<Team>().HasData(Teti);
            builder.Entity<Team>().HasData(Contr);

            builder.Entity<Player>().HasData(new Player{FullName = "аро",TeamId = Teti.Id}); 
            builder.Entity<Player>().HasData(new Player{FullName = "апр",TeamId = Teti.Id}); 
            builder.Entity<Player>().HasData(new Player{FullName = "вап",TeamId = Teti.Id}); 
            builder.Entity<Player>().HasData(new Player{FullName = "варвар",TeamId = Teti.Id}); 

            builder.Entity<Player>().HasData(new Player{FullName = "счи",TeamId = Contr.Id}); 
            builder.Entity<Player>().HasData(new Player{FullName = "лапор",TeamId = Contr.Id}); 
            builder.Entity<Player>().HasData(new Player{FullName = "драгул",TeamId = Contr.Id}); 
            builder.Entity<Player>().HasData(new Player{FullName = "Зина",TeamId = Contr.Id}); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseNpgsql(connectionString);
        }
    }
}
