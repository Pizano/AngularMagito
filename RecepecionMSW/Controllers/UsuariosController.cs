using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RecepecionMSW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RecepecionMSW.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        RecepcionMSWEntities db = new RecepcionMSWEntities();
        public ApplicationDbContext context = new ApplicationDbContext();

        public async Task<ActionResult> Index()
        {
            var ListaUsuarios = db.AspNetUsers.Include(r => r.AspNetRoles);
            return View(await ListaUsuarios.ToListAsync());

            //var ListaUsuarios = await db.AspNetUsers.Select(x => new UsuariosModel { Usuario = x.UserName, Correo = x.Email }).ToListAsync();
             

            //return View(ListaUsuarios);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Agregar(UsuariosModel model)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
            var result = await UserManager.CreateAsync(user, model.PasswordHash);

            if (result.Succeeded)
            {
                await UserManager.AddToRoleAsync(user.Id, "AppUser");

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}