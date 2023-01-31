using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CinemaBooking
{
    public partial class SeatInformation : Form
    {
        public static SeatInformation Instance;
        private readonly int MovieSessionId;
        public SeatInformation(int id)
        {
            InitializeComponent();
            Instance = this;
            Owner = MainForm.Instance;
            this.MaximizeToSecondaryMonitor();
            CheckForIllegalCrossThreadCalls = false;
            MovieSessionId = id;
        }
        public static void ShowForm(int id)
        {
            if (Debugger.IsAttached) return;
            if (Screen.AllScreens.All(o => o.Primary)) return;
            if (Instance == null) Instance = new SeatInformation(id);
            Instance.Show();
            Instance.BringToFront();
        }
        public static void CloseForm() { Instance?.Close(); }
        protected override void OnClosed(EventArgs e) { base.OnClosed(e); Instance = null; }
        //protected override void OnLoad(EventArgs e)
        //{
        //    //switch (Properties.Settings.Default.SeatSelectionZoomLevel)
        //    //{
        //    //    case "XS": SetSizes(0); break;
        //    //    case "S": SetSizes(1); break;
        //    //    case "M": SetSizes(2); break;
        //    //    case "L": SetSizes(3); break;
        //    //    case "XL": SetSizes(4); break;
        //    //}
        //    base.OnLoad(e);
        //    //StartThread();
        //}
        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    base.OnClosing(e);
        //    //StopThread();
        //}

        private int SeatWidth = 30;
        private int SeatHeight = 25;
        private float SeatFontSize = 7;
        private bool creating;
        private void CreateSeats(MovieSession session)
        {
            if (creating) return;
            creating = true;
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            //var session = entities.MovieSession.First(o => o.MovieSessionId == MovieSessionId);
            var placeTemplate = session.MovieTheatrePlace.MovieTheatrePlaceTemplate;
            labelTitle.Text = session.Movie.Title.CropIfItsLong(30);
            labelPlace.Text = session.MovieTheatrePlace.MovieTheatrePlaceName;
            labelTime.Text = session.SessionTime.ToString("HH:mm");

            var details = placeTemplate.MovieTheatrePlaceTemplateDetails.ToArray();
            var ColumnCount = details.Max(item => item.ColumnIndex) + 1;
            var RowCount = details.Max(item => item.RowIndex) + 1;

            tableLayoutPanel1.ColumnCount = ColumnCount + 1;
            for (var i = 0; i < ColumnCount; i++) tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, SeatWidth));

            tableLayoutPanel1.RowCount = RowCount + 1;
            for (var i = 0; i < RowCount; i++) tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, SeatHeight));

            tableLayoutPanel1.SuspendLayout();
            foreach (var item in details)
            {
                var detail = details.FirstOrDefault(o => o.Id == item.Id);
                var button = new SeatItem(detail,detail.Id) { Font = new Font("Arial Narrow", SeatFontSize, FontStyle.Bold) };
                tableLayoutPanel1.Controls.Add(button, item.ColumnIndex, item.RowIndex);
            }

            // Separator Control
            for (var i = 0; i < ColumnCount; i++)
            {
                var separator = true;
                foreach (var item in details.Where(o => o.ColumnIndex == i)) { if ((item.MovieSeatTypeId > 3) || (item.MovieSeatTypeId <= 3 && !string.IsNullOrEmpty(item.Prefix))) { separator = false; } }
                if (separator) tableLayoutPanel1.ColumnStyles[i].Width = (int)(SeatWidth / 5d);
            }

            tableLayoutPanel1.ResumeLayout(true);

            //RefreshSeatsStatus();
            creating = false;
        }

        public bool refreshing;
        public void RefreshSeatsStatus(TableLayoutPanel tableLayoutPanel, MovieSessionReservation[] myReservations, MovieSessionReservation[] otherReservations, string[] sold, string[] bookingReservations)
        {


            if (creating) return;
            if (refreshing) return;
            refreshing = true;
            foreach (SeatItem item in tableLayoutPanel.Controls)
            {
                if (string.IsNullOrEmpty(item.Detail.SeatCode)) continue;
                if (sold.Contains(item.Detail.SeatCode))
                {
                    if (item.Status == SeatItem.SeatStatus.Sold) continue;
                    item.Status = SeatItem.SeatStatus.Sold;
                    item.SetBorder();
                }
                else if (otherReservations.Any(r => r.SeatCode == item.Detail.SeatCode && r.Block == item.Detail.Block))
                {
                    if (item.Status == SeatItem.SeatStatus.Sold) continue;
                    item.Status = SeatItem.SeatStatus.Sold;
                    item.SetBorder();
                }
                else if (myReservations.Any(r => r.SeatCode == item.Detail.SeatCode && r.Block == item.Detail.Block))
                {
                    if (item.Status == SeatItem.SeatStatus.Reserving) continue;
                    item.Status = SeatItem.SeatStatus.Reserving;
                    item.SetBorder();
                }
                else if (bookingReservations.Contains(item.Detail.SeatCode ))
                {
                    if (item.Status == SeatItem.SeatStatus.Sold) continue;
                    item.Status = SeatItem.SeatStatus.Sold;
                    item.SetBorder();
                }
                else
                {
                    if (item.Status == SeatItem.SeatStatus.Available) continue;
                    item.Status = SeatItem.SeatStatus.Available;
                    item.SetBorder();
                }
            }
            refreshing = false;
        }

        public void SetSizes(float value, MovieSession session)
        {
            SeatWidth = (int)(30 + value * 7);
            SeatHeight = (int)(35 + value * 7);
            SeatFontSize = (int)(8 + value * 2.5);
            try
            {
                CreateSeats(session);
            }
            catch (Exception)
            {
            }
        }

        //private Thread RefreshThread;
        //private void StartThread()
        //{
        //    if (RefreshThread != null) return;
        //    RefreshThread = new Thread(new ThreadStart(delegate
        //    {
        //        try
        //        {
        //            while (true)
        //            {
        //                RefreshSeatsStatus();
        //                Thread.Sleep(1000);
        //            }
        //        }
        //        catch (ThreadAbortException)
        //        {
        //        }
        //        catch (Exception e)
        //        {
        //            Debug.WriteLine(e);
        //        }
        //    }));
        //    RefreshThread.Start();
        //}
        //private void StopThread()
        //{
        //    try
        //    {
        //        if (RefreshThread != null) RefreshThread.Abort();
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

    }
}
