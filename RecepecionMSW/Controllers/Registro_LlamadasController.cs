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
using PagedList;

namespace RecepecionMSW.Controllers
{
    [Authorize]
    public class Registro_LlamadasController : Controller
    {
        private RecepcionMSWEntities db = new RecepcionMSWEntities();

        // GET: Registro_Llamadas
        public async Task<ActionResult> Index()
        {
            var registro_llamadas = db.Registro_Llamadas.Include(r => r.LLamada_Catalogo).Include(r => r.Persona);
            return View(await registro_llamadas.ToListAsync());
         
        }
        // GET: Registro_Llamadas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_Llamadas registro_Llamadas = await db.Registro_Llamadas.FindAsync(id);
            if (registro_Llamadas == null)
            {
                return HttpNotFound();
            }
            return View(registro_Llamadas);
        }
        // GET: Registro_Llamadas/Create
        public ActionResult Create()
        {
         

            ViewBag.Id_RRLcatalogo = new SelectList(db.Realizo_Recibio_Llamada_Catalogo, "Id_RRLcatalogo", "Tipo_Llamada_Estado");
            ViewBag.Id_Acatalogo = new SelectList(db.Atendio_Catalogo, "Id_Acatalogo", "Estado_Llamada");

            ViewBag.Id_Lcatalogo = new SelectList(db.LLamada_Catalogo, "Id_Lcatalogo", "Tipo_Llamada");
            
            ViewBag.Id_Persona = new SelectList(db.Personas, "Id_Persona", "Nombre");
            return View();
        }
        // POST: Registro_Llamadas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_Rllamadas,Id_Lcatalogo,Id_Persona,Id_RRLcatalogo,Id_Acatalogo,Usuario,Notas,NumSerieCampeon,NumSerieSmart")] Registro_Llamadas registro_Llamadas)
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
                return RedirectToAction("Index");
            }
           
            ViewBag.Id_RRLcatalogo = new SelectList(db.Realizo_Recibio_Llamada_Catalogo, "Id_RRLcatalogo", "Tipo_Llamada_Estado", registro_Llamadas.Id_RRLcatalogo);
            ViewBag.Id_Acatalogo = new SelectList(db.Atendio_Catalogo, "Id_Acatalogo", "Estado_Llamada", registro_Llamadas.Id_Acatalogo);
            ViewBag.Id_Lcatalogo = new SelectList(db.LLamada_Catalogo, "Id_Lcatalogo", "Tipo_Llamada", registro_Llamadas.Id_Lcatalogo);
            
            ViewBag.Id_Persona = new SelectList(db.Personas, "Id_Persona", "Nombre", registro_Llamadas.Id_Persona);
            return View(registro_Llamadas);
        }

        // GET: Registro_Llamadas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_Llamadas registro_Llamadas = await db.Registro_Llamadas.FindAsync(id);
            if (registro_Llamadas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_RRLcatalogo = new SelectList(db.Realizo_Recibio_Llamada_Catalogo, "Id_RRLcatalogo", "Tipo_Llamada_Estado", registro_Llamadas.Id_RRLcatalogo);
            ViewBag.Id_Acatalogo = new SelectList(db.Atendio_Catalogo, "Id_Acatalogo", "Estado_Llamada", registro_Llamadas.Id_Acatalogo);
            ViewBag.Id_Lcatalogo = new SelectList(db.LLamada_Catalogo, "Id_Lcatalogo", "Tipo_Llamada", registro_Llamadas.Id_Lcatalogo);

            ViewBag.Id_Persona = new SelectList(db.Personas, "Id_Persona", "Nombre", registro_Llamadas.Id_Persona);
            return View(registro_Llamadas);
        }

        // POST: Registro_Llamadas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Rllamadas,Id_Lcatalogo,Id_Persona,Id_RRLcatalogo,Id_Acatalogo,Usuario,Notas,NumSerieCampeon,NumSerieSmart")] Registro_Llamadas registro_Llamadas)
        {
            registro_Llamadas.Fecha = DateTime.Now;
            if (ModelState.IsValid)
            {


                db.Entry(registro_Llamadas).State = EntityState.Modified;
                await db.SaveChangesAsync();

                using (RecepcionMSWEntities db = new RecepcionMSWEntities())
                {
                    Numeros_Serie nums = await db.Numeros_Serie.FirstOrDefaultAsync(x => x.NumSerieSmart.Equals(registro_Llamadas.NumSerieSmart));
                    Numeros_Serie numc = await db.Numeros_Serie.FirstOrDefaultAsync(x => x.NumSerieCampeon.Equals(registro_Llamadas.NumSerieCampeon));
                    if (nums != null && numc != null)
                    {

                    }
                    else
                    {
                        var numeros_Serie = new Numeros_Serie()
                        {
                            Id_Persona = registro_Llamadas.Id_Persona,
                            NumSerieCampeon = registro_Llamadas.NumSerieCampeon,
                            NumSerieSmart = registro_Llamadas.NumSerieSmart,
                            Fecha = registro_Llamadas.Fecha
                        };
                        db.Numeros_Serie.Add(numeros_Serie);
                        await db.SaveChangesAsync();
                    }
                }
                    return RedirectToAction("Index");
            }
            var errorss = ModelState.Values.SelectMany(v => v.Errors);
            ViewBag.Id_RRLcatalogo = new SelectList(db.Realizo_Recibio_Llamada_Catalogo, "Id_RRLcatalogo", "Tipo_Llamada_Estado", registro_Llamadas.Id_RRLcatalogo);
            ViewBag.Id_Acatalogo = new SelectList(db.Atendio_Catalogo, "Id_Acatalogo", "Estado_Llamada", registro_Llamadas.Id_Acatalogo);
            ViewBag.Id_Lcatalogo = new SelectList(db.LLamada_Catalogo, "Id_Lcatalogo", "Tipo_Llamada", registro_Llamadas.Id_Lcatalogo);

            ViewBag.Id_Persona = new SelectList(db.Personas, "Id_Persona", "Nombre", registro_Llamadas.Id_Persona);

            return View(registro_Llamadas);
        }

        // GET: Registro_Llamadas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_Llamadas registro_Llamadas = await db.Registro_Llamadas.FindAsync(id);
            if (registro_Llamadas == null)
            {
                return HttpNotFound();
            }
            return View(registro_Llamadas);
        }

        // POST: Registro_Llamadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {

            Registro_Llamadas registro_Llamadas = await db.Registro_Llamadas.FindAsync(id);
            db.Registro_Llamadas.Remove(registro_Llamadas);
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
    }
}
