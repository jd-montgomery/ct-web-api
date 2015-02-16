using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DataAccessLayer.Services
{
	public class Brewery
	{
		private ApplicationDbContext context;

		public Brewery(ApplicationDbContext context) 
		{ 
			this.context = context; 
		}
 
		public Models.Brewery AddBrewery(Models.Brewery brewery) 
		{ 
			var savedBrewery = context.Breweries.Add(brewery); 
			this.context.SaveChanges();

			return savedBrewery; 
		} 
 
		public List<Models.Brewery> GetAllBreweries() 
		{ 
			var query = from b in this.context.Breweries 
						orderby b.Name 
						select b; 
 
			return query.ToList(); 
		} 
 
		public async Task<List<Models.Brewery>> GetAllBreweriesAsync() 
		{ 
			var query = from b in this.context.Breweries 
						orderby b.Name 
						select b; 
 
			return await query.ToListAsync(); 
		} 
	}
}