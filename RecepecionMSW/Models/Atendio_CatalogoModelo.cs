using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecepecionMSW.Models
{
    public class Atendio_CatalogoModelo
    {
        [Required]
        public int Id_Acatalogo { get; set; }
        [Required]
        [StringLength(100)]
        public string Estado_Llamada { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}