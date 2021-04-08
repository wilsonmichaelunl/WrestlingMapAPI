using System;
using System.Collections.Generic;
using System.Text;
using Contracts.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Accessors
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        public DbSet<Champion> Champions { get; set; }
        public DbSet<Wrestler> Wrestlers { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Champion>(entity =>
            {
                entity.HasKey(e => e.ChampionID)
                    .HasName("champion_id");

                entity.ToTable("champion", "dbo");

                entity.Property(e => e.ChampionID).HasColumnName("champion_id");
                entity.Property(e => e.WrestlerID).HasColumnName("wrestler_id");
                entity.Property(e => e.Year).HasColumnName("year");
                entity.Property(e => e.Team).HasColumnName("school");
                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(w => w.Wrestler)
                .WithMany(c => c.Champions)
                .HasForeignKey(w => w.WrestlerID)
                .HasConstraintName("champion_wrestler_wrestler_id_fk");
            });

            builder.Entity<Wrestler>(entity =>
            {
                entity.HasKey(e => e.WrestlerID)
                    .HasName("wrestler_id");

                entity.ToTable("wrestler", "dbo");

                entity.Property(e => e.WrestlerID).HasColumnName("wrestler_id");
                entity.Property(e => e.LastName).HasColumnName("last_name");
                entity.Property(e => e.FirstName).HasColumnName("first_name");
                entity.Property(e => e.Hometown).HasColumnName("hometown");
                entity.Property(e => e.Latitude).HasColumnName("latitude");
                entity.Property(e => e.Longitude).HasColumnName("longitude");
                entity.Property(e => e.StateID).HasColumnName("state_id");
                entity.Property(e => e.WrestleStat).HasColumnName("wrestlestat");

                entity.HasOne(s => s.State)
                .WithMany(w => w.Wrestlers)
                .HasForeignKey(s => s.StateID)
                .HasConstraintName("wrestler_state_state_id_fk");
            });

            builder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.StateID)
                    .HasName("state_id");

                entity.ToTable("state", "dbo");

                entity.Property(e => e.StateID).HasColumnName("state_id");
                entity.Property(e => e.PostalAbbreviation).HasColumnName("postal_abbreviation");
                entity.Property(e => e.StateName).HasColumnName("state_name");
            });
        }


    }
}
