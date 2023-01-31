using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaBooking
{
    public sealed class SeatItem : Button
    {
        public readonly MovieTheatrePlaceTemplateDetails Detail;
        public readonly int _MovieSession;
        public readonly MovieSeatType seatType;
        public enum SeatStatus { Available, Reserved, Sold, Reserving, BookingReserved }
        public SeatStatus Status { get; set; }
        //public SeatItem(int id)
        public SeatItem(MovieTheatrePlaceTemplateDetails detail, int movieSession)
        {
            //int movieSession
            Detail = detail;
            seatType = Detail.MovieSeatType;
            _MovieSession = movieSession;
            //using (var entities = new CinemaBookingEntities())
            //{
            //    Detail = entities.MovieTheatrePlaceTemplateDetails.First(o => o.Id == id);
            //    seatType = Detail.MovieSeatType;
            //}
        }
        protected override void InitLayout()
        {
            if (Detail == null) return;
            if (seatType == null) return;
            if (seatType.MovieSeatTypeBackground != null) BackColor = ColorTranslator.FromHtml(seatType.MovieSeatTypeBackground);
            if (seatType.MovieSeatTypeForeground != null) ForeColor = ColorTranslator.FromHtml(seatType.MovieSeatTypeForeground);

            using (var entities = new CinemaBookingEntities())
            {
                var aa = entities.MovieSessionAmount.Where(o => o.MovieTheatrePlaceTemplateDetailsId == Detail.Id && o.MovieSessionId == _MovieSession).FirstOrDefault();
                if (aa == null) Text = string.IsNullOrEmpty(Detail.Suffix) ? Detail.Prefix : Detail.Suffix;
                else
                {
                    if (Detail.Block==0)
                    Font = new Font("Arial Narrow", 11.5F, FontStyle.Bold);
                    else
                    Font = new Font("Arial Narrow", 6.5F, FontStyle.Bold);
                    Text =  (string.IsNullOrEmpty(Detail.Suffix) ? Detail.Prefix : Detail.Suffix)+ "*";
                }
                //Text = (string.IsNullOrEmpty(Detail.Suffix) ? "&" + Detail.Prefix : "&" + Detail.Suffix);
            }

            //Text = string.IsNullOrEmpty(Detail.Suffix) ? Detail.Prefix : Detail.Suffix;
            FlatStyle = FlatStyle.Flat;
            Dock = DockStyle.Fill;
            Margin = new Padding(1, 10, 1, 1);
            Padding = Padding.Empty;
            TabStop = false;
            BackgroundImageLayout = ImageLayout.Zoom;
            SetBorder();
            base.InitLayout();
        }
        public override void NotifyDefault(bool value) { base.NotifyDefault(false); }

        public void SetBorder(bool? isChecked = null)
        {
            try
            {
                FlatAppearance.BorderSize = 1;
                FlatAppearance.BorderColor = Color.Black;
                switch (Status)
                {
                    case SeatStatus.Available:
                        BackColor = ColorTranslator.FromHtml(seatType.MovieSeatTypeBackground);
                        ForeColor = ColorTranslator.FromHtml(seatType.MovieSeatTypeForeground);
                        break;
                    case SeatStatus.Sold:
                        BackColor = ColorTranslator.FromHtml(seatType.MovieSeatTypeBackground);
                        BackgroundImage = GetIcon(userIcon);
                        Text = "";
                        break;
                    case SeatStatus.Reserved:
                        BackColor = Color.Fuchsia;
                        ForeColor = Color.White;
                        break;
                    case SeatStatus.Reserving:
                        BackColor = Color.Blue;
                        ForeColor = Color.White;
                        break;
                    case SeatStatus.BookingReserved:
                        BackColor = Color.Maroon;
                        ForeColor = Color.White;
                        break;
                }
            }
            catch (Exception)
            {
            }
        }
        private const string userIcon = "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";
        private static Image GetIcon(string data)
        {
            Image result = null;
            try
            {
                var bytes = Convert.FromBase64String(data);
                result = (Bitmap)new ImageConverter().ConvertFrom(bytes);
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
