//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventarioAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class modelos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public modelos()
        {
            this.equipos = new HashSet<equipos>();
        }
    
        public int id_modelo { get; set; }
        public string modelo { get; set; }
        public Nullable<int> id_marca { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<equipos> equipos { get; set; }
        public virtual marcas marcas { get; set; }
    }
}
