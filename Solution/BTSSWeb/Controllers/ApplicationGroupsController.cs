using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BTSSWeb.Models;

namespace BTSSWeb.Controllers
{
    public class ApplicationGroupsController : ApiController
    {
        private BTSSWebContext db = new BTSSWebContext();

        // GET: api/ApplicationGroups
        public IQueryable<ApplicationGroups> GetApplicationGroups()
        {
            return db.ApplicationGroups;
        }

        // GET: api/ApplicationGroups/5
        [ResponseType(typeof(ApplicationGroups))]
        public async Task<IHttpActionResult> GetApplicationGroups(Guid id)
        {
            ApplicationGroups applicationGroups = await db.ApplicationGroups.FindAsync(id);
            if (applicationGroups == null)
            {
                return NotFound();
            }

            return Ok(applicationGroups);
        }

        // PUT: api/ApplicationGroups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutApplicationGroups(Guid id, ApplicationGroups applicationGroups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicationGroups.ApplicationGroupID)
            {
                return BadRequest();
            }

            db.Entry(applicationGroups).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationGroupsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ApplicationGroups
        [ResponseType(typeof(ApplicationGroups))]
        public async Task<IHttpActionResult> PostApplicationGroups(ApplicationGroups applicationGroups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApplicationGroups.Add(applicationGroups);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ApplicationGroupsExists(applicationGroups.ApplicationGroupID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = applicationGroups.ApplicationGroupID }, applicationGroups);
        }

        // DELETE: api/ApplicationGroups/5
        [ResponseType(typeof(ApplicationGroups))]
        public async Task<IHttpActionResult> DeleteApplicationGroups(Guid id)
        {
            ApplicationGroups applicationGroups = await db.ApplicationGroups.FindAsync(id);
            if (applicationGroups == null)
            {
                return NotFound();
            }

            db.ApplicationGroups.Remove(applicationGroups);
            await db.SaveChangesAsync();

            return Ok(applicationGroups);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationGroupsExists(Guid id)
        {
            return db.ApplicationGroups.Count(e => e.ApplicationGroupID == id) > 0;
        }
    }
}