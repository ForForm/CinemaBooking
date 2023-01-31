using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using CineBookWcfService.Classes;
using CineBookWcfService.Models;

namespace CineBookWcfService.ViewModels
{
    public class MovieSessionSeatInfo
    {
        public String SeatCode { get; set; }

        public int? Block { get; set; }

    }


    public class MovieSessionReservationViewModel
    {
        public List<MovieSessionSeatInfo> ReservatingByMe { get; set; }
        public List<MovieSessionSeatInfo> ReservatingByOther { get; set; }
        public List<MovieSessionSeatInfo> AlreadyBooked { get; set; }
        public List<MovieSessionSeatInfo> AlreadySold { get; set; }

        public static void DeleteOldReservations()
        {
            try
            {
                using (var entities = new CineBookEntitiesExt())
                {
                    foreach (var item in entities.GetOldReservations()) entities.Entry(item).State = EntityState.Deleted;
                    entities.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        public static MovieSessionReservationViewModel Get(int sessionId, string webSessionId)
        {
            MovieSessionReservationViewModel result = null;
            try
            {
                DeleteOldReservations();
                using (var entities = new CineBookEntitiesExt())
                {
                    var movieSession = entities.MovieSession.FirstOrDefault(o => o.MovieSessionId == sessionId);
                    if (movieSession != null)
                    {
                        result = new MovieSessionReservationViewModel
                        {
                            ReservatingByMe = entities.GetMyReservations(sessionId, webSessionId).Select(o =>  new MovieSessionSeatInfo { Block = o.Block??0, SeatCode = o.SeatCode }).ToList(),
                            ReservatingByOther = entities.GetOtherReservations(sessionId, webSessionId).Select(o => new MovieSessionSeatInfo { Block = o.Block ?? 0, SeatCode = o.SeatCode }).ToList(),
                            AlreadySold = entities.MovieTicket.Where(t => t.MovieTicketSale.MovieSessionId == sessionId).Select(o => 
                            new MovieSessionSeatInfo {
                                Block =  entities.MovieTheatrePlaceTemplateBlock.FirstOrDefault(x => x.MovieTheaterBlockName.Contains(o.BlockName)).BlockIndex ?? 0,
                                SeatCode = o.SeatCode
                            }).ToList(),
                            AlreadyBooked = new List<MovieSessionSeatInfo>()
                        };
                        foreach (var bookingReservation in entities.GetBookingReservations(sessionId).ToArray())
                        {
                            foreach (var item in bookingReservation.MovieSessionBookingDetail)
                            {
                                result.AlreadyBooked.Add(new MovieSessionSeatInfo { Block=item.Block ?? 0, SeatCode=item.SeatCode });
                            }
                            //result.AlreadyBooked.AddRange(bookingReservation.MovieSessionBookingDetail.Select(movieSessionBookingDetail => movieSessionBookingDetail.SeatCode));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
            return result;
        }
        public static bool Alive(int sessionId, string webSessionId)
        {
            try
            {
                DeleteOldReservations();
                using (var entities = new CineBookEntitiesExt())
                {
                    foreach (var item in entities.GetMyReservations(sessionId, webSessionId)) item.LastUpdate = entities.GetDate();
                    entities.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return false;
        }
        public static bool Check(int sessionId, string webSessionId, int? block, string seatCode, out string reason)
        {
            reason = string.Empty;
            try
            {
                DeleteOldReservations();
                var seatCodes = Get(sessionId, webSessionId);
                if (seatCodes.AlreadyBooked.Contains( new MovieSessionSeatInfo { Block=block??0 , SeatCode = seatCode })) { reason = "Seat is already reserved."; return false; }
                if (seatCodes.AlreadySold.Contains(new MovieSessionSeatInfo { Block = block ?? 0, SeatCode = seatCode })) { reason = "Seat is already sold."; return false; }
                if (seatCodes.ReservatingByOther.Contains(new MovieSessionSeatInfo { Block = block ?? 0, SeatCode = seatCode })) { reason = "Seat is reservating by other person."; return false; }
                var template = MovieSeatTemplateDetailViewModel.Get(sessionId,null);
                var templateDetail = template.FirstOrDefault(o => o.SeatCode == seatCode);
                if (templateDetail == null) { reason = "Seat code is invalid."; return false; }

                //if (templateDetail.Block == null) block = null;
                using (var entities = new CineBookEntitiesExt())
                {
                    var reservation = entities.GetMyReservations(sessionId, webSessionId).FirstOrDefault(o => o.Block==block && o.SeatCode == seatCode);

                    int? _templateId = entities.MovieSession.Where(o => o.MovieSessionId == sessionId).FirstOrDefault().MovieTheatrePlace.MovieTheatrePlaceTemplate.MovieTheatrePlaceTemplateDetails.Where(o => o.Block == block && o.SeatCode == seatCode).FirstOrDefault().Id ;
                    if (reservation == null)
                    {
                        reservation = new MovieSessionReservation { MovieSeatTypeId = templateDetail.MovieSeatTypeId, SeatPrefix = templateDetail.Prefix, SeatSuffix = templateDetail.Suffix, SeatCode = templateDetail.SeatCode, MovieSessionId = sessionId, LastUpdate = entities.GetDate(), UserId = Properties.Settings.Default.DefaultUserId, SessionId = webSessionId, Block= templateDetail.Block == null?null:block, MovieTheatrePlaceTemplateDetailsId= _templateId };
                        entities.MovieSessionReservation.Add(reservation);
                        entities.SaveChanges();
                    }
                }
                Alive(sessionId, webSessionId);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return false;
        }
        public static bool Uncheck(int sessionId, string webSessionId, string seatCode)
        {
            try
            {
                DeleteOldReservations();
                using (var entities = new CineBookEntitiesExt())
                {
                    var reservation = entities.GetMyReservations(sessionId, webSessionId).FirstOrDefault(o => o.SeatCode == seatCode);
                    if (reservation != null)
                    {
                        entities.MovieSessionReservation.Remove(reservation);
                        entities.SaveChanges();
                    }
                }
                Alive(sessionId, webSessionId);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return false;
        }
        public static bool Uncheck(int sessionId, string webSessionId)
        {
            try
            {
                DeleteOldReservations();
                using (var entities = new CineBookEntitiesExt())
                {
                    foreach (var item in entities.GetMyReservations(sessionId, webSessionId)) entities.Entry(item).State = EntityState.Deleted;
                    entities.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return false;
        }
    }
}
