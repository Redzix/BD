﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BD
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bazaEntities : DbContext
    {
        public bazaEntities()
            : base("name=bazaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Kierowca> Kierowca { get; set; }
        public virtual DbSet<Kierownik> Kierownik { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Miejsce> Miejsce { get; set; }
        public virtual DbSet<Opinia> Opinia { get; set; }
        public virtual DbSet<Panel_pracowniczy> Panel_pracowniczy { get; set; }
        public virtual DbSet<Pilot> Pilot { get; set; }
        public virtual DbSet<Pojazd> Pojazd { get; set; }
        public virtual DbSet<Reklamacja> Reklamacja { get; set; }
        public virtual DbSet<Rezerwacja> Rezerwacja { get; set; }
        public virtual DbSet<Uczestnictwo> Uczestnictwo { get; set; }
        public virtual DbSet<Wycieczka> Wycieczka { get; set; }
        public virtual DbSet<Promocja> Promocja { get; set; }
        public virtual DbSet<Katalog> Katalog { get; set; }
    }
}
