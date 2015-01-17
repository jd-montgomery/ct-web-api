using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CT_Web_Api.Models
{
	public class State
	{
		[Key]
		public string Abbreviation { get; set; }
		public string Name { get; set; }
	}
}
