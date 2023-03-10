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
    
    public partial class MovieSeatType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MovieSeatType()
        {
            this.MovieSessionAmount = new HashSet<MovieSessionAmount>();
            this.MovieSessionBookingDetail = new HashSet<MovieSessionBookingDetail>();
            this.MovieSessionReservation = new HashSet<MovieSessionReservation>();
            this.MovieTheatrePlaceTemplateDetails = new HashSet<MovieTheatrePlaceTemplateDetails>();
            this.MovieTicket = new HashSet<MovieTicket>();
        }
    
        public int MovieSeatTypeId { get; set; }
        public string MovieSeatTypeName { get; set; }
        public string MovieSeatTypeBackground { get; set; }
        public string MovieSeatTypeForeground { get; set; }
        public bool Reserved { get; set; }
        public bool Salable { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieSessionAmount> MovieSessionAmount { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieSessionBookingDetail> MovieSessionBookingDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieSessionReservation> MovieSessionReservation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieTheatrePlaceTemplateDetails> MovieTheatrePlaceTemplateDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieTicket> MovieTicket { get; set; }
    }
}
