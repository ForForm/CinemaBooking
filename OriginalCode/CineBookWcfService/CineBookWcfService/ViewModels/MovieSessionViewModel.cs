using System;
using System.Linq;
using CineBookWcfService.Classes;
using CineBookWcfService.Models;

namespace CineBookWcfService.ViewModels
{
    public class MovieSessionViewModel
    {
        public int SessionId { get; set; }
        public string TheatrePlaceName { get; set; }
        public string SessionTime { get; set; }
        public System.Collections.Generic.List<MovieFormatViewModel> MovieFormats { get; set; }

        public static bool Check(int sessionId, out string reason)
        {
            reason = string.Empty;
            var result = false;
            try
            {
                using (var entities = new CineBookEntitiesExt())
                {
                    result = entities.GetCurrentSessions().Any(o => o.MovieSessionId == sessionId);
                }
                if (!result) reason = "SessionId is invalid.";
            }
            catch (Exception exception)
            {
                reason = exception.Message;
            }
            return result;
        }
    }
}