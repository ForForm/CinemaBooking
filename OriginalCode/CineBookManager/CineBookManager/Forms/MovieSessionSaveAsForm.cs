using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using CineBookManager.Models;
using CineBookManager.Classes;

namespace CineBookManager.Forms
{
    public partial class MovieSessionSaveAsForm : Form
    {
        private readonly MovieSession _movieSession;
        public MovieSessionSaveAsForm(MovieSession movieSession) { InitializeComponent(); Owner = Main.Instance; _movieSession = movieSession; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            checkedListBox.Items.Clear();
            for (var i = 1; i <= 13; i++) checkedListBox.Items.Add(new DateOfSession { DateValue = _movieSession.SessionTime.Date.AddDays(i) });
            for (var i = 0; i < 6; i++) checkedListBox.SetItemChecked(i, true);
        }
        public static bool ShowForm(MovieSession movieSession)
        {
            return new MovieSessionSaveAsForm(movieSession).ShowDialog() == DialogResult.OK;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var items = checkedListBox.CheckedItems;
                if (items.Count == 0) { StaticClass.ShowWarning(StringConsts.Thereisnovalueforsave); return; }
                var counter = 0;
                using (var database = CineBookEntitiesExt.New())
                {
                    var _session = database.MovieSession.Single(p => p.MovieSessionId == _movieSession.MovieSessionId);
                    var sessions = database.MovieSession.Include(o => o.MovieSession_MovieFormat).Where(o => o.MovieId == _session.MovieId && DbFunctions.TruncateTime(o.SessionTime) == DbFunctions.TruncateTime(_session.SessionTime)).ToArray();
                    foreach (var session in sessions)
                    {
                        foreach (DateOfSession item in items)
                        {
                            var newSessionTime = new DateTime(item.DateValue.Year, item.DateValue.Month, item.DateValue.Day, session.SessionTime.Hour, session.SessionTime.Minute, session.SessionTime.Second);
                            if (!database.MovieSession.Any(o => o.MovieId == session.MovieId && o.MovieTheatrePlaceId == session.MovieTheatrePlaceId && o.SessionTime == newSessionTime))
                            {
                                var newSession = new MovieSession();
                                newSession.MovieId = session.MovieId;
                                newSession.MovieTheatrePlaceId = session.MovieTheatrePlaceId;
                                newSession.SessionTime = newSessionTime;
                                database.MovieSession.Add(newSession);
                                database.SaveChanges();
                                foreach (var format in session.MovieSession_MovieFormat) database.MovieSession_MovieFormat.Add(new MovieSession_MovieFormat { MovieSessionId = newSession.MovieSessionId, MovieFormatId = format.MovieFormatId });
                                database.SaveChanges();
                                counter++;
                            }
                            else
                            {
                                var newSession = database.MovieSession.Include(o => o.MovieSession_MovieFormat).FirstOrDefault(o => o.MovieId == session.MovieId && o.MovieTheatrePlaceId == session.MovieTheatrePlaceId && o.SessionTime == newSessionTime);
                                if (newSession != null)
                                {
                                    var oldFormats = session.MovieSession_MovieFormat.Select(o => o.MovieFormatId).Distinct().AsEnumerable();
                                    var newFormats = newSession.MovieSession_MovieFormat.Select(o => o.MovieFormatId).Distinct().AsEnumerable();
                                    if(!oldFormats.SequenceEqual(newFormats))
                                    {
                                        database.MovieSession_MovieFormat.RemoveRange(newSession.MovieSession_MovieFormat);
                                        database.SaveChanges();
                                        foreach (var format in session.MovieSession_MovieFormat) database.MovieSession_MovieFormat.Add(new MovieSession_MovieFormat { MovieSessionId = newSession.MovieSessionId, MovieFormatId = format.MovieFormatId });
                                        database.SaveChanges();
                                        counter++;
                                    }
                                }
                            }
                        }
                    }
                }
                StaticClass.ShowInfo(StringConsts.MessageBox_Operationsuccessful + Environment.NewLine + string.Format(StringConsts.MessageBox_xrecordsaffected, counter));
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var items = checkedListBox.CheckedItems;
                if (items.Count == 0) { StaticClass.ShowWarning(StringConsts.Thereisnovalueforsave); return; }
                var counter = 0;
                using (var database = CineBookEntitiesExt.New())
                {
                    var _session = database.MovieSession.Single(p => p.MovieSessionId == _movieSession.MovieSessionId);
                    var sessions = database.MovieSession.Include(o => o.MovieSession_MovieFormat).Where(o => DbFunctions.TruncateTime(o.SessionTime) == DbFunctions.TruncateTime(_session.SessionTime)).ToArray();
                    foreach (var session in sessions)
                    {
                        foreach (DateOfSession item in items)
                        {
                            var newSessionTime = new DateTime(item.DateValue.Year, item.DateValue.Month, item.DateValue.Day, session.SessionTime.Hour, session.SessionTime.Minute, session.SessionTime.Second);
                            if (!database.MovieSession.Any(o => o.MovieId == session.MovieId && o.MovieTheatrePlaceId == session.MovieTheatrePlaceId && o.SessionTime == newSessionTime))
                            {
                                var newSession = new MovieSession();
                                newSession.MovieId = session.MovieId;
                                newSession.MovieTheatrePlaceId = session.MovieTheatrePlaceId;
                                newSession.SessionTime = newSessionTime;
                                database.MovieSession.Add(newSession);
                                database.SaveChanges();
                                foreach (var format in session.MovieSession_MovieFormat) database.MovieSession_MovieFormat.Add(new MovieSession_MovieFormat { MovieSessionId = newSession.MovieSessionId, MovieFormatId = format.MovieFormatId });
                                database.SaveChanges();
                                counter++;
                            }
                            else
                            {
                                var newSession = database.MovieSession.Include(o => o.MovieSession_MovieFormat).FirstOrDefault(o => o.MovieId == session.MovieId && o.MovieTheatrePlaceId == session.MovieTheatrePlaceId && o.SessionTime == newSessionTime);
                                if (newSession != null)
                                {
                                    var oldFormats = session.MovieSession_MovieFormat.Select(o => o.MovieFormatId).Distinct().AsEnumerable();
                                    var newFormats = newSession.MovieSession_MovieFormat.Select(o => o.MovieFormatId).Distinct().AsEnumerable();
                                    if (!oldFormats.SequenceEqual(newFormats))
                                    {
                                        database.MovieSession_MovieFormat.RemoveRange(newSession.MovieSession_MovieFormat);
                                        database.SaveChanges();
                                        foreach (var format in session.MovieSession_MovieFormat) database.MovieSession_MovieFormat.Add(new MovieSession_MovieFormat { MovieSessionId = newSession.MovieSessionId, MovieFormatId = format.MovieFormatId });
                                        database.SaveChanges();
                                        counter++;
                                    }
                                }
                            }
                        }
                    }
                }
                StaticClass.ShowInfo(StringConsts.MessageBox_Operationsuccessful + Environment.NewLine + string.Format(StringConsts.MessageBox_xrecordsaffected, counter));
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        public class DateOfSession
        {
            public DateTime DateValue { get; set; }
            public override string ToString()
            {
                return DateValue.ToString("dd-MMM-yyyy dddd");
            }
        }


    }
}
