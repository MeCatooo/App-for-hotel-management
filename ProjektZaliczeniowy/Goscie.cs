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
    
    public partial class Goscie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Goscie()
        {
            this.Dodatkowe_Oplaty = new HashSet<Dodatkowe_Oplaty>();
            this.Historia_Rezerwacji = new HashSet<Historia_Rezerwacji>();
        }
    
        public int ID_Goscia { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Nr_Telefonu { get; set; }
        public string Pesel { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dodatkowe_Oplaty> Dodatkowe_Oplaty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historia_Rezerwacji> Historia_Rezerwacji { get; set; }
    }
}
