using DataAccessLayer.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataAccessLayer.Models
{
	public class Brewery
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 3)]
		[Index("IX_BreweryName", 1, IsUnique = true)]
		public string Name { get; set; }

		[NotMapped]
		public string Slug { get {
			return this.Name.GenerateSlug();
		}}

		[StringLength(4096, MinimumLength = 3)]
		public string Description { get; set; }

		[Required]
		public virtual ApplicationUser CreatedBy { get; set; }

		[Required]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime CreatedOn { get; set; }

		public virtual ApplicationUser ModifiedBy { get; set; }

		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime ModifiedOn { get; set; }

		[StringLength(128, MinimumLength = 4)]
		public string Uri { get; set; }
		
		public virtual IList<Beer> Beers { get; set; }
		public virtual IList<State> Distribution { get; set; }
		
		public Brewery()
		{
			this.CreatedOn = DateTime.UtcNow;
			this.Beers = new List<Beer>();
			this.Distribution = new List<State>();
		}

		public Brewery(string name): this()
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("Brewery Name must be provided upon construction.");

			this.Name = name;
		}
	}
}