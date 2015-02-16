using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
	public class Style
	{
		public Style() { }
		
		public Style(string name)
		{
			this.Name = name;
		}

		public short Id { get; set; }

		[StringLength(50, MinimumLength=3)]
		public string Name { get; set; }
		
		public string Description { get; set; }

		public virtual IList<Beer> Beers { get; set; }
	}
}
