using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecepecionMSW.Models;

namespace RecepecionMSW.Controllers
{
    public class PersonasController : Controller
    {
        private RecepcionMSWEntities db = new RecepcionMSWEntities();

        // GET: Personas
        public async Task<ActionResult> Index()
        {
            return View(await db.Personas.OrderByDescending( x => x.Id_Persona).ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = await db.Personas.FindAsync(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_Persona,Nombre,TelefonoFijo,TelefonoCelular,Correo,Empresa,Dependencia,LadaCelular,LadaFijo")] Persona persona)
        {

            using (RecepcionMSWEntities db = new RecepcionMSWEntities())
            {
                Persona No = await db.Personas.FirstOrDefaultAsync(x => x.Nombre.Equals(persona.Nombre));
                Persona Co = await db.Personas.FirstOrDefaultAsync(x => x.Correo.Equals(persona.Correo));
                Persona De = await db.Personas.FirstOrDefaultAsync(x => x.Dependencia.Equals(persona.Dependencia));
                Persona Em = await db.Personas.FirstOrDefaultAsync(x => x.Empresa.Equals(persona.Empresa));
                Persona Tf = await db.Personas.FirstOrDefaultAsync(x => x.TelefonoFijo.Equals(persona.TelefonoFijo));
                Persona Tc = await db.Personas.FirstOrDefaultAsync(x => x.TelefonoCelular.Equals(persona.TelefonoCelular));
                Persona Lc = await db.Personas.FirstOrDefaultAsync(x => x.LadaCelular.Equals(persona.LadaCelular));
                Persona Lf = await db.Personas.FirstOrDefaultAsync(x => x.LadaFijo.Equals(persona.LadaFijo));


                if (No != null && Co != null && De != null && Em != null && Tf != null && Tc != null && Lc != null && Lf != null )
                {
                    Response.Write("<script>window.alert('No puedes registrar a dos personas con los mismos datos');" + "</script>" + 
                                   "<script>window.setTimeout(location.href='Create', 2000);</script>");
                    return View(persona);
                }
            }
            if (ModelState.IsValid)
            {
                db.Personas.Add(persona);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = await db.Personas.FindAsync(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Persona,Nombre,TelefonoFijo,TelefonoCelular,Correo,Empresa,Dependencia,LadaCelular,LadaFijo")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = await db.Personas.FindAsync(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Persona persona = await db.Personas.FindAsync(id);
            
            using (RecepcionMSWEntities db = new RecepcionMSWEntities())
            {
                Registro_Llamadas oRegistro_llamadas = await db.Registro_Llamadas.FirstOrDefaultAsync(m => m.Id_Persona.Equals(id));
                
                if (oRegistro_llamadas != null)
                {

                    Response.Write("<script>window.alert('No puedes eliminar una persona, que tiene registros en llamadas.');" + "</script>" +
                                   "<script>window.setTimeout(location.href='/Personas/Index', 2000);</script>");
                 
                    return View(persona);
                }
            }
            db.Personas.Remove(persona);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
        public JsonResult BuscarPersonas(string search )
      {
            
            //using (RecepcionMSWEntities db = new RecepcionMSWEntities()) {
            //    //var a = db.Personas.GroupBy(s => s.Nombre.Equals(db.Per)).Select(g => g.Count());
            //    var q = db.Personas.GroupBy(s => s.Nombre).Count();
            //    if (q > 1) {
                    
            //        List<PersonaModelo> allsearchs = db.Personas.Where(x => x.Nombre.Contains(search)).Select(x => new PersonaModelo
                    
            //            {
            //                Id_Persona = x.Id_Persona,
            //            Nombre = x.Nombre,
            //            Correo = x.Correo
            //            }).ToList();
                    
            //        return new JsonResult { Data = allsearchs, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            //    }
            //}

                List<PersonaModelo> allsearch = db.Personas.Where(x => x.Nombre.Contains(search)).Select(x => new PersonaModelo
                {
                    Id_Persona = x.Id_Persona,
                    Nombre = x.Nombre,
                    Correo = x.Correo
                }).ToList();

            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpGet]
         public ActionResult GetUserData(int userID)
        {

            

            List<PersonaModelo> userName = db.Personas.Where(x => x.Id_Persona.Equals(userID)).Select(x => new PersonaModelo
            {
                Nombre = x.Nombre
            }).ToList();



            return new JsonResult { Data = userName, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpGet]
        public ActionResult GetUserNums(int userID)
        {

            List<Numeros_SerieModelo> userNums = db.Numeros_Serie.Where(x => x.Id_Persona.Equals(userID)).Select(x => new Numeros_SerieModelo
            {
                NumSerieCampeon = x.NumSerieCampeon,
                NumSerieSmart = x.NumSerieSmart,
            }).ToList();

            return new JsonResult { Data = userNums, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}
