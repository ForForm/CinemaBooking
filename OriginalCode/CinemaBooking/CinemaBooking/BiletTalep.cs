//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaBooking
{
    using System;
    using System.Collections.Generic;
    
    public partial class BiletTalep
    {
        public int TalepId { get; set; }
        public int KotaId { get; set; }
        public Nullable<System.DateTime> TalepTarih { get; set; }
        public int Adet { get; set; }
        public bool Nakit { get; set; }
        public bool KrediKarti { get; set; }
        public bool Cek { get; set; }
        public bool Onay { get; set; }
        public bool Ret { get; set; }
        public string RetAcik { get; set; }
    
        public virtual BiletKota BiletKota { get; set; }
    }
}
