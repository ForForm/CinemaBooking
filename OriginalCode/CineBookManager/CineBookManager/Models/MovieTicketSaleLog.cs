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
    
    public partial class MovieTicketSaleLog
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string SeanceId { get; set; }
        public Nullable<System.DateTime> SaleTime { get; set; }
        public string PaymentType { get; set; }
        public string PlatformType { get; set; }
        public string PaymentProvider { get; set; }
        public string PaymentNumber { get; set; }
        public string PaymentZNumber { get; set; }
        public string SeatNumber { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> TaxAmount { get; set; }
        public string TicketType { get; set; }
        public Nullable<int> State { get; set; }
        public string Response { get; set; }
        public Nullable<System.DateTime> TranDate { get; set; }
        public Nullable<bool> IsSend { get; set; }
    }
}