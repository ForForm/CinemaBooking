using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CineBookWcfService.Models;
using CineBookWcfService.ViewModels;

namespace CineBookWcfService.Classes
{
    public static class Extensions
    {
        public static IQueryable<MovieSession> GetCurrentSessions(this CineBookEntitiesExt entities)
        {
            var start = DateTime.Now;
            var finish = DateTime.Today.AddDays(13).AddSeconds(-1);
            return entities.MovieSession.Where(o => o.SessionTime > start && o.SessionTime < finish);
        }
        public static IQueryable<MovieSessionReservation> GetMyReservations(this CineBookEntitiesExt entities, int sessionId, string webSessionId)
        {
            return entities.MovieSessionReservation.Where(r => r.MovieSessionId == sessionId && r.SessionId == webSessionId);
        }
        public static IQueryable<MovieSessionReservation> GetOtherReservations(this CineBookEntitiesExt entities, int sessionId, string webSessionId)
        {
            return entities.MovieSessionReservation.Where(r => r.MovieSessionId == sessionId && r.SessionId != webSessionId);
        }
        public static IQueryable<MovieSessionReservation> GetOldReservations(this CineBookEntitiesExt entities)
        {
            var oneminute = entities.GetDate().AddSeconds(-60);
            return entities.MovieSessionReservation.Where(r => r.LastUpdate < oneminute);
        }
        public static IQueryable<MovieSessionBooking> GetBookingReservations(this CineBookEntitiesExt entities, int movieSessionId)
        {
            return entities.MovieSessionBooking.Include(o => o.MovieSessionBookingDetail).Where(o => o.MovieSessionId == movieSessionId && o.Status == "Active");
        }
        public static void DeleteMyReservations(this CineBookEntitiesExt entities, int sessionId, string webSessionId)
        {
            var reservations = GetMyReservations(entities, sessionId, webSessionId);
            foreach (var item in reservations) entities.Entry(item).State = EntityState.Deleted;
        }
        public static DateTime GetDate(this CineBookEntitiesExt entities)
        {
            var result = DateTime.Now;
            try
            {
                result = entities.Database.SqlQuery<DateTime>("SELECT GetDate();").FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return result;
        }
        public static MovieSessionViewModel ToViewModel(this MovieSession session)
        {
            return new MovieSessionViewModel
            {
                SessionId = session.MovieSessionId,
                TheatrePlaceName = session.MovieTheatrePlace.MovieTheatrePlaceName,
                SessionTime = session.SessionTime.ToString(Properties.Settings.Default.DateTimeFormatShort),
                MovieFormats = session.MovieSession_MovieFormat.Select(o => new MovieFormatViewModel
                {
                    Id = o.MovieFormat.MovieFormatId,
                    Code = o.MovieFormat.MovieFormatCode,
                    Name = o.MovieFormat.MovieFormatName
                }).ToList()
            };
        }
        public static MovieViewModel ToViewModel(this Movie movie, bool includeImages = true)
        {
            return new MovieViewModel
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Description = movie.Description,
                Duration = movie.Duration,
                ReleaseDate = movie.ReleaseDate?.ToString(Properties.Settings.Default.DateFormat),
                Summary = movie.Summary,
                Story = movie.Story,
#if !DEBUG && includePosters
                PosterPreview = Convert.ToBase64String(movie.PosterPreview),
                PosterOriginal = Convert.ToBase64String(movie.PosterOriginal),
#endif
                TypeList = movie.Movie_MovieType.Select(o => new MovieTypeViewModel
                {
                    Id = o.MovieType.MovieTypeId,
                    Name = o.MovieType.MovieTypeName
                }).ToList(),
                FormatList = movie.Movie_MovieFormat.Select(o => new MovieFormatViewModel
                {
                    Id = o.MovieFormat.MovieFormatId,
                    Code = o.MovieFormat.MovieFormatCode,
                    Name = o.MovieFormat.MovieFormatName
                }).ToList(),
                DirectorList = movie.Movie_MovieDirector.Select(o => new MovieDirectorViewModel
                {
                    Id = o.MovieDirector.MovieDirectorId,
                    Name = o.MovieDirector.MovieDirectorName
                }).ToList(),
                CategoryList = movie.Movie_MovieCategory.Select(o => new MovieCategoryViewModel
                {
                    Id = o.MovieCategory.MovieCategoryId,
                    Code = o.MovieCategory.MovieCategoryCode,
                    Name = o.MovieCategory.MovieCategoryName,
#if !DEBUG && includePosters
                    Image = Convert.ToBase64String(o.MovieCategory.MovieCategoryImage)
#endif
                }).ToList(),
                CastList = movie.Movie_MovieCast.Select(o => new MovieCastViewModel
                {
                    Id = o.MovieCast.MovieCastId,
                    Name = o.MovieCast.CastName
                }).ToList(),
                SessionSummaryList = new List<MovieSessionSummaryViewModel>(),
                SessionList = new List<MovieSessionViewModel>()
            };
        }

    }
}