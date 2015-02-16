using DataAccessLayer.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Models
{
	public class Cellar
	{
		public Cellar()
		{
			this.Cellared = new List<Cellared>();
		}
		
		public long Id { get; set; }

		[StringLength(50, MinimumLength=3)]
		public string Name { get; set; }

		public virtual ApplicationUser Owner { get; set; }
		
		public virtual IList<Cellared> Cellared { get; set; }
	}
}
