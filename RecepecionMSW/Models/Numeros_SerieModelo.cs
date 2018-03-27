using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecepecionMSW.Models
{
    public class Numeros_SerieModelo
    {
        public int Id_NSerie { get; set; }
        public int Id_Persona { get; set; }
        public string NumSerieCampeon { get; set; }
        public string NumSerieSmart { get; set; }
        public DateTime Fecha { get; set; }
    }
}