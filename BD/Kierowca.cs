//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Kierowca
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kierowca()
        {
            this.Panel_pracowniczy = new HashSet<Panel_pracowniczy>();
            this.Wycieczka = new HashSet<Wycieczka>();
        }
    
        public string pesel { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string ulica { get; set; }
        public string miejscowosc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Panel_pracowniczy> Panel_pracowniczy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wycieczka> Wycieczka { get; set; }
    }
}