using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
	public class BeerRating : Rating
	{
		public virtual Beer Beer { get; set; }
	}
}
