using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CinemaBooking
{
    public class SessionButton : Button
    {
        public MovieSession Session { get; set; }
        private MovieTheatrePlaceTemplate Template { get; set; }
        private string TextLeft { get; set; }
        private string TextRight { get; set; }

        public SessionButton(MovieSession session, MovieTheatrePlaceTemplate template)
        {
            Session = session;
            Template = template;
            TextLeft = Session.SessionTime.ToString("HH:mm");
            //TextRight = string.Join(",", Session.MovieSession_MovieFormat.Select(o => o.MovieFormat.MovieFormatCode));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            if (string.IsNullOrEmpty(TextRight))
            {
                if (TextLeft != null) g.DrawString(TextLeft, new Font(DefaultFont, Enabled ? FontStyle.Bold : FontStyle.Regular), Brushes.Black, (float)Width / 2, (float)Height / 2, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
            else
            {
                if (TextLeft != null) g.DrawString(TextLeft, new Font(DefaultFont, Enabled ? FontStyle.Bold : FontStyle.Regular), Brushes.Black, 5, (float)Height / 2, new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
                if (TextRight != null) g.DrawString(TextRight, Font, Brushes.Black, Width - 5, (float)Height / 2, new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });
            }
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (Session == null) return;
            SeatInformation.ShowForm(Session.MovieSessionId);
            SeatSelection.ShowForm(Session.MovieSessionId);
        }
    }
}
