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
    
    public partial class YUKLEME_NOKTASI
    {
        public int ID { get; set; }
        public string YUKNOKID { get; set; }
        public string YUKNOKADI { get; set; }
        public bool AKTIF { get; set; }
        public string CHECKSUM { get; set; }
        public string LICENCE_CODE { get; set; }
        public Nullable<System.DateTime> SONILETISIM { get; set; }
        public string SONSICILNO { get; set; }
        public string SONDURUM { get; set; }
        public string SONVERSIYON { get; set; }
        public Nullable<decimal> POSLIMITNAKIT { get; set; }
        public Nullable<decimal> POSLIMITKART { get; set; }
        public Nullable<decimal> POSLIMITKREDI { get; set; }
        public Nullable<decimal> POSLIMITTOPLAM { get; set; }
    }
}
