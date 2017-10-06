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
    public class TablesController : ApiController
    {
        private BTSSWebContext db = new BTSSWebContext();

        // GET: api/Tables
        public IQueryable<Tables> GetTables()
        {
            return db.Tables;
        }

        // GET: api/Tables/5
        [ResponseType(typeof(Tables))]
        public async Task<IHttpActionResult> GetTables(int id)
        {
            Tables tables = await db.Tables.FindAsync(id);
            if (tables == null)
            {
                return NotFound();
            }

            return Ok(tables);
        }

        // PUT: api/Tables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTables(int id, Tables tables)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tables.TableID)
            {
                return BadRequest();
            }

            db.Entry(tables).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TablesExists(id))
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

        // POST: api/Tables
        [ResponseType(typeof(Tables))]
        public async Task<IHttpActionResult> PostTables(Tables tables)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tables.Add(tables);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tables.TableID }, tables);
        }

        // DELETE: api/Tables/5
        [ResponseType(typeof(Tables))]
        public async Task<IHttpActionResult> DeleteTables(int id)
        {
            Tables tables = await db.Tables.FindAsync(id);
            if (tables == null)
            {
                return NotFound();
            }

            db.Tables.Remove(tables);
            await db.SaveChangesAsync();

            return Ok(tables);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TablesExists(int id)
        {
            return db.Tables.Count(e => e.TableID == id) > 0;
        }
    }
}