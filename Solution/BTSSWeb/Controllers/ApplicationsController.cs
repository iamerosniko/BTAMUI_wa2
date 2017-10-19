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
    public class ApplicationsController : ApiController
    {
        private BTSSWebContext db = new BTSSWebContext();

        // GET: api/Applications
        public IQueryable<Applications> GetApplications()
        {
            return db.Applications;
        }

        // GET: api/Applications/5
        [ResponseType(typeof(Applications))]
        public async Task<IHttpActionResult> GetApplications(int id)
        {
            Applications applications = await db.Applications.FindAsync(id);
            if (applications == null)
            {
                return Ok(null);
            }

            return Ok(applications);
        }

        // PUT: api/Applications/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutApplications(int id, Applications applications)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applications.ApplicationID)
            {
                return BadRequest();
            }

            db.Entry(applications).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationsExists(id))
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

        // POST: api/Applications
        [ResponseType(typeof(Applications))]
        public async Task<IHttpActionResult> PostApplications(Applications applications)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Applications.Add(applications);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = applications.ApplicationID }, applications);
        }

        // DELETE: api/Applications/5
        [ResponseType(typeof(Applications))]
        public async Task<IHttpActionResult> DeleteApplications(int id)
        {
            Applications applications = await db.Applications.FindAsync(id);
            if (applications == null)
            {
                return NotFound();
            }

            db.Applications.Remove(applications);
            await db.SaveChangesAsync();

            return Ok(applications);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationsExists(int id)
        {
            return db.Applications.Count(e => e.ApplicationID == id) > 0;
        }
    }
}