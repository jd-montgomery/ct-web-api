using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CT_Web_Api.Models
{
	public class Brewery
	{
		[Key]
		public long Id { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 3)]
		public string Name { get; set; }
		[StringLength(4096, MinimumLength = 3)]
		public string Description { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
		public ushort? YearEstablished { get; set; }

		[Required]
		public ApplicationUser CreatedBy { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime CreatedOn { get; set; }
		public ApplicationUser ModifiedBy { get; set; }

		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime ModifiedOn { get; set; }
		
		public virtual IEnumerable<Beer> Beers { get; set; }
		public virtual IEnumerable<State> Distribution { get; set; }
		
		public Brewery(string name)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("Brewery Name must be provided upon construction.");

			this.Name = name;
			this.CreatedOn = DateTime.UtcNow;
		}
	}
}