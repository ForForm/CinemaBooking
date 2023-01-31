namespace CineBookWcfService.ViewModels
{
    public class SaleTicketViewModel
    {
        public string SeatPrefix { get; set; }
        public string SeatSuffix { get; set; }
        public string SeatCode { get; set; }
        public int SeatTypeId { get; set; }
        public string SeatTypeName { get; set; }
        public int TariffId { get; set; }
        public string TariffName { get; set; }
        public decimal Amount { get; set; }
        public string BarcodeNumber { get; set; }
        public string TicketOrder { get; set; }
    }
}