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
    
    public partial class ModuleAuth
    {
        public int AuthId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> UserGroupId { get; set; }
        public string OperationCode { get; set; }
    
        public virtual ModuleOperation ModuleOperation { get; set; }
        public virtual User User { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}
