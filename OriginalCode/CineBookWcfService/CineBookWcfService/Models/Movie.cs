//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CineBookWcfService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movie()
        {
            this.Movie_MovieCast = new HashSet<Movie_MovieCast>();
            this.Movie_MovieCategory = new HashSet<Movie_MovieCategory>();
            this.Movie_MovieDirector = new HashSet<Movie_MovieDirector>();
            this.Movie_MovieFormat = new HashSet<Movie_MovieFormat>();
            this.Movie_MovieType = new HashSet<Movie_MovieType>();
            this.MovieSession = new HashSet<MovieSession>();
        }
    
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public byte[] PosterPreview { get; set; }
        public byte[] PosterOriginal { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public string Summary { get; set; }
        public string Story { get; set; }
        public string NameTr { get; set; }
        public Nullable<int> MadeYear { get; set; }
        public Nullable<System.DateTime> VisionDate2 { get; set; }
        public string Distributor { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> SgmMovieId { get; set; }
        public string PosterUrl { get; set; }
        public string TemplateName { get; set; }
        public Nullable<bool> Active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movie_MovieCast> Movie_MovieCast { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movie_MovieCategory> Movie_MovieCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movie_MovieDirector> Movie_MovieDirector { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movie_MovieFormat> Movie_MovieFormat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movie_MovieType> Movie_MovieType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieSession> MovieSession { get; set; }
    }
}
