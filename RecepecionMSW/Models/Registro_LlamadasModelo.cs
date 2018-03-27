using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecepecionMSW.Models
{
    public class Registro_LlamadasModelo
    {
        
     
        

        public int Id_Rllamadas { get; set; }
        [Required]
        public int Id_Lcatalogo { get; set; }
        [Required]
        public int Id_Persona { get; set; }
        //[Required]
        //public int Id_PCatalogo { get; set; }
        [Required]
        public int Id_RRLcatalogo { get; set; }
        [Required]
        public int Id_Acatalogo { get; set; }
     
        public DateTime Fecha { get; set; }
        [Required]
        [StringLength(100)]
        public string Usuario { get; set; }
        [StringLength(250)]
        public string Notas { get; set; }
        [StringLength(30)]
        public string NumSerieCampeon { get; set; }
        [StringLength(30)]
        public string NumSerieSmart { get; set; }

        public string Nombre { get; set; }
        public string Realizo { get; set; }
        public string Atendio { get; set; }
        public string Llamada { get; set; }

        //[Required]
        //[StringLength(100)]
        //public string Atendido { get; set; }
    }
    public class AgregarRegistro_LlamadasModelo
    {
        [DisplayName("Origen de la Llamada.")]
        [Required]
        public int Id_Lcatalogo { get; set; }
        [DisplayName("Nombre del la persona.")]
        [Required]
        public int Id_Persona { get; set; }
        //[Required]
        //public int Id_PCatalogo { get; set; }
        [DisplayName("Origen de la llamada")]
        [Required]
        public int Id_RRLcatalogo { get; set; }
        [DisplayName("Estado de la llamada")]
        [Required]
        public int Id_Acatalogo { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [DisplayName("Nombre de la persona que atendio la llamada")]
        [Required]
        [StringLength(100)]
        public string Usuario { get; set; }
        [DisplayName("Notas")]
        [StringLength(250)]
        public string Notas { get; set; }
        [DisplayName("Numero de Serie de Campeon 8")]
        [StringLength(30)]
        public string NumSerieCampeon { get; set; }
        [DisplayName("Numero de Serie de Campeon Smart")]
        [StringLength(30)]
        public string NumSerieSmart { get; set; }
        //[Required]
        //[StringLength(100)]
        //public string Atendido { get; set; }
    }
    public class EditarRegistro_LlamadasModelo
    {
       
       
        [Required]
        public int Id_Rllamadas { get; set; }
        [Required]
        public int Id_Lcatalogo { get; set; }
        [Required]
        public int Id_Persona { get; set; }
        //[Required]
        //public int Id_PCatalogo { get; set; }
        [Required]
        public int Id_RRLcatalogo { get; set; }
        [Required]
        public int Id_Acatalogo { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        [StringLength(100)]
        public string Usuario { get; set; }
        [StringLength(250)]
        public string Notas { get; set; }
        [StringLength(30)]
        public string NumSerieCampeon { get; set; }
        [StringLength(30)]
        public string NumSerieSmart { get; set; }
        //[Required]
        //[StringLength(100)]
        //public string Atendido { get; set; }
    }
    public class EliminarRegistro_LlamadasModelo
    {
        [Required]
        public int Id_Rllamadas { get; set; }
    }

}