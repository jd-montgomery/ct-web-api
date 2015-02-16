using DataAccessLayer.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Models
{
	public class Cellared
	{
		public Cellared()
		{
			this.CellaredOn = DateTime.UtcNow;
		}

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		public virtual Beer Beer { get; set; }
		public virtual Cellar Cellar { get; set; }

		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime CellaredOn { get; set; }

		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime DrinkBy { get; set; }
		
		public short Quantity { get; set; }
		public short VolumeInMilliliters { get; set; }
	}
}
