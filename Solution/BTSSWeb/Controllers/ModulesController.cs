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
    public class ModulesController : ApiController
    {
        private BTSSWebContext db = new BTSSWebContext();

        // GET: api/Modules
        public IQueryable<Modules> GetModules()
        {
            return db.Modules;
        }

        // GET: api/Modules/5
        [ResponseType(typeof(Modules))]
        public async Task<IHttpActionResult> GetModules(int id)
        {
            Modules modules = await db.Modules.FindAsync(id);
            if (modules == null)
            {
                return NotFound();
            }

            return Ok(modules);
        }

        // PUT: api/Modules/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutModules(int id, Modules modules)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modules.ModuleID)
            {
                return BadRequest();
            }

            db.Entry(modules).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModulesExists(id))
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

        // POST: api/Modules
        [ResponseType(typeof(Modules))]
        public async Task<IHttpActionResult> PostModules(Modules modules)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Modules.Add(modules);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = modules.ModuleID }, modules);
        }

        // DELETE: api/Modules/5
        [ResponseType(typeof(Modules))]
        public async Task<IHttpActionResult> DeleteModules(int id)
        {
            Modules modules = await db.Modules.FindAsync(id);
            if (modules == null)
            {
                return NotFound();
            }

            db.Modules.Remove(modules);
            await db.SaveChangesAsync();

            return Ok(modules);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModulesExists(int id)
        {
            return db.Modules.Count(e => e.ModuleID == id) > 0;
        }
    }
}