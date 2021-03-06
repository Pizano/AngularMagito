//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecepecionMSW.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Registro_Llamadas
    {
        public int Id_Rllamadas { get; set; }
        [Required(ErrorMessage = "Seleccione alguna opcion")]
        public int Id_Lcatalogo { get; set; }
        [Required(ErrorMessage = "El campo debe se llenado")]
        public int Id_Persona { get; set; }
        public System.DateTime Fecha { get; set; }
        [Required]
        public string Usuario { get; set; }
        [DataType(DataType.MultilineText)]
        public string Notas { get; set; }
        public string NumSerieCampeon { get; set; }
        public string NumSerieSmart { get; set; }
        [Required(ErrorMessage = "Seleccione alguna opcion")]
        public int Id_RRLcatalogo { get; set; }
        [Required(ErrorMessage = "Seleccione alguna opcion")]
        public int Id_Acatalogo { get; set; }
    
        public virtual LLamada_Catalogo LLamada_Catalogo { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual Atendio_Catalogo Atendio_Catalogo { get; set; }
        public virtual Realizo_Recibio_Llamada_Catalogo Realizo_Recibio_Llamada_Catalogo { get; set; }
    }
}
