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
    public class Realizo_Recibio_Llamada_CatalogoAPIController : ApiController
    {
        private RecepcionMSWEntities db = new RecepcionMSWEntities();

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // GET: api/Realizo_Recibio_Llamada_CatalogoAPI
        public IQueryable<Realizo_Recibio_Llamada_CatalogoModelo> GetRealizo_Recibio_Llamada_Catalogo()
        {
            return db.Realizo_Recibio_Llamada_Catalogo.ToList().Select(p => new Realizo_Recibio_Llamada_CatalogoModelo
            {
                Id_RRLcatalogo = p.Id_RRLcatalogo,
                Tipo_Llamada_Estado = p.Tipo_Llamada_Estado,
                Descripcion = p.Descripcion

            }).AsQueryable();

        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // GET: api/Realizo_Recibio_Llamada_CatalogoAPI/5
        [ResponseType(typeof(Realizo_Recibio_Llamada_CatalogoModelo))]
        public async Task<IHttpActionResult> GetRealizo_Recibio_Llamada_Catalogo(int id)
        {
            Realizo_Recibio_Llamada_CatalogoModelo rrlcatalogo = new Realizo_Recibio_Llamada_CatalogoModelo();
            Realizo_Recibio_Llamada_Catalogo oRRLcatalogo = await db.Realizo_Recibio_Llamada_Catalogo.FindAsync(id);
            if (oRRLcatalogo != null) {
                rrlcatalogo = new Realizo_Recibio_Llamada_CatalogoModelo
                {
                    Id_RRLcatalogo = oRRLcatalogo.Id_RRLcatalogo,
                    Tipo_Llamada_Estado = oRRLcatalogo.Tipo_Llamada_Estado,
                    Descripcion = oRRLcatalogo.Descripcion
                };
            }
            if (rrlcatalogo == null)
            {
                return NotFound();
            }

            return Ok(rrlcatalogo);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // PUT: api/Realizo_Recibio_Llamada_CatalogoAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRealizo_Recibio_Llamada_Catalogo(int id, Realizo_Recibio_Llamada_Catalogo realizo_Recibio_Llamada_Catalogo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != realizo_Recibio_Llamada_Catalogo.Id_RRLcatalogo)
            {
                return BadRequest();
            }

            db.Entry(realizo_Recibio_Llamada_Catalogo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Realizo_Recibio_Llamada_CatalogoExists(id))
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
        // POST: api/Realizo_Recibio_Llamada_CatalogoAPI
        [ResponseType(typeof(Realizo_Recibio_Llamada_Catalogo))]
        public async Task<IHttpActionResult> PostRealizo_Recibio_Llamada_Catalogo(Realizo_Recibio_Llamada_Catalogo realizo_Recibio_Llamada_Catalogo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Realizo_Recibio_Llamada_Catalogo.Add(realizo_Recibio_Llamada_Catalogo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = realizo_Recibio_Llamada_Catalogo.Id_RRLcatalogo }, realizo_Recibio_Llamada_Catalogo);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // DELETE: api/Realizo_Recibio_Llamada_CatalogoAPI/5
        [ResponseType(typeof(Realizo_Recibio_Llamada_Catalogo))]
        public async Task<IHttpActionResult> DeleteRealizo_Recibio_Llamada_Catalogo(int id)
        {
            Realizo_Recibio_Llamada_Catalogo realizo_Recibio_Llamada_Catalogo = await db.Realizo_Recibio_Llamada_Catalogo.FindAsync(id);
            if (realizo_Recibio_Llamada_Catalogo == null)
            {
                return NotFound();
            }

            db.Realizo_Recibio_Llamada_Catalogo.Remove(realizo_Recibio_Llamada_Catalogo);
            await db.SaveChangesAsync();

            return Ok(realizo_Recibio_Llamada_Catalogo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Realizo_Recibio_Llamada_CatalogoExists(int id)
        {
            return db.Realizo_Recibio_Llamada_Catalogo.Count(e => e.Id_RRLcatalogo == id) > 0;
        }
    }
}