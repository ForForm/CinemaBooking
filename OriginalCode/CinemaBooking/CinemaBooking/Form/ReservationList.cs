using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace CinemaBooking
{
    public partial class ReservationList : Form
    {
        private List<InternalClass> _items = new List<InternalClass>();
        private readonly int _movieSessionId;
        public static ReservationList Instance;
        public ReservationList(int movieSessionId)
        {
            InitializeComponent();
            Instance = this;
            Owner = MainForm.Instance;
            Location = Owner.Location;
            Size = Owner.Size;
            WindowState = Owner.WindowState;

            CheckForIllegalCrossThreadCalls = false;
            _movieSessionId = movieSessionId;
            dataGridView1.SelectionChanged += delegate { buttonNext.Enabled = dataGridView1.SelectedRows.Count == 1; };
            dataGridView1.DataBindingComplete += delegate { foreach (DataGridViewRow row in dataGridView1.Rows) row.MinimumHeight = 70; };

        }
        protected override void OnShown(EventArgs e) { base.OnShown(e); RefreshGrid(); }
        protected override void OnClosed(EventArgs e) { base.OnClosed(e); Instance = null; }
        public static void ShowForm(int movieTicketSaleId)
        {
            if (Instance == null) Instance = new ReservationList(movieTicketSaleId);
            Instance.Show();
            Instance.BringToFront();
        }
        public static void CloseForm() { Instance?.Close(); }
        private void buttonBack_Click(object sender, EventArgs e) { CloseForm(); }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            var item = dataGridView1.SelectedRows[0].DataBoundItem as InternalClass;
            if (item == null) return;

            using (var entities = new CinemaBookingEntities())
            {
                entities.DeleteMyReservations(_movieSessionId);
                entities.SaveChanges();

                var bookingDetails = entities.MovieSessionBookingDetail.Where(o => o.BookingId == item.BookingId).ToArray();
                foreach (var bookingDetail in bookingDetails)
                {
                    var reservation = new MovieSessionReservation { MovieSeatTypeId = bookingDetail.MovieSeatTypeId, SeatPrefix = bookingDetail.SeatPrefix, SeatSuffix = bookingDetail.SeatSuffix, SeatCode = bookingDetail.SeatCode, MovieSessionId = _movieSessionId, LastUpdate = entities.GetDate(), UserId = LoginUser.LoggedUserId, SessionId = LoginUser.SessionId };
                    entities.MovieSessionReservation.Add(reservation);
                }
                entities.SaveChanges();
            }
            TariffSelection.ShowForm(null,_movieSessionId, item.BookingId);
            CloseForm();

        }
        private void RefreshGrid()
        {
            _items = new List<InternalClass>();
            using (var entities = new CinemaBookingEntities())
            {
                var session = entities.MovieSession.FirstOrDefault(o => o.MovieSessionId == _movieSessionId);
                if (session != null)
                {
                    labelTitle.Text = session.Movie.Title;
                    labelPlace.Text = session.MovieTheatrePlace.MovieTheatrePlaceName;
                    labelTime.Text = session.SessionTime.ToString("HH:mm");
                    var time = entities.GetDate();
                    _items = entities.MovieSessionBooking.Include(o => o.MovieSessionBookingDetail).Where(o => o.MovieSessionId == _movieSessionId && o.MovieTicketSaleId == null && o.ExpirationTime > time).Select(o => new InternalClass
                    {
                        BookingId = o.Id,
                        Phone = o.CustomerPhone,
                        Name = o.CustomerName,
                        Email = o.CustomerEmail,
                        BookingTime = o.BookingTime,
                        ExpirationTime = o.ExpirationTime,
                        SeatCount = o.MovieSessionBookingDetail.Count
                    }).ToList();
                }
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _items;
            dataGridView1.ClearSelection();
        }

        public class InternalClass
        {
            public int BookingId { get; set; }
            public string Phone { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime BookingTime { get; set; }
            public DateTime ExpirationTime { get; set; }
            public int SeatCount { get; set; }
        }

    }
}
