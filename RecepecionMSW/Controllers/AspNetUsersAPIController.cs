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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RecepecionMSW.Models;

namespace RecepecionMSW.Controllers
{
    [Authorize]
    public class AspNetUsersAPIController : ApiController
    {
        private RecepcionMSWEntities db = new RecepcionMSWEntities();
        public ApplicationDbContext context = new ApplicationDbContext();

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // GET: api/AspNetUsersAPI
        public IQueryable<UsuariosModel> GetAspNetUsers()
        {

            return db.AspNetUsers.ToList().Select(p => new UsuariosModel {
                Id = p.Id,
                UserName = p.UserName,
                Email = p.Email,
                Rol = p.AspNetRoles.Count > 0? p.AspNetRoles.ElementAt(0).Name: "Sin Rol"
            }).AsQueryable();
           
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // GET: api/AspNetUsersAPI/5
        [ResponseType(typeof(UsuariosModel))]
        public async Task<IHttpActionResult> GetAspNetUser(string id)
        {
            UsuariosModel usuariosModel = new UsuariosModel();
            AspNetUser oUsuariosModel = await db.AspNetUsers.FindAsync(id);
            if (oUsuariosModel != null) {
                usuariosModel= new UsuariosModel
                {
                    Id = oUsuariosModel.Id,
                    UserName = oUsuariosModel.UserName,
                    Email = oUsuariosModel.Email,
                    Rol = oUsuariosModel.AspNetRoles.Count > 0 ? oUsuariosModel.AspNetRoles.ElementAt(0).Name : "Sin Rol"
                };
            }
            if (usuariosModel == null)
            {
                return NotFound();
            }

            return Ok(usuariosModel);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // PUT: api/AspNetUsersAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAspNetUser(string id, AspNetUser aspNetUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspNetUser.Id)
            {
                return BadRequest();
            }

            db.Entry(aspNetUser).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUserExists(id))
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

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // POST: api/AspNetUsersAPI
        [ResponseType(typeof(AspNetUser))]
        public async Task<IHttpActionResult> PostAspNetUser(AspNetUser aspNetUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser { UserName = aspNetUser.UserName, Email = aspNetUser.Email };
            var result = await UserManager.CreateAsync(user, aspNetUser.PasswordHash);

            if (result.Succeeded)
            {
                await UserManager.AddToRoleAsync(user.Id, "AppUser");


            }
            //db.AspNetUsers.Add(aspNetUser);

           
                //await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetUserExists(aspNetUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aspNetUser.Id }, aspNetUser);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // DELETE: api/AspNetUsersAPI/5
        [ResponseType(typeof(AspNetUser))]
        public async Task<IHttpActionResult> DeleteAspNetUser(string id)
        {
            AspNetUser aspNetUser = await db.AspNetUsers.FindAsync(id);
            if (aspNetUser == null)
            {
                return NotFound();
            }

            db.AspNetUsers.Remove(aspNetUser);
            await db.SaveChangesAsync();

            return Ok(aspNetUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AspNetUserExists(string id)
        {
            return db.AspNetUsers.Count(e => e.Id == id) > 0;
        }
    }
}