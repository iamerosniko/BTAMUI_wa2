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
    public class ApplicationGroupTablesController : ApiController
    {
        private BTSSWebContext db = new BTSSWebContext();

        // GET: api/ApplicationGroupTables
        public IQueryable<ApplicationGroupTables> GetApplicationGroupTables()
        {
            return db.ApplicationGroupTables;
        }

        // GET: api/ApplicationGroupTables/5
        [ResponseType(typeof(ApplicationGroupTables))]
        public async Task<IHttpActionResult> GetApplicationGroupTables(Guid id)
        {
            ApplicationGroupTables applicationGroupTables = await db.ApplicationGroupTables.FindAsync(id);
            if (applicationGroupTables == null)
            {
                return NotFound();
            }

            return Ok(applicationGroupTables);
        }

        // PUT: api/ApplicationGroupTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutApplicationGroupTables(Guid id, ApplicationGroupTables applicationGroupTables)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicationGroupTables.AppGroupTableID)
            {
                return BadRequest();
            }

            db.Entry(applicationGroupTables).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationGroupTablesExists(id))
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

        // POST: api/ApplicationGroupTables
        [ResponseType(typeof(ApplicationGroupTables))]
        public async Task<IHttpActionResult> PostApplicationGroupTables(ApplicationGroupTables applicationGroupTables)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApplicationGroupTables.Add(applicationGroupTables);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ApplicationGroupTablesExists(applicationGroupTables.AppGroupTableID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = applicationGroupTables.AppGroupTableID }, applicationGroupTables);
        }

        // DELETE: api/ApplicationGroupTables/5
        [ResponseType(typeof(ApplicationGroupTables))]
        public async Task<IHttpActionResult> DeleteApplicationGroupTables(Guid id)
        {
            ApplicationGroupTables applicationGroupTables = await db.ApplicationGroupTables.FindAsync(id);
            if (applicationGroupTables == null)
            {
                return NotFound();
            }

            db.ApplicationGroupTables.Remove(applicationGroupTables);
            await db.SaveChangesAsync();

            return Ok(applicationGroupTables);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationGroupTablesExists(Guid id)
        {
            return db.ApplicationGroupTables.Count(e => e.AppGroupTableID == id) > 0;
        }
    }
}