namespace CineBookWcfService.ViewModels
{
    public class ReservationDetailViewModel
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string SeatCode { get; set; }
        public int SeatTypeId { get; set; }
        public string SeatTypeName { get; set; }
        public int TariffId { get; set; }
        public string TariffName { get; set; }
        public decimal? Price { get; set; }
        internal string CustomerInfo { get; set; }
        //public MovieSeatTypeViewModel SeatType { get; set; }
        //public MovieTariffViewModel Tariff { get; set; }
    }
}