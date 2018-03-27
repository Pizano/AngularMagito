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
    
    public class PersonasAPIController : ApiController
    {
        private RecepcionMSWEntities db = new RecepcionMSWEntities();

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // GET: api/PersonasAPI
        public IQueryable<PersonaModelo> GetPersonas()
        {
            
            return db.Personas.ToList().Select(p => new PersonaModelo
            {
                Nombre = p.Nombre,
                Empresa = p.Empresa,
                Correo = p.Correo,
                TelefonoCelular = p.TelefonoCelular,
                TelefonoFijo = p.TelefonoFijo,
                Dependencia = p.Dependencia,
                Id_Persona = p.Id_Persona


            }).AsQueryable();
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // GET: api/PersonasAPI/5
        [ResponseType(typeof(PersonaModelo))]
        public async Task<IHttpActionResult> GetPersona(int id)
        {
            PersonaModelo persona = new PersonaModelo();
            Persona oPersona = await db.Personas.FindAsync(id);
            if (oPersona != null) {
                persona = new PersonaModelo
                {
                    Nombre = oPersona.Nombre,
                    Empresa = oPersona.Empresa,
                    Correo = oPersona.Correo,
                    TelefonoCelular = oPersona.TelefonoCelular,
                    TelefonoFijo = oPersona.TelefonoFijo,
                    Dependencia = oPersona.Dependencia,
                    Id_Persona = oPersona.Id_Persona
                };
            }
        
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // PUT: api/PersonasAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPersona(int id, Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona.Id_Persona)
            {
                return BadRequest();
            }

            db.Entry(persona).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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
        // POST: api/PersonasAPI
        [ResponseType(typeof(PersonaModelo))]
        public async Task<IHttpActionResult> PostPersona(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personas.Add(persona);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = persona.Id_Persona }, persona);
        }
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        // DELETE: api/PersonasAPI/5
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> DeletePersona(int id)
        {


            Persona persona = await db.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            db.Personas.Remove(persona);
            await db.SaveChangesAsync();

            return Ok(persona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonaExists(int id)
        {
            return db.Personas.Count(e => e.Id_Persona == id) > 0;
        }
    }
}