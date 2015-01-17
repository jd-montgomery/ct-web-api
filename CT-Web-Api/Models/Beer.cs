using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CT_Web_Api.Models
{
	public class Beer
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ushort Vintage { get; set; }
		public Beer VariantOf { get; set; }

		public ApplicationUser CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public ApplicationUser ModifiedBy { get; set; }
		public DateTime ModifiedOn { get; set; }

		public virtual IEnumerable<Cellared> Cellared { get; set; }
		public virtual IEnumerable<Beer> Variants { get; set; }
		public virtual IEnumerable<Brewery> Breweries { get; set; }
	}
}