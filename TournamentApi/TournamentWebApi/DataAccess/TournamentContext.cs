using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWebApi.Models;

namespace TournamentWebApi.DataAccess
{
    public class TournamentContext : DbContext
    {
        private readonly IConfiguration configuration;

        public DbSet<User> User { get; set; }
        public DbSet<Tournament> Tournament { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<Team> Team { get; set; }
        public TournamentContext(DbContextOptions<TournamentContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SomeeSqlServer"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            builder.Entity<Match>()
                .Property(m => m.Bracket)
                .HasConversion<string>();
            builder.Entity<Match>()
                .HasOne(m => m.Tournament)
                .WithMany(t => t.Matches)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Tournament>()
                .HasIndex(t => t.Name)
                .IsUnique();
            builder.Entity<Tournament>()
                .HasOne(t => t.Owner)
                .WithMany(u => u.Tournaments);
            builder.Entity<Match>()
                .HasOne(m => m.FirstTeam)
                .WithMany()
                .IsRequired(false);
            builder.Entity<Match>()
                .HasOne(m => m.SecondTeam)
                .WithMany()
                .IsRequired(false);

            base.OnModelCreating(builder);
        }
    }
}
