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
    
    public partial class Acente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Acente()
        {
            this.MailLog = new HashSet<MailLog>();
            this.Rehber = new HashSet<Rehber>();
            this.Sozlesme = new HashSet<Sozlesme>();
        }
    
        public int AcenteId { get; set; }
        public string AcenteKodu { get; set; }
        public string KisaAdi { get; set; }
        public string TamAdi { get; set; }
        public string Aciklama { get; set; }
        public int AcenteTipiId { get; set; }
        public string Adres { get; set; }
        public string Telefon1 { get; set; }
        public string Telefon2 { get; set; }
        public string Faks1 { get; set; }
        public string Faks2 { get; set; }
        public string Mail1 { get; set; }
        public string Mail2 { get; set; }
        public string WebAdres { get; set; }
        public string YetkiliKisiAdi { get; set; }
        public string YetkiliKisiGorevi { get; set; }
        public string YetkiliKisiDahili { get; set; }
        public string VergiDairesiKodu { get; set; }
        public string VergiDairesiAdi { get; set; }
        public string VergiNumarasi { get; set; }
        public string BankaAdi { get; set; }
        public string BankaSube { get; set; }
        public string BankaHesapNo { get; set; }
        public string BankaIBAN { get; set; }
        public bool OdemeNakit { get; set; }
        public bool OdemeKredili { get; set; }
    
        public virtual AcenteTipi AcenteTipi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MailLog> MailLog { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rehber> Rehber { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sozlesme> Sozlesme { get; set; }
    }
}
