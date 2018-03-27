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
    public class LLamada_CatalogoAPIController : ApiController
    {
        private RecepcionMSWEntities db = new RecepcionMSWEntities();

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // GET: api/LLamada_CatalogoAPI
        public IQueryable<Llamada_CatalogoModelo> GetLLamada_Catalogo()
        {
            return db.LLamada_Catalogo.ToList().Select(p => new Llamada_CatalogoModelo
            {
                Id_Lcatalogo = p.Id_Lcatalogo,
                Descripcion = p.Descripcion,
                Tipo_Llamada = p.Tipo_Llamada
           
            }).AsQueryable();
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // GET: api/LLamada_CatalogoAPI/5
        [ResponseType(typeof(Llamada_CatalogoModelo))]
        public async Task<IHttpActionResult> GetLLamada_Catalogo(int id)
        {
            Llamada_CatalogoModelo llamada = new Llamada_CatalogoModelo();
            LLamada_Catalogo olLamada_Catalogo = await db.LLamada_Catalogo.FindAsync(id);
            if (olLamada_Catalogo != null) {
                llamada = new Llamada_CatalogoModelo
                {
                    Id_Lcatalogo = olLamada_Catalogo.Id_Lcatalogo,
                    Descripcion = olLamada_Catalogo.Descripcion,
                    Tipo_Llamada = olLamada_Catalogo.Tipo_Llamada
                };
            }

            if (llamada == null)
            {
                return NotFound();
            }

            return Ok(llamada);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // PUT: api/LLamada_CatalogoAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLLamada_Catalogo(int id, LLamada_Catalogo lLamada_Catalogo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lLamada_Catalogo.Id_Lcatalogo)
            {
                return BadRequest();
            }

            db.Entry(lLamada_Catalogo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LLamada_CatalogoExists(id))
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
        // POST: api/LLamada_CatalogoAPI
        [ResponseType(typeof(LLamada_Catalogo))]
        public async Task<IHttpActionResult> PostLLamada_Catalogo(LLamada_Catalogo lLamada_Catalogo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LLamada_Catalogo.Add(lLamada_Catalogo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = lLamada_Catalogo.Id_Lcatalogo }, lLamada_Catalogo);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // DELETE: api/LLamada_CatalogoAPI/5
        [ResponseType(typeof(LLamada_Catalogo))]
        public async Task<IHttpActionResult> DeleteLLamada_Catalogo(int id)
        {
            LLamada_Catalogo lLamada_Catalogo = await db.LLamada_Catalogo.FindAsync(id);
            if (lLamada_Catalogo == null)
            {
                return NotFound();
            }

            db.LLamada_Catalogo.Remove(lLamada_Catalogo);
            await db.SaveChangesAsync();

            return Ok(lLamada_Catalogo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LLamada_CatalogoExists(int id)
        {
            return db.LLamada_Catalogo.Count(e => e.Id_Lcatalogo == id) > 0;
        }
    }
}