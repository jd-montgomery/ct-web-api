using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Web;

namespace CT_Web_Api.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}

		public IDbSet<Brewery> Breweries { get; set; }
		public IDbSet<Beer> Beers { get; set; }
		public IDbSet<State> States { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Properties<DateTime>()
				.Configure(c => c.HasColumnType("datetime2"));

			modelBuilder.Entity<Brewery>()
				.Property(b => b.Name)
				.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation("UQ_BreweryName", 1) { IsUnique = true });

			base.OnModelCreating(modelBuilder);
		}
	}
}