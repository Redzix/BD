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
    
    public partial class Katalog
    {
        public int id_katalogu { get; set; }
        public Nullable<int> okres_trwania_wycieczki { get; set; }
        public Nullable<int> id_cennika { get; set; }
        public Nullable<int> id_miejsca_odjazdu { get; set; }
        public Nullable<int> id_miejsca_przyjazdu { get; set; }
        public Nullable<int> id_wycieczki { get; set; }
        public Nullable<decimal> cena { get; set; }
    
        public virtual Miejsce Miejsce { get; set; }
        public virtual Miejsce Miejsce1 { get; set; }
        public virtual Wycieczka Wycieczka { get; set; }
    }
}
