//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CineBookManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MovieTicketSalePayment
    {
        public int Id { get; set; }
        public int MovieTicketSaleId { get; set; }
        public int MovieTicketSalePaymentTypeId { get; set; }
        public decimal Amount { get; set; }
        public Nullable<int> KotaId { get; set; }
        public string Kod { get; set; }
        public Nullable<bool> KodUsed { get; set; }
    
        public virtual MovieTicketSale MovieTicketSale { get; set; }
        public virtual MovieTicketSalePaymentType MovieTicketSalePaymentType { get; set; }
    }
}