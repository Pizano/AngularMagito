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
    public class Registro_LlamadasAPIController : ApiController
    {
        private RecepcionMSWEntities db = new RecepcionMSWEntities();

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // GET: api/Registro_LlamadasAPI
        public IQueryable<Registro_LlamadasModelo> GetRegistro_Llamadas()
        {
            var a = db.Registro_Llamadas.ToList().Select(p => new Registro_LlamadasModelo
            {   
                Id_Lcatalogo = p.Id_Lcatalogo,
                Llamada = p.LLamada_Catalogo.Tipo_Llamada,
                Id_Persona = p.Id_Persona,
                Nombre = p.Persona.Nombre,
                Id_RRLcatalogo = p.Id_RRLcatalogo,
                Realizo = p.Realizo_Recibio_Llamada_Catalogo.Tipo_Llamada_Estado,
                Id_Acatalogo = p.Id_Acatalogo,
                Atendio = p.Atendio_Catalogo.Estado_Llamada,
                Id_Rllamadas = p.Id_Rllamadas,
                Fecha = p.Fecha,
                Usuario = p.Usuario,
                Notas = p.Notas,
                NumSerieCampeon = p.NumSerieCampeon,
                NumSerieSmart = p.NumSerieSmart,

            }).AsQueryable();

            return a;

            //return db.Registro_Llamadas;
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // GET: api/Registro_LlamadasAPI/5
        [ResponseType(typeof(Registro_LlamadasModelo))]
        public async Task<IHttpActionResult> GetRegistro_Llamadas(int id)
        {
            Registro_LlamadasModelo llamada = new Registro_LlamadasModelo();
            Registro_Llamadas p = await db.Registro_Llamadas.FindAsync(id);
            if (p != null)
            {
                llamada = new Registro_LlamadasModelo
                {
                    Id_Lcatalogo = p.Id_Lcatalogo,
                Llamada = p.LLamada_Catalogo.Tipo_Llamada,
                Id_Persona = p.Id_Persona,
                Nombre = p.Persona.Nombre,
                Id_RRLcatalogo = p.Id_RRLcatalogo,
                Realizo = p.Realizo_Recibio_Llamada_Catalogo.Tipo_Llamada_Estado,
                Id_Acatalogo = p.Id_Acatalogo,
                Atendio = p.Atendio_Catalogo.Estado_Llamada,
                Id_Rllamadas = p.Id_Rllamadas,
                Fecha = p.Fecha,
                Usuario = p.Usuario,
                Notas = p.Notas,
                NumSerieCampeon = p.NumSerieCampeon,
                NumSerieSmart = p.NumSerieSmart,
                 
                };
            }
            
            if (llamada == null)
            {
                return NotFound();
            }

            return Ok(llamada);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // PUT: api/Registro_LlamadasAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRegistro_Llamadas(int id, Registro_Llamadas registro_Llamadas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registro_Llamadas.Id_Rllamadas)
            {
                return BadRequest();
            }

            db.Entry(registro_Llamadas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Registro_LlamadasExists(id))
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
        // POST: api/Registro_LlamadasAPI
        [ResponseType(typeof(Registro_LlamadasModelo))]
        public async Task<IHttpActionResult> PostRegistro_Llamadas(Registro_Llamadas registro_Llamadas)
        {
            registro_Llamadas.Fecha = DateTime.Now;


            if (ModelState.IsValid)
            {

                db.Registro_Llamadas.Add(registro_Llamadas);
                await db.SaveChangesAsync();

                using (RecepcionMSWEntities db = new RecepcionMSWEntities())
                {
                    Numeros_Serie nums = await db.Numeros_Serie.FirstOrDefaultAsync(x => x.NumSerieCampeon.Equals(registro_Llamadas.NumSerieCampeon));
                    Numeros_Serie numc = await db.Numeros_Serie.FirstOrDefaultAsync(x => x.NumSerieSmart.Equals(registro_Llamadas.NumSerieSmart));

                    if (nums != null && numc != null)
                    {

                    }
                    else
                    {
                        var Numero_Serie = new Numeros_Serie()
                        {
                            Id_Persona = registro_Llamadas.Id_Persona,
                            NumSerieCampeon = registro_Llamadas.NumSerieCampeon,
                            NumSerieSmart = registro_Llamadas.NumSerieSmart,
                            Fecha = registro_Llamadas.Fecha
                        };
                        db.Numeros_Serie.Add(Numero_Serie);
                        await db.SaveChangesAsync();
                    }

                }
            
            }

            return CreatedAtRoute("DefaultApi", new { id = registro_Llamadas.Id_Rllamadas }, registro_Llamadas);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // DELETE: api/Registro_LlamadasAPI/5
        [ResponseType(typeof(Registro_Llamadas))]
        public async Task<IHttpActionResult> DeleteRegistro_Llamadas(int id)
        {
            Registro_Llamadas registro_Llamadas = await db.Registro_Llamadas.FindAsync(id);
            if (registro_Llamadas == null)
            {
                return NotFound();
            }

            db.Registro_Llamadas.Remove(registro_Llamadas);
            await db.SaveChangesAsync();

            return Ok(registro_Llamadas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Registro_LlamadasExists(int id)
        {
            return db.Registro_Llamadas.Count(e => e.Id_Rllamadas == id) > 0;
        }
    }
}