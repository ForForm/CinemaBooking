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
    
    public partial class YEMEKHANE_HAREKET_KIOSK
    {
        public int ID { get; set; }
        public Nullable<int> PERID { get; set; }
        public Nullable<long> KARTID { get; set; }
        public Nullable<int> DUSULEN_BAKIYE { get; set; }
        public Nullable<int> KALAN_BAKIYE { get; set; }
        public string HARNOKID { get; set; }
        public Nullable<System.DateTime> TARIH { get; set; }
        public Nullable<System.DateTime> ZAMAN { get; set; }
        public Nullable<int> YEMEK_FIYATI { get; set; }
        public Nullable<int> DEVLETIN_ODEDIGI { get; set; }
        public Nullable<bool> ONAYLANDI { get; set; }
        public Nullable<int> KERE { get; set; }
        public Nullable<int> TARIFEID { get; set; }
    
        public virtual HARCAMA_NOKTASI HARCAMA_NOKTASI { get; set; }
        public virtual PERSONEL PERSONEL { get; set; }
    }
}