using System;
using System.Collections.Generic;

namespace CineBookWcfService.ViewModels
{
    public class SaleViewModel
    {
        public string ReservationId { get; set; }
        public decimal Amount { get; set; }
        public string DateCreated { get; set; }
        public string WebSessionId { get; set; }
        public string TransactionId { get; set; }
        public List<SaleTicketViewModel> Tickets { get; set; }
    }
}