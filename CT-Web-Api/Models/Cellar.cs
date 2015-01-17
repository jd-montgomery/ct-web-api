using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CT_Web_Api.Models
{
	public class Cellar
	{
		public UInt64 Id { get; set; }
		public ApplicationUser Owner { get; set; }
		public string Name { get; set; }
	}
}
