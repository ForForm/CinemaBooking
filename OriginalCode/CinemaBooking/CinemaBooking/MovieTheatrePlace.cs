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
    
    public partial class MovieTheatrePlace
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MovieTheatrePlace()
        {
            this.MovieSession = new HashSet<MovieSession>();
        }
    
        public int MovieTheaterId { get; set; }
        public int MovieTheatrePlaceId { get; set; }
        public string MovieTheatrePlaceName { get; set; }
        public int MovieTheatrePlaceTemplateId { get; set; }
        public string SgmSaloonFormat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieSession> MovieSession { get; set; }
        public virtual MovieTheater MovieTheater { get; set; }
        public virtual MovieTheatrePlaceTemplate MovieTheatrePlaceTemplate { get; set; }
    }
}
