using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TriatlonLogic.Models;

namespace TriatlonDataAccess.Context
{
	public class TriatlonContext : DbContext
	{
		public DbSet<Korido> Koridok { get; set; }
		public DbSet<Verseny> Versenyek { get; set; }
		public DbSet<VersenyVersenyzo> VersenyVersenyzok { get; set; }
		public DbSet<Versenyzo> Versenyzok { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(TriatlonDbConfiguration.GetConnectionString());
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Verseny>()
			.HasMany(e => e.VersenyVersenyzok)
			.WithOne(e => e.Verseny)
			.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<VersenyVersenyzo>()
			.HasMany(e => e.Koridok)
			.WithOne(e => e.VersenyVersenyzo)
			.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Versenyzo>()
			.HasMany(e => e.VersenyVersenyzok)
			.WithOne(e => e.Versenyzo)
			.OnDelete(DeleteBehavior.Restrict);

		}
	}
}
