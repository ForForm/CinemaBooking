using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CinemaBooking
{
    public partial class MovieSelection : Form
    {
        public static MovieSelection Instance;
        private int PageIndex { get; set; }
        private const int PageShow = 6;
        public DateTime SelectedDay { get; set; }
        public MovieSelection()
        {
            InitializeComponent();
            Instance = this;
            Owner = MainForm.Instance;
            Location = Owner.Location;
            Size = Owner.Size;
            WindowState = Owner.WindowState;

            CheckForIllegalCrossThreadCalls = false;
            labelUserName.Text = LoginUser.LoggedUserName;

            buttonNext.Click += delegate { PageIndex++; CreateMovies(); };
            buttonBack.Click += delegate { if (PageIndex <= 0) return; PageIndex--; CreateMovies(); };
            buttonLogout.Click += delegate { Close(); };

            radioButton1.CheckedChanged += delegate { if (!radioButton1.Checked) return; SelectedDay = (DateTime)radioButton1.Tag; StopThread(); /*CreateMovies();*/ StartThread(); };
            radioButton2.CheckedChanged += delegate { if (!radioButton2.Checked) return; SelectedDay = (DateTime)radioButton2.Tag; StopThread(); /*CreateMovies();*/ StartThread(); };
            radioButton3.CheckedChanged += delegate { if (!radioButton3.Checked) return; SelectedDay = (DateTime)radioButton3.Tag; StopThread(); /*CreateMovies();*/ StartThread(); };
            radioButton4.CheckedChanged += delegate { if (!radioButton4.Checked) return; SelectedDay = (DateTime)radioButton4.Tag; StopThread(); /*CreateMovies();*/ StartThread(); };

            radioButton5.CheckedChanged += delegate { if (!radioButton5.Checked) return; SelectedDay = (DateTime)radioButton5.Tag; StopThread(); /*CreateMovies();*/ StartThread(); };
            radioButton6.CheckedChanged += delegate { if (!radioButton6.Checked) return; SelectedDay = (DateTime)radioButton6.Tag; StopThread(); /*CreateMovies();*/ StartThread(); };
            radioButton7.CheckedChanged += delegate { if (!radioButton7.Checked) return; SelectedDay = (DateTime)radioButton7.Tag; StopThread(); /*CreateMovies();*/ StartThread(); };
            radioButton8.CheckedChanged += delegate { if (!radioButton8.Checked) return; SelectedDay = (DateTime)radioButton8.Tag; StopThread(); /*CreateMovies();*/ StartThread(); };
            radioButton9.CheckedChanged += delegate { if (!radioButton9.Checked) return; SelectedDay = (DateTime)radioButton9.Tag; StopThread(); /*CreateMovies();*/ StartThread(); };
            radioButton10.CheckedChanged += delegate { if (!radioButton10.Checked) return; SelectedDay = (DateTime)radioButton10.Tag; StopThread(); /*CreateMovies();*/ StartThread(); };


            radioButton1.Tag = DateTime.Today;
            radioButton2.Tag = DateTime.Today.AddDays(1);
            radioButton3.Tag = DateTime.Today.AddDays(2);
            radioButton4.Tag = DateTime.Today.AddDays(3);
            radioButton5.Tag = DateTime.Today.AddDays(4);
            radioButton6.Tag = DateTime.Today.AddDays(5);
            radioButton7.Tag = DateTime.Today.AddDays(6);
            radioButton8.Tag = DateTime.Today.AddDays(7);
            radioButton9.Tag = DateTime.Today.AddDays(8);
            radioButton10.Tag = DateTime.Today.AddDays(9);
            radioButton1.Text = ((DateTime)radioButton1.Tag).ToString("dd MMM") + Environment.NewLine + ((DateTime)radioButton1.Tag).ToString("dddd");
            radioButton2.Text = ((DateTime)radioButton2.Tag).ToString("dd MMM") + Environment.NewLine + ((DateTime)radioButton2.Tag).ToString("dddd");
            radioButton3.Text = ((DateTime)radioButton3.Tag).ToString("dd MMM") + Environment.NewLine + ((DateTime)radioButton3.Tag).ToString("dddd");
            radioButton4.Text = ((DateTime)radioButton4.Tag).ToString("dd MMM") + Environment.NewLine + ((DateTime)radioButton4.Tag).ToString("dddd");
            radioButton5.Text = ((DateTime)radioButton5.Tag).ToString("dd MMM") + Environment.NewLine + ((DateTime)radioButton5.Tag).ToString("dddd");
            radioButton6.Text = ((DateTime)radioButton6.Tag).ToString("dd MMM") + Environment.NewLine + ((DateTime)radioButton6.Tag).ToString("dddd");
            radioButton7.Text = ((DateTime)radioButton7.Tag).ToString("dd MMM") + Environment.NewLine + ((DateTime)radioButton7.Tag).ToString("dddd");
            radioButton8.Text = ((DateTime)radioButton8.Tag).ToString("dd MMM") + Environment.NewLine + ((DateTime)radioButton8.Tag).ToString("dddd");
            radioButton9.Text = ((DateTime)radioButton9.Tag).ToString("dd MMM") + Environment.NewLine + ((DateTime)radioButton9.Tag).ToString("dddd");
            radioButton10.Text = ((DateTime)radioButton10.Tag).ToString("dd MMM") + Environment.NewLine + ((DateTime)radioButton10.Tag).ToString("dddd");
        }


        protected void getNames()
        {
            var c = StaticClass.GetAll(this);
            foreach (var item in c) StaticClass.ChangeNames(item);

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            radioButton1.Checked = true;
            getNames();
        }
        protected override void OnClosed(EventArgs e) { base.OnClosed(e); Instance = null; LoginForm.ShowForm(); }
        protected override void OnClosing(CancelEventArgs e)
        {
            StopThread();
            base.OnClosing(e);
        }
        public static void ShowForm()
        {
            if (Instance == null) Instance = new MovieSelection();
            Instance.Show();
            Instance.BringToFront();
        }
        public static void CloseForm()
        {
            Instance?.Close();
        }
        private void CreateMovies()
        {
            Invoke(new Action(delegate
            {
                var saleId = 0;
                tableLayoutPanel.Controls.Clear();
                using (var entities = new CinemaBookingEntities())
                {
                    var start = SelectedDay;
                    var finish = start.AddDays(1);
                    var tolerance = 0;
                    var parameter = entities.SystemParameter.FirstOrDefault(o => o.ParameterName == "MovieSessionTolerance");
                    if (parameter != null) int.TryParse(parameter.ParameterValue, out tolerance);

                    var movieIdList = entities.MovieSession.Where(item => item.SessionTime > start && item.SessionTime < finish).Select(item => item.MovieId).Distinct().ToArray();
                    var movies = entities.Movie.Where(item => movieIdList.Contains(item.MovieId));
                    if (movies.Any())
                    {
                        foreach (var movie in movies.OrderBy(o => o.MovieId).Skip(PageShow * PageIndex).Take(PageShow))
                        {
                            var item = new MovieItem
                            {
                                MovieObject = movie,
                                MovieSessions = entities.MovieSession.Where(o => o.MovieId == movie.MovieId && o.SessionTime > start && o.SessionTime < finish).OrderBy(o => o.SessionTime).ToArray(),
                                MovieSessionTolerance = tolerance,
                                Dock = DockStyle.Fill
                            };
                            tableLayoutPanel.Controls.Add(item);
                        }
                        buttonBack.Visible = PageIndex > 0;
                        buttonNext.Visible = movies.OrderBy(o => o.MovieId).Skip(PageShow * (PageIndex + 1)).Take(PageShow).Any();
                    }
                    else
                    {

                        var label = new Label { Text = @"Aktif seans bulunamadı.".ChangeLng(), AutoSize = true, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font(Font.FontFamily, 30) };
                        tableLayoutPanel.Controls.Add(label);
                        tableLayoutPanel.SetColumnSpan(label, 2);
                        tableLayoutPanel.SetRowSpan(label, 3);
                        buttonBack.Visible = false;
                        buttonNext.Visible = false;
                    }
                    var sale = entities.MovieTicketSale.FirstOrDefault(o => o.UserId == LoginUser.LoggedUserId && o.Completed == false);
                    if (sale != null)
                    {
                        saleId = sale.MovieTicketSaleId;
                    }
                }
                if (saleId > 0)
                {
                    new Thread(new ThreadStart(delegate
                    {
                        Invoke(new Action(delegate
                        {
                            TicketPrint.ShowForm(saleId,null);
                        }));
                    })).Start();
                }
            }));
        }

        private Thread _refreshThread;
        private void StartThread()
        {
            if (_refreshThread != null) return;
            _refreshThread = new Thread(new ThreadStart(delegate
            {
                try
                {
                    var lastRefresh = new DateTime(2000, 1, 1);
                    while (true)
                    {
                        var time = DateTime.Now;
                        try { using (var entities = new CinemaBookingEntities()) { time = entities.GetDate(); } } catch (Exception e) { Console.WriteLine(e); }
                        labelTime.Text = time.ToString("HH:mm");
                        if (time.Subtract(lastRefresh).TotalSeconds >= 30)
                        {
                            if (SeatSelection.Instance == null) CreateMovies();
                            lastRefresh = time;
                        }
                        Thread.Sleep(TimeSpan.FromSeconds(10));
                    }
                }
                catch (ThreadAbortException)
                {
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }));
            _refreshThread.Start();
        }
        private void StopThread()
        {
            try
            {
                _refreshThread?.Abort();
                _refreshThread = null;
            }
            catch (Exception)
            {
            }
        }

        private void buttonReservation_Click(object sender, EventArgs e)
        {
            try
            {
                var tagId = TapYourCardForm.GetConfirm();
                if (!string.IsNullOrEmpty(tagId))
                {
                    ReservationListByCard.ShowForm(tagId);

                    //var rezCount = 0;
                    //using (var entities = new CinemaBookingEntities())
                    //{
                    //    rezCount = entities.MovieSessionBooking.Where(o => o.Status == "Active").Include(o => o.MovieSessionBookingDetail).Count(o => o.MovieSessionBookingDetail.Any(p => p.CustomerInfo == tagId));
                    //}
                    //if (rezCount == 0)
                    //{
                    //    InfoForm.ShowInfo("Bu karta ait bir rezervasyon bulunamadı.");
                    //}
                    //else if (rezCount == 1)
                    //{
                    //}
                    //else if (rezCount > 1)
                    //{
                    //}

                    //MovieSessionBooking booking;
                    //using (var entities = new CinemaBookingEntities())
                    //{
                    //    booking = entities.MovieSessionBooking.Where(o => o.Status == "Active").Include(o => o.MovieSessionBookingDetail).FirstOrDefault(o => o.MovieSessionBookingDetail.Any(p => p.CustomerInfo == tagId));
                    //    if (booking != null)
                    //    {
                    //        entities.DeleteMyReservations(booking.MovieSessionId);
                    //        entities.SaveChanges();

                    //        var bookingDetails = entities.MovieSessionBookingDetail.Where(o => o.BookingId == booking.Id).ToArray();
                    //        foreach (var bookingDetail in bookingDetails)
                    //        {
                    //            var reservation = new MovieSessionReservation { MovieSeatTypeId = bookingDetail.MovieSeatTypeId, SeatPrefix = bookingDetail.SeatPrefix, SeatSuffix = bookingDetail.SeatSuffix, SeatCode = bookingDetail.SeatCode, MovieSessionId = booking.MovieSessionId, LastUpdate = entities.GetDate(), UserId = LoginUser.LoggedUserId, SessionId = LoginUser.SessionId };
                    //            entities.MovieSessionReservation.Add(reservation);
                    //        }
                    //        entities.SaveChanges();
                    //    }
                    //}
                    //if (booking == null)
                    //{
                    //    InfoForm.ShowInfo("Bu karta ait bir rezervasyon bulunamadı.");
                    //}
                    //else
                    //{
                    //    TariffSelection.ShowForm(booking.MovieSessionId, booking.Id);
                    //}
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

    }
}
