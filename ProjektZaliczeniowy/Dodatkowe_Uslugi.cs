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
    
    public partial class Dodatkowe_Uslugi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dodatkowe_Uslugi()
        {
            this.Dodatkowe_Oplaty = new HashSet<Dodatkowe_Oplaty>();
        }
    
        public int ID_uslugi { get; set; }
        public string Nazwa_Uslugi { get; set; }
        public decimal Cena { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dodatkowe_Oplaty> Dodatkowe_Oplaty { get; set; }
    }
}
