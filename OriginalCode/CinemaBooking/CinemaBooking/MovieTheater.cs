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
    
    public partial class MovieTheater
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MovieTheater()
        {
            this.MovieTheatrePlace = new HashSet<MovieTheatrePlace>();
        }
    
        public int MovieTheaterId { get; set; }
        public string MovieTheaterName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CityName { get; set; }
        public string TownName { get; set; }
        public string Address { get; set; }
        public string AvmName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieTheatrePlace> MovieTheatrePlace { get; set; }
    }
}
