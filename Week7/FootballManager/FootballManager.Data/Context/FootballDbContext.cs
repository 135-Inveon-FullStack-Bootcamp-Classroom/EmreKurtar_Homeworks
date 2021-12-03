using FootballManager.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Data.Context
{
    public class FootballDbContext : DbContext
    {
        public FootballDbContext(DbContextOptions<FootballDbContext> options) : base(options)
        {

        }

        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<ManagementPosition> ManagementPositions { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<NationalTeam> NationalTeams { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tactic> Tactics { get; set; }
        public DbSet<Position> Positions { get; set; }





    }

}

