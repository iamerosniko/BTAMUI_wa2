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
    public class AuditsController : ApiController
    {
        private BTSSWebContext db = new BTSSWebContext();

        // GET: api/Audits
        public IQueryable<Audit> GetAudit()
        {
            return db.Audit;
        }

        // GET: api/Audits/5
        [ResponseType(typeof(Audit))]
        public async Task<IHttpActionResult> GetAudit(Guid id)
        {
            Audit audit = await db.Audit.FindAsync(id);
            if (audit == null)
            {
                return NotFound();
            }

            return Ok(audit);
        }

        // PUT: api/Audits/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAudit(Guid id, Audit audit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != audit.AuditID)
            {
                return BadRequest();
            }

            db.Entry(audit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditExists(id))
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

        // POST: api/Audits
        [ResponseType(typeof(Audit))]
        public async Task<IHttpActionResult> PostAudit(Audit audit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Audit.Add(audit);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AuditExists(audit.AuditID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = audit.AuditID }, audit);
        }

        // DELETE: api/Audits/5
        [ResponseType(typeof(Audit))]
        public async Task<IHttpActionResult> DeleteAudit(Guid id)
        {
            Audit audit = await db.Audit.FindAsync(id);
            if (audit == null)
            {
                return NotFound();
            }

            db.Audit.Remove(audit);
            await db.SaveChangesAsync();

            return Ok(audit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuditExists(Guid id)
        {
            return db.Audit.Count(e => e.AuditID == id) > 0;
        }
    }
}