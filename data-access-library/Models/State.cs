using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Models
{
	public class State
	{
		public State() { }

		public State(string abbr, string name)
		{
			this.Abbreviation = abbr;
			this.Name = name;
			this.BreweryDistribution = new List<Brewery>();
		}

		[Key]
		[StringLength(2, MinimumLength = 2)]
		public string Abbreviation { get; set; }
	
		[StringLength(50, MinimumLength = 3)]
		public string Name { get; set; }

		/// <summary>
		/// A list of Breweries which distribute to this state.
		/// </summary>
		public virtual IList<Brewery> BreweryDistribution { get; set; }
	}
}
