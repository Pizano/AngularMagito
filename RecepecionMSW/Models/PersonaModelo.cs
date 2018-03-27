using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecepecionMSW.Models
{
    public class PersonaModelo
    {
        [Required]
        public int Id_Persona { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100)]
        public string TelefonoFijo { get; set; }
       
        [StringLength(100)]
        public string TelefonoCelular { get; set; }
        [Required]
        [StringLength(100)]
        public string Correo { get; set; }
        [StringLength(100)]
        public string Empresa { get; set; }
        [StringLength(100)]
        public string Dependencia { get; set; }




    }
    public class AgregarPersonaModelo
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100)]
        public string TelefonoFijo { get; set; }
        
        [StringLength(100)]
        public string TelefonoCelular { get; set; }
        [Required]
        [StringLength(100)]
        public string Correo { get; set; }
        [StringLength(100)]
        public string Empresa { get; set; }
        [StringLength(100)]
        public string Dependencia { get; set; }
    }

    public class EditarPersonaModelo
    {
        [Required]
        public int Id_Persona { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(100)]
        [Required]
        public string TelefonoFijo { get; set; }
        
        [StringLength(100)]
        public string TelefonoCelular { get; set; }
        [Required]
        [StringLength(100)]
        public string Correo { get; set; }
        [StringLength(100)]
        public string Empresa { get; set; }
        [StringLength(100)]
        public string Dependencia { get; set; }
    }
    public class EliminarPersonaModelo
    {
        [Required]
        public int Id_Persona { get; set; }
    }

}