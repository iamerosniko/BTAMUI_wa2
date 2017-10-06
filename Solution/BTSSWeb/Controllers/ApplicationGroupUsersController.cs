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
    public class ApplicationGroupUsersController : ApiController
    {
        private BTSSWebContext db = new BTSSWebContext();

        // GET: api/ApplicationGroupUsers
        public IQueryable<ApplicationGroupUsers> GetApplicationGroupUsers()
        {
            return db.ApplicationGroupUsers;
        }

        // GET: api/ApplicationGroupUsers/5
        [ResponseType(typeof(ApplicationGroupUsers))]
        public async Task<IHttpActionResult> GetApplicationGroupUsers(Guid id)
        {
            ApplicationGroupUsers applicationGroupUsers = await db.ApplicationGroupUsers.FindAsync(id);
            if (applicationGroupUsers == null)
            {
                return NotFound();
            }

            return Ok(applicationGroupUsers);
        }

        // PUT: api/ApplicationGroupUsers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutApplicationGroupUsers(Guid id, ApplicationGroupUsers applicationGroupUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicationGroupUsers.AppGroupUserID)
            {
                return BadRequest();
            }

            db.Entry(applicationGroupUsers).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationGroupUsersExists(id))
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

        // POST: api/ApplicationGroupUsers
        [ResponseType(typeof(ApplicationGroupUsers))]
        public async Task<IHttpActionResult> PostApplicationGroupUsers(ApplicationGroupUsers applicationGroupUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApplicationGroupUsers.Add(applicationGroupUsers);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ApplicationGroupUsersExists(applicationGroupUsers.AppGroupUserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = applicationGroupUsers.AppGroupUserID }, applicationGroupUsers);
        }

        // DELETE: api/ApplicationGroupUsers/5
        [ResponseType(typeof(ApplicationGroupUsers))]
        public async Task<IHttpActionResult> DeleteApplicationGroupUsers(Guid id)
        {
            ApplicationGroupUsers applicationGroupUsers = await db.ApplicationGroupUsers.FindAsync(id);
            if (applicationGroupUsers == null)
            {
                return NotFound();
            }

            db.ApplicationGroupUsers.Remove(applicationGroupUsers);
            await db.SaveChangesAsync();

            return Ok(applicationGroupUsers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationGroupUsersExists(Guid id)
        {
            return db.ApplicationGroupUsers.Count(e => e.AppGroupUserID == id) > 0;
        }
    }
}