using System.Linq;
using System.Data.Entity;

namespace CinemaBooking
{
    public static class DatabaseExtensionMethods
    {
        public static IQueryable<MovieSessionReservation> GetMyReservations(this CinemaBookingEntities entities, int movieSessionId)
        {
            return entities.MovieSessionReservation.Where(r => r.MovieSessionId == movieSessionId && r.SessionId == LoginUser.SessionId);
        }
        public static IQueryable<MovieSessionReservation> GetOtherReservations(this CinemaBookingEntities entities, int movieSessionId)
        {
            return entities.MovieSessionReservation.Where(r => r.MovieSessionId == movieSessionId && r.SessionId != LoginUser.SessionId);
        }
        public static IQueryable<MovieSessionReservation> GetOldReservations(this CinemaBookingEntities entities)
        {
            var oneminute = entities.GetDate().AddSeconds(-60);
            return entities.MovieSessionReservation.Where(r => r.LastUpdate < oneminute);
        }
        public static IQueryable<MovieSessionBooking> GetBookingReservations(this CinemaBookingEntities entities, int movieSessionId)
        {
            return entities.MovieSessionBooking.Include(o => o.MovieSessionBookingDetail).Where(o => o.MovieSessionId == movieSessionId && o.Status == "Active");
        }
        public static void DeleteMyReservations(this CinemaBookingEntities entities, int movieSessionId)
        {
            var reservations = GetMyReservations(entities, movieSessionId);
            foreach (var item in reservations) entities.Entry(item).State = EntityState.Deleted;
        }
        //public static void SeatSelectionToggle(this CinemaBookingEntities entities, int movieSessionId)
        //{
        //    var reservation = entities.GetMyReservations(_movieSessionId).FirstOrDefault(o => o.SeatCode == item.Detail.SeatCode);
        //    if (reservation == null)
        //    {
        //        reservation = new MovieSessionReservation { MovieSeatTypeId = item.Detail.MovieSeatTypeId, SeatPrefix = item.Detail.Prefix, SeatSuffix = item.Detail.Suffix, SeatCode = item.Detail.SeatCode, MovieSessionId = _movieSessionId, LastUpdate = entities.GetDate(), UserId = LoginUser.LoggedUserId, SessionId = LoginUser.SessionId };
        //        entities.MovieSessionReservation.Add(reservation);
        //    }
        //    else
        //    {
        //        entities.MovieSessionReservation.Remove(reservation);
        //    }
        //    entities.SaveChanges();

        //}
    }
}
