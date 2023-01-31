using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CineBookWcfService.Classes;
using CineBookWcfService.Models;

namespace CineBookWcfService.ViewModels
{
    public class ReservationViewModel
    {
        internal int Id { get; set; }
        public string ReservationId { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public int SessionId { get; set; }
        public string ReservationTime { get; set; }
        public string ExpirationTime { get; set; }
        public string CancellationTime { get; set; }
        public string Status { get; set; }

        public MovieSessionViewModel Sesssion { get; set; }
        public MovieViewModel Movie { get; set; }
        public List<ReservationDetailViewModel> Seats { get; set; }
        public decimal? TotalPrice { get; set; }
        //internal int? MovieTicketSaleId { get; set; }
        public SaleViewModel Sale { get; set; }

        public static ReservationViewModel Get(string reservationId, bool includeImages)
        {
            ReservationViewModel result = null;
            try
            {
                using (var entities = new CineBookEntitiesExt())
                {
                    var booking = entities.MovieSessionBooking.FirstOrDefault(o => o.ReservationId == reservationId);
                    if (booking != null)
                    {
                        result = new ReservationViewModel
                        {
                            Id = booking.Id,
                            ReservationId = booking.ReservationId,
                            CustomerPhone = booking.CustomerPhone,
                            CustomerName = booking.CustomerName,
                            CustomerEmail = booking.CustomerEmail,
                            SessionId = booking.MovieSessionId,
                            ReservationTime = booking.BookingTime.ToString(Properties.Settings.Default.DateTimeFormatLong),
                            ExpirationTime = booking.ExpirationTime.ToString(Properties.Settings.Default.DateTimeFormatLong),
                            CancellationTime = booking.CancellationTime?.ToString(Properties.Settings.Default.DateTimeFormatLong),
                            Status = booking.Status,
                            Sesssion = booking.MovieSession.ToViewModel(),
                            Movie = booking.MovieSession.Movie.ToViewModel(includeImages),
                            Seats = booking.MovieSessionBookingDetail.Select(o => new ReservationDetailViewModel
                            {
                                Prefix = o.SeatPrefix,
                                Suffix = o.SeatSuffix,
                                SeatCode = o.SeatCode,
                                SeatTypeId = o.MovieSeatTypeId,
                                SeatTypeName = o.MovieSeatType.MovieSeatTypeName,
                                TariffId = o.MovieTariffId,
                                TariffName = entities.MovieTariff.Single(p => p.MovieTariffId == o.MovieTariffId).MovieTariffName,
                                Price = booking.MovieSessionBookingDetail.FirstOrDefault().MovieSeatTypeId == 7 ? entities.MovieSessionAmount.FirstOrDefault(p => p.MovieSessionId == booking.MovieSession.MovieSessionId && p.MovieSeatTypeId == o.MovieSeatTypeId && p.MovieTariffId == o.MovieTariffId && p.MovieTheatrePlaceTemplateDetailsId != null)?.Amount :
                                entities.MovieSessionAmount.FirstOrDefault(p => p.MovieSessionId == booking.MovieSession.MovieSessionId && p.MovieSeatTypeId == o.MovieSeatTypeId && p.MovieTariffId == o.MovieTariffId)?.Amount,
                                CustomerInfo = o.CustomerInfo
                            }).ToList()
                        };
                        if (result.Seats != null && result.Seats.All(o => o.Price != null)) result.TotalPrice = result.Seats.Sum(o => (decimal)o.Price);
                        if (booking.MovieTicketSaleId != null)
                        {
                            var sale = entities.MovieTicketSale.Single(o => o.MovieTicketSaleId == booking.MovieTicketSaleId);
                            result.Sale = new SaleViewModel();
                            result.Sale.ReservationId = booking.ReservationId;
                            result.Sale.Amount = sale.Amount;
                            result.Sale.DateCreated = sale.DateCreated.ToString(Properties.Settings.Default.DateTimeFormatLong);
                            result.Sale.WebSessionId = sale.SessionId;
                            result.Sale.TransactionId = sale.TransactionId;
                            result.Sale.Tickets = sale.MovieTicket.Select(o => new SaleTicketViewModel
                            {
                                SeatPrefix = o.SeatPrefix,
                                SeatSuffix = o.SeatSuffix,
                                SeatCode = o.SeatCode,
                                SeatTypeId = o.MovieSeatTypeId,
                                SeatTypeName = o.MovieSeatType.MovieSeatTypeName,
                                TariffId = o.MovieTariffId,
                                TariffName = o.MovieTariff.MovieTariffName,
                                Amount = o.Amount,
                                BarcodeNumber = o.BarcodeNumber,
                                TicketOrder = o.TicketOrder
                            }).ToList();
                        }

                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.ToString());
            }
            return result;
        }
        //string customerPhone, string customerName, string customerEmail,
        public static ReservationViewModel CreateForAnnual(int sessionId, string webSessionId,  string customerInfo, int tariffId, decimal amount, out string reason)
        {
            reason = string.Empty;
            ReservationViewModel result = null;
            try
            {
                MovieSessionReservationViewModel.DeleteOldReservations();

                var reservationId = string.Empty;
                using (var entities = new CineBookEntitiesExt())
                {

                    var bb = entities.MovieBookingSerialReservation.Where(o => o.SerialNumber == customerInfo && o.Used == false).FirstOrDefault();

                    if (bb == null)
                        reservationId = StaticClass.GetNewBarcodeId();
                    else
                        reservationId = bb.ReservationId;

                    var reservations = entities.GetMyReservations(sessionId, webSessionId);
                    var tolerance = 0;
                    var parameter = entities.SystemParameter.FirstOrDefault(o => o.ParameterName == "MovieSessionBookingTolerance");
                    if (parameter != null) int.TryParse(parameter.ParameterValue, out tolerance);
                    var session = entities.MovieSession.Single(item => item.MovieSessionId == sessionId);

                    var booking = new MovieSessionBooking
                    {
                        ReservationId = reservationId,
                        CustomerPhone = string.Empty,
                        CustomerName = string.Empty,
                        CustomerEmail = string.Empty,
                        MovieSessionId = sessionId,
                        BookingTime = entities.GetDate(),
                        ExpirationTime = session.SessionTime.AddMinutes(-1 * tolerance),
                        UserId = Properties.Settings.Default.DefaultUserId,
                        SessionId = webSessionId,
                        MovieTicketSaleId = null
                    };
                    entities.MovieSessionBooking.Add(booking);
                    entities.SaveChanges();

                    var msr = reservations.First();
                    var bookingDetail = new MovieSessionBookingDetail
                    {
                        Block = msr.Block,
                        BookingId = booking.Id,
                        MovieSeatTypeId = msr.MovieSeatTypeId,
                        SeatPrefix = msr.SeatPrefix,
                        SeatSuffix = msr.SeatSuffix,
                        SeatCode = msr.SeatCode,
                        MovieTariffId = tariffId,
                        Amount=amount,
                        //msr.MovieSeatTypeId == 7 ? 7 : Properties.Settings.Default.DefaultAnnualTariffId,
                        CustomerInfo = customerInfo
                    };
                    entities.MovieSessionBookingDetail.Add(bookingDetail);
                    
                    entities.SaveChanges();

                    entities.DeleteMyReservations(sessionId, webSessionId);
                    entities.SaveChanges();

                    MovieBookingSerialReservation rItem = new MovieBookingSerialReservation { ReservationId = reservationId, SerialNumber = customerInfo, Used=false, MovieTheatrePlaceTemplateDetailsId=msr.MovieTheatrePlaceTemplateDetailsId, MovieSessionId= msr.MovieSessionId,
                    MovieSessionBookingDetailId= bookingDetail.Id
                    };
                    entities.MovieBookingSerialReservation.Add(rItem);
                    entities.SaveChanges();

                }
                result = Get(reservationId, true);
            }
            catch (Exception exception)
            {
                reason = exception.ToString();
            }
            return result;
        }
        public static ReservationViewModel CreateForSale(int sessionId, string webSessionId, string customerPhone, string customerName, string customerEmail, int[] tariffs, out string reason)
        {
            reason = string.Empty;
            ReservationViewModel result = null;
            try
            {
                MovieSessionReservationViewModel.DeleteOldReservations();
                var reservationId = StaticClass.GetNewBarcodeId();
                using (var entities = new CineBookEntitiesExt())
                {
                    var now = entities.GetDate();
                    var booking = new MovieSessionBooking
                    {
                        ReservationId = reservationId,
                        CustomerPhone = customerPhone,
                        CustomerName = customerName,
                        CustomerEmail = customerEmail,
                        MovieSessionId = sessionId,
                        BookingTime = now,
                        ExpirationTime = now.AddMinutes(10),
                        UserId = Properties.Settings.Default.DefaultUserId,
                        SessionId = webSessionId,
                        MovieTicketSaleId = null
                    };
                    entities.MovieSessionBooking.Add(booking);
                    entities.SaveChanges();

                    var queue = new Queue<int>(tariffs);
                    foreach (var msr in entities.GetMyReservations(sessionId, webSessionId).ToArray())
                    {
                        var bookingDetail = new MovieSessionBookingDetail
                        {
                            BookingId = booking.Id,
                            MovieSeatTypeId = msr.MovieSeatTypeId,
                            SeatPrefix = msr.SeatPrefix,
                            SeatSuffix = msr.SeatSuffix,
                            SeatCode = msr.SeatCode,
                            MovieTariffId = queue.Dequeue()
                        };
                        entities.MovieSessionBookingDetail.Add(bookingDetail);
                    }
                    entities.SaveChanges();

                    entities.DeleteMyReservations(sessionId, webSessionId);
                    entities.SaveChanges();
                }
                result = Get(reservationId, true);
            }
            catch (Exception exception)
            {
                reason = exception.ToString();
            }
            return result;
        }
        public static bool Cancel(string reservationId, string webSessionId, out string reason)
        {
            reason = string.Empty;
            try
            {
                using (var entities = new CineBookEntitiesExt())
                {
                    var booking = entities.MovieSessionBooking.FirstOrDefault(o => o.ReservationId == reservationId);
                    if (booking == null) { reason = "Reservation could not be found."; return false; }
                    if (booking.Status == "Cancelled") { reason = "Reservation is already cancelled."; return false; }
                    if (booking.Status == "Sold") { reason = "Reservation is sold."; return false; }
                    if (booking.Status == "Expired") { reason = "Reservation is expired."; return false; }
                    booking.CancellationTime = entities.GetDate();
                    booking.CancellationUserId = Properties.Settings.Default.DefaultUserId;
                    booking.CancellationSessionId = webSessionId;
                    entities.SaveChanges();
                    return true;
                }
            }
            catch (Exception exception)
            {
                reason = exception.ToString();
            }
            return false;
        }
        public static bool ConvertToSale(string reservationId, string webSessionId, string transactionId, out string reason)
        {
            reason = string.Empty;
            try
            {
                var reservation = Get(reservationId, false);
                if (reservation == null) { reason = "Reservation could not be found."; return false; }
                if (reservation.TotalPrice == null) { reason = "Reservation total price is invalid."; return false; }
                using (var entities = new CineBookEntitiesExt())
                {
                    var booking = entities.MovieSessionBooking.FirstOrDefault(o => o.ReservationId == reservationId);
                    if (booking == null) { reason = "Reservation could not be found."; return false; }
                    if (booking.Status == "Cancelled") { reason = "Reservation is cancelled."; return false; }
                    if (booking.Status == "Sold") { reason = "Reservation is already sold."; return false; }
                    if (booking.Status == "Expired") { reason = "Reservation is expired."; return false; }

                    #region Add to MovieTicketSale
                    var sale = new MovieTicketSale
                    {
                        MovieSessionId = booking.MovieSessionId,
                        Amount = reservation.TotalPrice.Value,
                        DateCreated = entities.GetDate(),
                        UserId = Properties.Settings.Default.DefaultUserId,
                        SessionId = webSessionId,
                        Completed = true,
                        TransactionId = transactionId
                    };
                    entities.MovieTicketSale.Add(sale);
                    entities.SaveChanges();
                    #endregion

                    #region Update SaleId on MovieSessionBooking
                    booking.MovieTicketSaleId = sale.MovieTicketSaleId;
                    #endregion

                    #region Add to MovieTicketSalePayment
                    var payment = new MovieTicketSalePayment
                    {
                        MovieTicketSaleId = sale.MovieTicketSaleId,
                        MovieTicketSalePaymentTypeId = Properties.Settings.Default.DefaultPaymentTypeId,
                        Amount = reservation.TotalPrice.Value
                    };
                    entities.MovieTicketSalePayment.Add(payment);
                    #endregion

                    #region Add to MovieTicket
                    for (var i = 0; i < reservation.Seats.Count; i++)
                    {
                        var seat = reservation.Seats[i];
                        var ticket = new MovieTicket
                        {
                            MovieTicketSaleId = sale.MovieTicketSaleId,
                            MovieSeatTypeId = seat.SeatTypeId,
                            MovieTariffId = seat.TariffId,
                            SeatPrefix = seat.Prefix,
                            SeatSuffix = seat.Suffix,
                            SeatCode = seat.SeatCode,
                            Amount = seat.Price ?? 0,
                            TicketOrder = $"{i + 1}/{reservation.Seats.Count}",
                            BarcodeNumber = StaticClass.GetNewBarcodeId(),
                            CustomerInfo = seat.CustomerInfo
                        };
                        entities.MovieTicket.Add(ticket);
                    }
                    #endregion

                    entities.SaveChanges();

                    return true;
                }
            }
            catch (Exception exception)
            {
                reason = exception.ToString();
            }
            return false;
        }

    }
}