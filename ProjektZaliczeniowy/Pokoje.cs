//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjektZaliczeniowy
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pokoje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pokoje()
        {
            this.Historia_Rezerwacji = new HashSet<Historia_Rezerwacji>();
        }
    
        public int ID_Pokoju { get; set; }
        public int Nr_Pokoju { get; set; }
        public int Typ_Pokoju { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historia_Rezerwacji> Historia_Rezerwacji { get; set; }
        public virtual Typ_Pokoju Typ_Pokoju1 { get; set; }
    }
}
