using DataAccessLayer.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
	public abstract class Rating
	{
		public Rating()
		{
			this.CreatedOn = DateTime.UtcNow;
		}

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		public virtual ApplicationUser CreatedBy { get; set; }

		public string Review { get; set; }

		public byte OneToTen { get; set; }

		public DateTime CreatedOn { get; set; }
	}
}
