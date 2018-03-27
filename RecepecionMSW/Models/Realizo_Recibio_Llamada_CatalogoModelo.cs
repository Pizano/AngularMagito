using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RecepecionMSW.Models
{
    public class Realizo_Recibio_Llamada_CatalogoModelo
    {
        [Required]
        public int Id_RRLcatalogo { get; set; }
        [Required]
        [StringLength(100)]
        public string Tipo_Llamada_Estado { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}