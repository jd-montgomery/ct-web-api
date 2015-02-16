using DataAccessLayer.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Models
{
	public class Beer
	{
		public Beer()
		{
			this.CreatedOn = DateTime.UtcNow;

			this.Breweries = new List<Brewery>();
			this.Cellared = new List<Cellared>();
			this.Variants = new List<Beer>();
		}

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[StringLength(80, MinimumLength = 1)]
		[Index("IX_BeerName", 1)]
		public string Name { get; set; }

		[StringLength(4096, MinimumLength = 3)]
		public string Description { get; set; }

		public virtual Style Style { get; set; }
		public short Ibu { get; set; }
		public Single Abv { get; set; }
		public short Srm { get; set; }
		public short Vintage { get; set; }
		public virtual Beer VariantOf { get; set; }

		public virtual ApplicationUser CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public virtual ApplicationUser ModifiedBy { get; set; }
		public DateTime ModifiedOn { get; set; }

		public virtual IList<Brewery> Breweries { get; set; }
		public virtual IList<Cellared> Cellared { get; set; }
		public virtual IList<Beer> Variants { get; set; }
	}
}