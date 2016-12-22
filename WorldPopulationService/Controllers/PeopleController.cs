using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using WorldPopulationService.Models;

namespace WorldPopulationService.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using WorldPopulationService.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<People>("People");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PeopleController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/People
        [EnableQuery]
        public IQueryable<People> GetPeople()
        {
            return db.People;
        }

        // GET: odata/People(5)
        [EnableQuery]
        public SingleResult<People> GetPeople([FromODataUri] int key)
        {
            return SingleResult.Create(db.People.Where(people => people.Id == key));
        }

        // PUT: odata/People(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<People> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            People people = db.People.Find(key);
            if (people == null)
            {
                return NotFound();
            }

            patch.Put(people);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeopleExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(people);
        }

        // POST: odata/People
        public IHttpActionResult Post(People people)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.People.Add(people);
            db.SaveChanges();

            return Created(people);
        }

        // PATCH: odata/People(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<People> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            People people = db.People.Find(key);
            if (people == null)
            {
                return NotFound();
            }

            patch.Patch(people);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeopleExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(people);
        }

        // DELETE: odata/People(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            People people = db.People.Find(key);
            if (people == null)
            {
                return NotFound();
            }

            db.People.Remove(people);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeopleExists(int key)
        {
            return db.People.Count(e => e.Id == key) > 0;
        }
    }
}
