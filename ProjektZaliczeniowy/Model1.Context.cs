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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HotelEntities : DbContext
    {
        public HotelEntities()
            : base("name=HotelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Dodatkowe_Oplaty> Dodatkowe_Oplaty { get; set; }
        public virtual DbSet<Dodatkowe_Uslugi> Dodatkowe_Uslugi { get; set; }
        public virtual DbSet<Goscie> Goscie { get; set; }
        public virtual DbSet<Historia_Rezerwacji> Historia_Rezerwacji { get; set; }
        public virtual DbSet<Pokoje> Pokoje { get; set; }
        public virtual DbSet<Pracownicy> Pracownicy { get; set; }
        public virtual DbSet<Typ_Pokoju> Typ_Pokoju { get; set; }
    }
}
