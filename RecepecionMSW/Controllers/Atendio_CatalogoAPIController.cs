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
using RecepecionMSW.Models;

namespace RecepecionMSW.Controllers
{
    [Authorize]
    public class Atendio_CatalogoAPIController : ApiController
    {
        private RecepcionMSWEntities db = new RecepcionMSWEntities();

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // GET: api/Atendio_CatalogoAPI
        public IQueryable<Atendio_CatalogoModelo> GetAtendio_Catalogo()
        {
            return db.Atendio_Catalogo.ToList().Select(p => new Atendio_CatalogoModelo {
                Id_Acatalogo = p.Id_Acatalogo,
                Estado_Llamada = p.Estado_Llamada,
                Descripcion = p.Descripcion
            }).AsQueryable();
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // GET: api/Atendio_CatalogoAPI/5
        [ResponseType(typeof(Atendio_CatalogoModelo))]
        public async Task<IHttpActionResult> GetAtendio_Catalogo(int id)
        {
            Atendio_CatalogoModelo atendiocatalogo = new Atendio_CatalogoModelo();
            Atendio_Catalogo oAtendiocatalogo = await db.Atendio_Catalogo.FindAsync(id);
            if ( oAtendiocatalogo != null) {
                atendiocatalogo = new Atendio_CatalogoModelo
                {
                    Id_Acatalogo = oAtendiocatalogo.Id_Acatalogo,
                    Estado_Llamada = oAtendiocatalogo.Estado_Llamada,
                    Descripcion = oAtendiocatalogo.Descripcion
                };
            }
            if (atendiocatalogo == null)
            {
                return NotFound();
            }

            return Ok(atendiocatalogo);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // PUT: api/Atendio_CatalogoAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAtendio_Catalogo(int id, Atendio_Catalogo atendio_Catalogo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != atendio_Catalogo.Id_Acatalogo)
            {
                return BadRequest();
            }

            db.Entry(atendio_Catalogo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Atendio_CatalogoExists(id))
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
        // POST: api/Atendio_CatalogoAPI
        [ResponseType(typeof(Atendio_Catalogo))]
        public async Task<IHttpActionResult> PostAtendio_Catalogo(Atendio_Catalogo atendio_Catalogo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Atendio_Catalogo.Add(atendio_Catalogo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = atendio_Catalogo.Id_Acatalogo }, atendio_Catalogo);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // DELETE: api/Atendio_CatalogoAPI/5
        [ResponseType(typeof(Atendio_Catalogo))]
        public async Task<IHttpActionResult> DeleteAtendio_Catalogo(int id)
        {
            Atendio_Catalogo atendio_Catalogo = await db.Atendio_Catalogo.FindAsync(id);
            if (atendio_Catalogo == null)
            {
                return NotFound();
            }

            db.Atendio_Catalogo.Remove(atendio_Catalogo);
            await db.SaveChangesAsync();

            return Ok(atendio_Catalogo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Atendio_CatalogoExists(int id)
        {
            return db.Atendio_Catalogo.Count(e => e.Id_Acatalogo == id) > 0;
        }
    }
}