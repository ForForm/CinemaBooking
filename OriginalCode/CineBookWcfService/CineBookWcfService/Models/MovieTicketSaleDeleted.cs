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
    
    public partial class MovieTicketSaleDeleted
    {
        public int MovieTicketSaleId { get; set; }
        public int MovieSessionId { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime DateCreated { get; set; }
        public bool Completed { get; set; }
        public int UserId { get; set; }
        public string SessionId { get; set; }
    }
}