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
    
    public partial class Typ_Pokoju
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Typ_Pokoju()
        {
            this.Pokoje = new HashSet<Pokoje>();
        }
    
        public int ID_Typu_Pokoju { get; set; }
        public int Liczba_osob { get; set; }
        public decimal Cena_Doba { get; set; }
        public string Opis { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pokoje> Pokoje { get; set; }
    }
}
