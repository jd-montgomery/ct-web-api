using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using Microsoft.Data.OData;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace CT_Web_Api.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using CT_Web_Api.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Brewery>("Breweries");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class BreweriesController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
		private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/Breweries
        public async Task<IHttpActionResult> GetBreweries(ODataQueryOptions<Brewery> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }
			
            return Ok<IEnumerable<Brewery>>(db.Breweries.ToList());
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/Breweries(5)
        public async Task<IHttpActionResult> GetBrewery([FromODataUri] long key, ODataQueryOptions<Brewery> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<Brewery>(brewery);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/Breweries(5)
        public async Task<IHttpActionResult> Put([FromODataUri] long key, Delta<Brewery> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(brewery);

            // TODO: Save the patched entity.

            // return Updated(brewery);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Breweries
        public async Task<IHttpActionResult> Post(Brewery brewery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(brewery);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Breweries(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] long key, Delta<Brewery> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(brewery);

            // TODO: Save the patched entity.

            // return Updated(brewery);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Breweries(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] long key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
