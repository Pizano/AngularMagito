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
    
    public partial class Realizo_Recibio_Llamada_Catalogo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Realizo_Recibio_Llamada_Catalogo()
        {
            this.Registro_Llamadas = new HashSet<Registro_Llamadas>();
        }
    
        public int Id_RRLcatalogo { get; set; }
        public string Tipo_Llamada_Estado { get; set; }
        public string Descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registro_Llamadas> Registro_Llamadas { get; set; }
    }
}