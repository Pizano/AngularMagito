using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using RecepecionMSW.Models;
using System.Data.Entity;

namespace RecepecionMSW.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;
        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            string nameUser = string.Empty, idUsuario = string.Empty;
            string  respuesta = "true", mensaje = "Log in correcto.";


            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
            //string message = ""; // Meesage return

            // get information user
            ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);


            if (user == null)
            {
                //context.SetError("invalid_grant", "The user name or password is incorrect.");
                context.SetError("true", "Usuario/Contraseña incorrectos.");

                return;
            }
            nameUser = user.UserName;
            idUsuario = user.Id.ToString();
            
           
            // Jr
            // 24-nov-2017
            // Valore que regresa el login
            var roles = await userManager.GetRolesAsync(user.Id);
            if(roles.Count > 0)
            {
                //using (RecepcionMSWEntities db = new RecepcionMSWEntities())
                //{
                //    Cliente oCliente = await db.Clientes.FirstOrDefaultAsync(c=>c.Id_Cliente ==user.Id_Cliente );
                //    if (oCliente != null)
                //    {
                //        nombreCliente = oCliente.Nombre_Cliente;
                //        urlFoto = oCliente.Foto_Cliente;
                //    }
                //    else
                //    {
                //        respuesta = "false";
                //        mensaje = "No existe usuario.";
                //    }
                //}
            }
            

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager);
            ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager);

            // Ejecuta las propiedades a regresar   
            AuthenticationProperties properties = CreateProperties(nameUser, idUsuario,  respuesta, mensaje);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        // Aqui se genera el diccionario que regresa

        // nameUser, idCliente, emailUsuario, urlFoto, nombreCliente, respuesta, mensaje
        public static AuthenticationProperties CreateProperties(string nameUser, string idCliente, string respuesta, string mensaje)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", nameUser },
                { "idCliente", idCliente},
                { "respuesta", respuesta},
                { "mensaje", mensaje}
            };
            return new AuthenticationProperties(data);
        }
    }
}