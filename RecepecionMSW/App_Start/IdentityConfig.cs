using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using RecepecionMSW.Models;

namespace RecepecionMSW
{
    public class EmailService : IIdentityMessageService
    {


        //private string destinatario;
        //private string CCOAdmin;
        //private string Asunto;
        private string Mensaje = //mensaje que va en el body del correo electronico.
                        "<!DOCTYPE html>" + "<html lang='es'>" +
                        "<head>" +
                        "<meta http-equiv='Content-Type'content='text/html;charset=utf-8'>" +
                        "<style>" +
                        "p{text-align:justify;font-family:Arial;font-size:18px}" +
                        "</style>" +
                        "</head>" +
                        "<body>" +
                        "<p>Bienvenido a MSWRecepcion un sistema hecho a la medida de la administración de llamadas y control.</p>" +
                        "<p>Agradecemos su registro a nuestra plataforma.</p>" +
                        "<p>Dudas favor de comunicarte a los teléfonos:</p>" +
                        "<p> +52 (312) 312 33 83<br/> +52 (312) 312 80 98<br/></p>" +
                        "<p>Calzada del Campesino #265, San Pablo C.P. 28060, Colima, Colima, México</p>" +
                        "</body>" + "</html>";
        //private string rutaPDF;

        public Task SendAsync(IdentityMessage message)
        {
            // Conecte su servicio de correo electrónico aquí para enviar correo electrónico.
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("carlos.pizano@msw.com.mx", "MSWRecepcion Web-Admin");
            mail.To.Add(message.Destination);
            //MailAddress bcc = new MailAddress(CCOAdmin, "CampeónPlus Web-Admin");
            //mail.Bcc.Add(bcc);
            mail.Subject = message.Subject;
            mail.Body = Mensaje + message.Body;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            //mail.Attachments.Add(new Attachment(rutaPDF));
            mail.IsBodyHtml = true;
            //Configuracion del servidor SMTP de la empresa.                     
            SmtpClient smtp = new SmtpClient("msw.com.mx", 7777); // cliente y puerto
            smtp.Host = "msw.com.mx";
            smtp.Port = 7777;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            ("carlos.pizano@msw.com.mx", "_ceps"); // credenciales de usuario establecido como administrador.
            try
            {
                smtp.Send(mail); // para enviar el correo.
                Dispose();
            }
            catch (Exception ex) //excepcion para ver si existe algun error al mandar el correo.
            {
                var error = ex.Message;
            }
            return Task.FromResult(0);
        }

        private void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Conecte el servicio SMS aquí para enviar un mensaje de texto.
            return Task.FromResult(0);
        }
    }

    // Configure el administrador de usuarios de aplicación que se usa en esta aplicación. UserManager se define en ASP.NET Identity y se usa en la aplicación.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure la lógica de validación de nombres de usuario
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure la lógica de validación de contraseñas
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configurar valores predeterminados para bloqueo de usuario
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Registre proveedores de autenticación en dos fases. Esta aplicación usa los pasos Teléfono y Correo electrónico para recibir un código para comprobar el usuario
            // Puede escribir su propio proveedor y conectarlo aquí.
            manager.RegisterTwoFactorProvider("Código telefónico", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Su código de seguridad es {0}"
            });
            manager.RegisterTwoFactorProvider("Código de correo electrónico", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Código de seguridad",
                BodyFormat = "Su código de seguridad es {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure el administrador de inicios de sesión que se usa en esta aplicación.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
