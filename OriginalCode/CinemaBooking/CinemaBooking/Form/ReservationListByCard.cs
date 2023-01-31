using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace CinemaBooking
{
    public partial class ReservationListByCard : Form
    {
        private List<InternalClass> _items = new List<InternalClass>();
        private readonly string _tagId;
        public static ReservationListByCard Instance;
        public ReservationListByCard(string tagId)
        {
            InitializeComponent();
            Instance = this;
            Owner = MainForm.Instance;
            Location = Owner.Location;
            Size = Owner.Size;
            WindowState = Owner.WindowState;

            CheckForIllegalCrossThreadCalls = false;
            _tagId = tagId;
            dataGridView1.SelectionChanged += delegate { buttonNext.Visible = dataGridView1.SelectedRows.Count == 1; };
            dataGridView1.DataBindingComplete += delegate { foreach (DataGridViewRow row in dataGridView1.Rows) row.MinimumHeight = 70; };

        }
        protected override void OnShown(EventArgs e) { base.OnShown(e); RefreshGrid(); }
        protected override void OnClosed(EventArgs e) { base.OnClosed(e); Instance = null; }
        public static void ShowForm(string tagId)
        {
            if (Instance == null) Instance = new ReservationListByCard(tagId);
            Instance.Show();
            Instance.BringToFront();
        }
        public static void CloseForm() { Instance?.Close(); }
        private void buttonBack_Click(object sender, EventArgs e) { CloseForm(); }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            var item = dataGridView1.SelectedRows[0].DataBoundItem as InternalClass;
            if (item == null) return;
            ContinueWithBookingId(item.BookingId);
        }
        private void RefreshGrid()
        {
            _items = new List<InternalClass>();
            try
            {
                using (var entities = new CinemaBookingEntities())
                {
                    //foreach (var booking in entities.MovieSessionBooking.Where(o => o.Status == "Active" && o.ReservationId==_tagId))
                    foreach (var booking in entities.MovieSessionBooking.Where(o => o.Status == "Active").Include(o => o.MovieSessionBookingDetail).Where(o => o.MovieSessionBookingDetail.Any(p => p.CustomerInfo == _tagId)).Include(o => o.MovieSession.Movie).Include(o => o.MovieSession.MovieTheatrePlace).OrderBy(o => o.BookingTime))
                    {
                        int? blockI = booking.MovieSessionBookingDetail.FirstOrDefault().Block;

                        var item = new InternalClass
                        {
                            BookingId = booking.Id,
                            MovieTitle = booking.MovieSession.Movie.Title,
                            PlaceName = booking.MovieSession.MovieTheatrePlace.MovieTheatrePlaceName,
                            SessionTime = booking.MovieSession.SessionTime,
                            BookingTime = booking.BookingTime,
                            BlockName= (entities.MovieTheatrePlaceTemplateBlock.Where(o=>o.BlockIndex== blockI).FirstOrDefault()==null?null: entities.MovieTheatrePlaceTemplateBlock.Where(o => o.BlockIndex == blockI).FirstOrDefault().MovieTheaterBlockName),
                            SeatDescription = string.Join("-", booking.MovieSessionBookingDetail.Select(o => o.SeatCode).ToArray()),
                            //MovieTheatrePlaceTemplateDetailsId=(entities.MovieBookingSerialReservation.Where(o=>o.ReservationId==))
                        };
                        _items.Add(item);
                    }
                }
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = _items;
                dataGridView1.ClearSelection();

                if (_items.Count == 0)
                {
                    InfoForm.ShowInfo("Bu karta ait bir rezervasyon bulunamadı.");
                    CloseForm();
                }
                if (_items.Count == 1)
                {
                    ContinueWithBookingId(_items[0].BookingId);
                }
            }
            catch (Exception exception)
            {
                InfoForm.ShowInfo(exception.ToString());
            }
        }
        private void ContinueWithBookingId(int bookingId)
        {
            try
            {
                MovieSessionBooking booking;
                using (var entities = new CinemaBookingEntities())
                {
                    booking = entities.MovieSessionBooking.FirstOrDefault(o => o.Id == bookingId);
                    if (booking != null)
                    {
                        entities.DeleteMyReservations(booking.MovieSessionId);
                        entities.SaveChanges();

                        var bookingDetails = entities.MovieSessionBookingDetail.Where(o => o.BookingId == booking.Id).ToArray();
                        foreach (var bookingDetail in bookingDetails)
                        {
                            var details = entities.MovieTheatrePlaceTemplateDetails.Where(o => o.SeatCode == bookingDetail.SeatCode && o.MovieTheatrePlaceTemplateId == bookingDetail.MovieSessionBooking.MovieSession.MovieTheatrePlace.MovieTheatrePlaceTemplateId).FirstOrDefault();

                            //var amount = entities.MovieSessionAmount.Where(o => o.MovieSessionId == booking.MovieSessionId && o.MovieTheatrePlaceTemplateDetailsId==seatId).FirstOrDefault();
                 
                            var reservation = new MovieSessionReservation { MovieSeatTypeId = bookingDetail.MovieSeatTypeId, SeatPrefix = bookingDetail.SeatPrefix, SeatSuffix = bookingDetail.SeatSuffix, SeatCode = bookingDetail.SeatCode, MovieSessionId = booking.MovieSessionId, LastUpdate = entities.GetDate(), UserId = LoginUser.LoggedUserId, SessionId = LoginUser.SessionId, MovieTheatrePlaceTemplateDetailsId= details.Id, Block=details.Block};
                            entities.MovieSessionReservation.Add(reservation);
                        }
                        entities.SaveChanges();
                    }
                }
                if (booking != null)
                {
                    TariffSelection.ShowForm(null,booking.MovieSessionId, booking.Id);
                    CloseForm();
                }
            }
            catch (Exception exception)
            {
                InfoForm.ShowInfo(exception.ToString());
            }
        }
        public class InternalClass
        {
            public int BookingId { get; set; }
            public string MovieTitle { get; set; }
            public string PlaceName { get; set; }
            public DateTime SessionTime { get; set; }
            public DateTime BookingTime { get; set; }
            public string SeatDescription { get; set; }
            public string BlockName { get; set; }
        }
    }
}
