using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecepecionMSW.Models
{
    public class Llamada_CatalogoModelo
    {
        public int Id_Lcatalogo { get; set; }
        [Required]
        [StringLength(100)]
        public string Tipo_Llamada { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
    public class Agregar_Llamada_catalogoModelo
    {

        [Required]
        [StringLength(100)]
        public string Tipo_Llamada { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
    public class Editar_Llamada_catalogoModelo
    {
        [Required]
        public int Id_Lcatalogo { get; set; }
        [Required]
        [StringLength(100)]
        public string Tipo_Llamada { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
    public class Eliminar_Llamada_catalogoModelo
    {
        [Required]
        public int Id_Lcatalogo { get; set; }
    }

}