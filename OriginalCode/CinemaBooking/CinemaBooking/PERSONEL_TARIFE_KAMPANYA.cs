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
    
    public partial class PERSONEL_TARIFE_KAMPANYA
    {
        public int ID { get; set; }
        public Nullable<byte> TARIFEID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public Nullable<byte> MinimumMeal { get; set; }
        public Nullable<byte> MaximumMeal { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<int> Frequency { get; set; }
        public Nullable<byte> Meals { get; set; }
    }
}