using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CineBookWcfService.Models;
using CineBookWcfService.Classes;

namespace CineBookWcfService.ViewModels
{
    public class MovieViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string PosterPreview { get; set; }
        public string PosterOriginal { get; set; }
        public string ReleaseDate { get; set; }
        public string Summary { get; set; }
        public string Story { get; set; }
        public List<MovieTypeViewModel> TypeList { get; set; }
        public List<MovieFormatViewModel> FormatList { get; set; }
        public List<MovieDirectorViewModel> DirectorList { get; set; }
        public List<MovieCategoryViewModel> CategoryList { get; set; }
        public List<MovieCastViewModel> CastList { get; set; }
        public List<MovieSessionSummaryViewModel> SessionSummaryList { get; set; }
        public List<MovieSessionViewModel> SessionList { get; set; }

        public static MovieViewModel[] GetMovies_NowPlaying()
        {
            try
            {
                using (var entities = new CineBookEntitiesExt())
                {
                    var items = new List<MovieViewModel>();
                    var movieIdList = entities.GetCurrentSessions().Select(o => o.MovieId).Distinct().ToArray();
                    var movies = entities.Movie.Where(o => movieIdList.Contains(o.MovieId)).ToArray();
                    foreach (var movie in movies)
                    {
                        var item = movie.ToViewModel();

                        #region MovieSessionSummaries
                        var sessions = entities.GetCurrentSessions().ToArray();
                        var places = sessions.Select(o => o.MovieTheatrePlaceId).Distinct();
                        foreach (var place in places)
                        {
                            item.SessionSummaryList.Add(new MovieSessionSummaryViewModel
                            {
                                TheatrePlaceName = entities.MovieTheatrePlace.First(o => o.MovieTheatrePlaceId == place).MovieTheatrePlaceName,
                                SessionTimes = sessions.Where(o => o.MovieTheatrePlaceId == place).Select(o => o.SessionTime.ToString("HH:mm")).Distinct().OrderBy(o => o).ToArray()
                            });
                        }
                        #endregion

                        #region MovieSessions
                        foreach (var session in sessions)
                        {
                            item.SessionList.Add(new MovieSessionViewModel
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
                            });
                        }
                        #endregion

                        items.Add(item);
                    }
                    return items.ToArray();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
        public static MovieViewModel[] GetMovies_ComingSoon()
        {
            try
            {
                using (var entities = new CineBookEntitiesExt())
                {
                    var items = new List<MovieViewModel>();
                    var movies = entities.Movie.Where(o => o.ReleaseDate > DateTime.Today).ToArray();
                    foreach (var movie in movies)
                    {
                        var item = movie.ToViewModel();
                        items.Add(item);
                    }
                    return items.ToArray();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }


        public static MovieViewModel[] GetMovies_Active()
        {
            try
            {
                using (var entities = new CineBookEntitiesExt())
                {
                    var items = new List<MovieViewModel>();
                    var movies = entities.Movie.Where(o => o.Active ==true).ToArray();
                    foreach (var movie in movies)
                    {
                        var item = movie.ToViewModel();

                        #region MovieSessionSummaries
                        var sessions = entities.GetCurrentSessions().Where(o=>o.MovieId==movie.MovieId).ToArray();
                        var places = sessions.Select(o => o.MovieTheatrePlaceId).Distinct();
                        foreach (var place in places)
                        {
                            item.SessionSummaryList.Add(new MovieSessionSummaryViewModel
                            {
                                TheatrePlaceName = entities.MovieTheatrePlace.First(o => o.MovieTheatrePlaceId == place).MovieTheatrePlaceName,
                                SessionTimes = sessions.Where(o => o.MovieTheatrePlaceId == place).Select(o => o.SessionTime.ToString("HH:mm")).Distinct().OrderBy(o => o).ToArray()
                            });
                        }
                        #endregion

                        #region MovieSessions
                        foreach (var session in sessions)
                        {
                            item.SessionList.Add(new MovieSessionViewModel
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
                            });
                        }
                        #endregion

                        items.Add(item);
                    }
                    return items.ToArray();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
    }
}