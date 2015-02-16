
using DataAccessLayer.Models;
using DataAccessLayer.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
			//Database.SetInitializer<ApplicationDbContext>(new DbDropCreateAlwaysInitializer());
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}

		public virtual IDbSet<Beer> Beers { get; set; }
		public virtual IDbSet<Brewery> Breweries { get; set; }
		public virtual IDbSet<State> States { get; set; }
		public virtual IDbSet<Style> Styles { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Properties<DateTime>()
				.Configure(c => c.HasColumnType("datetime2"));

			modelBuilder.Entity<Brewery>()
				.HasMany<Beer>(b => b.Beers)
				.WithMany(b => b.Breweries);

			modelBuilder.Entity<Brewery>()
				.HasMany<State>(b => b.Distribution)
				.WithMany(s => s.BreweryDistribution);

			modelBuilder.Entity<Style>()
				.HasMany<Beer>(s => s.Beers)
				.WithOptional(b => b.Style)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<ApplicationUser>()
				.HasMany<Cellar>(u => u.Cellars)
				.WithRequired(c => c.Owner)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<ApplicationUser>()
				.HasMany<Rating>(u => u.Ratings)
				.WithRequired(r => r.CreatedBy)
				.WillCascadeOnDelete(true);

			base.OnModelCreating(modelBuilder);
		}
	}
}