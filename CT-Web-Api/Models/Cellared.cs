using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CT_Web_Api.Models
{
	public class Cellared
	{
		public Guid Id { get; set; }
		public Cellar Cellar { get; set; }
		public Beer Beer { get; set; }
		public DateTime CellaredOn { get; set; }
		public DateTime DrinkBy { get; set; }

	}
}
