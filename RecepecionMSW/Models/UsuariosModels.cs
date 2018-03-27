using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecepecionMSW.Models
{
    public class UsuariosModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Usuario")]
        public string UserName { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "El correo no es valido")]
        public string Email { get; set; }
        public string Rol { get; set; }
        [Required]
        [DisplayName("Contraseña")]
        public string PasswordHash { get; set; }

        //public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
    }
}