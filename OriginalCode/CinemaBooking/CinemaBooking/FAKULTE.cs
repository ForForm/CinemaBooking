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
    
    public partial class FAKULTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAKULTE()
        {
            this.BOLUM = new HashSet<BOLUM>();
        }
    
        public Nullable<int> KAMPUSID { get; set; }
        public int FAKULTEID { get; set; }
        public string FAKULTEADI { get; set; }
        public Nullable<int> OGRENIM_SURESI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOLUM> BOLUM { get; set; }
    }
}
