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
    public class ApplicationGroupModulesController : ApiController
    {
        private BTSSWebContext db = new BTSSWebContext();

        // GET: api/ApplicationGroupModules
        public IQueryable<ApplicationGroupModules> GetApplicationGroupModules()
        {
            return db.ApplicationGroupModules;
        }

        // GET: api/ApplicationGroupModules/5
        [ResponseType(typeof(ApplicationGroupModules))]
        public async Task<IHttpActionResult> GetApplicationGroupModules(Guid id)
        {
            ApplicationGroupModules applicationGroupModules = await db.ApplicationGroupModules.FindAsync(id);
            if (applicationGroupModules == null)
            {
                return NotFound();
            }

            return Ok(applicationGroupModules);
        }

        // PUT: api/ApplicationGroupModules/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutApplicationGroupModules(Guid id, ApplicationGroupModules applicationGroupModules)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicationGroupModules.AppGroupModuleID)
            {
                return BadRequest();
            }

            db.Entry(applicationGroupModules).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationGroupModulesExists(id))
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

        // POST: api/ApplicationGroupModules
        [ResponseType(typeof(ApplicationGroupModules))]
        public async Task<IHttpActionResult> PostApplicationGroupModules(ApplicationGroupModules applicationGroupModules)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApplicationGroupModules.Add(applicationGroupModules);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ApplicationGroupModulesExists(applicationGroupModules.AppGroupModuleID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = applicationGroupModules.AppGroupModuleID }, applicationGroupModules);
        }

        // DELETE: api/ApplicationGroupModules/5
        [ResponseType(typeof(ApplicationGroupModules))]
        public async Task<IHttpActionResult> DeleteApplicationGroupModules(Guid id)
        {
            ApplicationGroupModules applicationGroupModules = await db.ApplicationGroupModules.FindAsync(id);
            if (applicationGroupModules == null)
            {
                return NotFound();
            }

            db.ApplicationGroupModules.Remove(applicationGroupModules);
            await db.SaveChangesAsync();

            return Ok(applicationGroupModules);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationGroupModulesExists(Guid id)
        {
            return db.ApplicationGroupModules.Count(e => e.AppGroupModuleID == id) > 0;
        }
    }
}