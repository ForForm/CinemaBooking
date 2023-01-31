using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CinemaBooking
{
  


    public partial class SeatSelection : Form
    {
        MovieTheatrePlaceTemplateBlock[] blockArray;
        TableLayoutPanel tblSessionDetail;
        SeatItem activeSeat;
        BiletTarifeSale _biletTarifeCompany;
        bool _biletTarife = false;

        public static SeatSelection Instance;
        private readonly int _movieSessionId;
        public SeatSelection(int id)
        {
            InitializeComponent();
            Instance = this;
            Owner = MainForm.Instance;
            Location = Owner.Location;
            Size = Owner.Size;
            WindowState = Owner.WindowState;
            CheckForIllegalCrossThreadCalls = false;
            _movieSessionId = id;
            buttonBack.Click += delegate { Close(); };
            buttonNext.Click += delegate { ContinueOperation(); };
        }

        protected static void getNames()
        {
            var c = StaticClass.GetAll(Instance);
            foreach (var item in c) StaticClass.ChangeNames(item);

        }

        public static void ShowForm(int id)
        {

            if (Instance == null) Instance = new SeatSelection(id);
            Instance.Show();
            Instance.BringToFront();
            //getNames();
        }
        public static void CloseForm() { Instance?.Close(); }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DeleteOldReservations();
            switch (Properties.Settings.Default.SeatSelectionZoomLevel)
            {
                case "XS": radioButtonXS.Checked = true; break;
                case "S": radioButtonS.Checked = true; break;
                case "M": radioButtonM.Checked = true; break;
                case "L": radioButtonL.Checked = true; break;
                case "XL": radioButtonXL.Checked = true; break;
                default: radioButtonM.Checked = true; break;
            }
            StartThread();
            tabSession.SelectedIndex = -1;



            //this.tabSession.Location = new Point(this.panel4.Width / 2 - this.tabSession.Size.Width / 2,this.panel4.Height / 2 - this.tabSession.Size.Height / 2);

        }
        protected override void OnClosed(EventArgs e) { base.OnClosed(e); Instance = null; SeatInformation.CloseForm(); }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            using (var entities = new CinemaBookingEntities())
            {
                entities.DeleteMyReservations(_movieSessionId);
                entities.SaveChanges();
            }
            StopThread();
        }
        private void ContinueOperation()
        {
            MovieSessionReservation[] reservations;
            using (var entities = new CinemaBookingEntities())
            {
                reservations = entities.GetMyReservations(_movieSessionId).ToArray();
            }
            if (reservations.Any())
            {
                if (_biletTarifeCompany != null)
                {
                    BiletTarifeSale biletTarifeSale = new BiletTarifeSale();
                    biletTarifeSale.biletTarife = new BiletTarife();
                    biletTarifeSale.biletTarife.TarifeId = _biletTarifeCompany.biletTarife.TarifeId;
                    biletTarifeSale.biletTarife.Tutar = _biletTarifeCompany.biletTarife.Tutar;
                    biletTarifeSale.Kod = _biletTarifeCompany.Kod;
                    biletTarifeSale.KotaId = _biletTarifeCompany.KotaId;
                    biletTarifeSale.OdemeKredili= _biletTarifeCompany.OdemeKredili;
                    biletTarifeSale.OdemeNakit= _biletTarifeCompany.OdemeNakit;
                    TariffSelection.ShowForm(biletTarifeSale, _movieSessionId);
                } else TariffSelection.ShowForm(null, _movieSessionId);
            }
        }

        private int _seatWidth = 30;
        private int _seatHeight = 25;
        private float _seatFontSize = 7;
        private bool _creating;
        


        void ClearReservations()
        {
            //using (var entities = new CinemaBookingEntities())
            //{
            //    var reservation = entities.GetMyReservations(_movieSessionId).FirstOrDefault(o => o.SeatCode == item.Detail.SeatCode && o.Block == item.Detail.Block);

            //    foreach (var item in reservation)
            //    {

            //    }
            //}
        }


        void btnAcenteType_OnClick(object sender, EventArgs eventArg)
        {
            Button btnAcenteType = this.Controls.Find("btnAcenteType", true).FirstOrDefault() as Button;
            if (_biletTarife)
            {
                if (ConfirmForm.GetConfirm("Aktif kampanya iptal edilsin mi?".ChangeLng()))
                {
                    _biletTarife = false;
                    _biletTarifeCompany = null;
                    btnAcenteType.BackColor = SystemColors.Control;

                    RefreshSeatsStatus(tblSessionDetail);
                    return;
                }
                else
                {
                    btnAcenteType.BackColor = System.Drawing.Color.PaleTurquoise;
                    return;
                };
            }

            using (var entities = new CinemaBookingEntities())
            {
                entities.DeleteMyReservations(_movieSessionId);
                entities.SaveChanges();
            }

            _biletTarife = !_biletTarife;
            getAcenteTypes();
        }

        void createTheaterBlockTemp(TabControl tab, MovieTheatrePlaceTemplate movieTheatrePlaceTemplate, int? blocks)
        {

            using (var entities = new CinemaBookingEntities())
            {
                blockArray = entities.MovieTheatrePlaceTemplateBlock.Where(o => o.MovieTheatrePlaceTemplateId
                == movieTheatrePlaceTemplate.MovieTheatrePlaceTemplateId).ToArray();
            }


            for (int i = 0; i < blocks; i++)
            {

                TabPage tabpage = new TabPage();
                tabpage.TabIndex = i;
                tabpage.ImageIndex = 0;

                if (i == 0)
                    tabpage.ImageIndex = 0;
                else if (i == 1)
                    tabpage.ImageIndex = 1;
                else if (i == blocks - 1)
                    tabpage.ImageIndex = 3;
                else
                    tabpage.ImageIndex = 2;


                TableLayoutPanel tlp1 = new TableLayoutPanel();
                tlp1.Dock = System.Windows.Forms.DockStyle.Fill;
                tlp1.Anchor = System.Windows.Forms.AnchorStyles.None;
                //tlp1.BackColor = System.Drawing.Color.Red;
                tlp1.AutoSize = true;
                tlp1.ColumnCount = 1;
                tlp1.RowCount = 1;
                tlp1.Name = "tblSessionDetail" + i.ToString();
                tlp1.Margin = new System.Windows.Forms.Padding(4);

                TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel();
                tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
                tableLayoutPanel2.ColumnCount = 3;
                tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                tableLayoutPanel2.RowCount = 3;
                tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
                tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                tableLayoutPanel2.Controls.Add(tlp1, 1, 1);



                tabpage.Text = blockArray[i].MovieTheaterBlockName.ToString(); //(i + 1).ToString();
                tabpage.Controls.Add(tableLayoutPanel2);
                //tableLayoutPanel2.Controls.Add(tlp1, 1, 1);
                //tabpage.Controls.Add(tableLayoutPanel2);
                //tabpage.Refresh();



                tab.Controls.Add(tabpage);
                tab.ImageList = this.imageList1;
            }


            TabPage tabpage2 = new TabPage();
            tabpage2.TabIndex = blocks ?? 0;
            tabpage2.Text = "Promo";
            //Button aa = new Button();
            //aa.Text = "asasdasd";
            //tabpage2.Controls.Add(aa);
            tabpage2.ImageIndex = -1;
            tab.Controls.Add(tabpage2);


        }


        void createTheaterTemp(MovieTheatrePlaceTemplate movieTheatrePlaceTemplate)
        {
            TableLayoutPanel tblSessionDetail2 = new TableLayoutPanel();
            //tblSessionDetail2.BackColor = System.Drawing.Color.Blue;
            tblSessionDetail2.Dock = System.Windows.Forms.DockStyle.Fill;
            tblSessionDetail2.Anchor = System.Windows.Forms.AnchorStyles.None;
            //tlp1.BackColor = System.Drawing.Color.Red;
            tblSessionDetail2.AutoSize = true;
            tblSessionDetail2.ColumnCount = 1;
            tblSessionDetail2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //tblSessionDetail2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            //tblSessionDetail2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

            tblSessionDetail2.RowCount = 1;
            tblSessionDetail2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            tblSessionDetail2.Name = "tblSessionDetail2";
            tblSessionDetail2.Margin = new System.Windows.Forms.Padding(4);

            TableLayoutPanel tlp1 = new TableLayoutPanel();
            tlp1.Dock = System.Windows.Forms.DockStyle.Fill;
            tlp1.Anchor = System.Windows.Forms.AnchorStyles.None;
            //tlp1.BackColor = System.Drawing.Color.Red;
            tlp1.AutoSize = true;
            tlp1.ColumnCount = 1;
            tlp1.RowCount = 1;
            tlp1.Name = "tblSessionDetail";
            tlp1.Margin = new System.Windows.Forms.Padding(4);

            var CloseImage = imageList1.Images[4];
            Bitmap myBitmap = new Bitmap(CloseImage); // @"C:\Temp\imgSwacaa.jpg");  

            Button btnAcenteType = new Button();
            btnAcenteType.Name = "btnAcenteType";
            btnAcenteType.Dock = System.Windows.Forms.DockStyle.Fill;
            btnAcenteType.BackColor = SystemColors.Control;
            btnAcenteType.Width = 200;
            btnAcenteType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnAcenteType.Image = myBitmap;
            btnAcenteType.Click += btnAcenteType_OnClick;

            //btnAcenteType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            tblSessionDetail2.Controls.Add(btnAcenteType, 3, 0);


            TableLayoutPanel tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(tblSessionDetail2, 3, 0);
            tableLayoutPanel2.Controls.Add(tlp1, 1, 1);
            this.Controls.Add(tableLayoutPanel2);
        }



        private void CreateSeats(MovieSession session)
        {
            //using (var entities = new CinemaBookingEntities())
            //{
            //var session = entities.MovieSession.First(o => o.MovieSessionId == MovieSessionId);
            var placeTemplate = session.MovieTheatrePlace.MovieTheatrePlaceTemplate;
            labelTitle.Text = session.Movie.Title.CropIfItsLong(30);
            labelPlace.Text = session.MovieTheatrePlace.MovieTheatrePlaceName;
            labelTime.Text = session.SessionTime.ToString("HH:mm");

            if (placeTemplate.Block > 0)
            {

                if (_creating) return;
                _creating = true;

                tabSession.Controls.Clear();
                tabSession.ImageList = null;
                //this.tabSession.Size = new System.Drawing.Size(834, 0);
                createTheaterBlockTemp(tabSession, placeTemplate, placeTemplate.Block);
                GetSessionBlockTemplate();


                _creating = false;
            }
            else
            {
                createTheaterTemp(placeTemplate);
                GetSessionTemplate();
            }


        }

        void GetSessionBlockTemplate()
        {
            int _seatWidth = (int)(30 + 3 * 1);
            int _seatHeight = (int)(35 + 3 * 1);
            int _seatFontSize = (int)(8 + 1 * 2.5);


            using (var database = new CinemaBookingEntities())
            {

                var session = database.MovieSession.First(o => o.MovieSessionId == _movieSessionId);
                var placeTemplate = session.MovieTheatrePlace.MovieTheatrePlaceTemplate;

                tblSessionDetail = this.Controls.Find("tblSessionDetail" + tabSession.SelectedIndex.ToString(), true).FirstOrDefault() as TableLayoutPanel;
                if (tblSessionDetail == null) return;

                tblSessionDetail.SuspendLayout();

                tblSessionDetail.Visible = false;
                tblSessionDetail.ColumnStyles.Clear();
                tblSessionDetail.RowStyles.Clear();
                tblSessionDetail.Controls.Clear();
                tblSessionDetail.Visible = true;

                List<MovieTheatrePlaceTemplateDetails> details;
                if (placeTemplate.Block == 0)
                    details = placeTemplate.MovieTheatrePlaceTemplateDetails.ToList();
                else
                    details = placeTemplate.MovieTheatrePlaceTemplateDetails.Where(o => o.Block == tabSession.SelectedIndex).ToList();

                if (details.Count == 0) return;

                var ColumnCount = details.Max(item => item.ColumnIndex) + 1;
                var RowCount = details.Max(item => item.RowIndex) + 1;

                tblSessionDetail.ColumnCount = ColumnCount + 1;
                for (var i = 0; i < ColumnCount; i++)
                {
                    if (i == 0 || i == ColumnCount - 1 || i == ColumnCount - 2)
                        tblSessionDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 44));
                    else
                        tblSessionDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _seatWidth));
                }
                tblSessionDetail.RowCount = RowCount + 1;
                for (var i = 0; i < RowCount; i++) tblSessionDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, _seatHeight));

               

                foreach (var item in details)
                {
                    var detail = details.FirstOrDefault(o => o.Id == item.Id && o.Block == item.Block);
                    int say = detail.Suffix == null ? 0 : Convert.ToInt32(detail.Suffix);
                    int fontSize = 7;
                    if (say >= 100) fontSize = 6;
                    var button = new SeatItem(detail, _movieSessionId) { Font = new Font("Arial Narrow", fontSize, FontStyle.Bold) };
                    button.Status = SeatItem.SeatStatus.Available;
                    button.MouseDown += SeatItem_OnClick;

                    tblSessionDetail.Controls.Add(button, item.ColumnIndex, item.RowIndex);
                }

                // Separator Control
                for (var i = 0; i < ColumnCount; i++)
                {
                    var separator = true;
                    foreach (var item in details.Where(o => o.ColumnIndex == i)) { if ((item.MovieSeatTypeId > 3) || (item.MovieSeatTypeId <= 3 && !string.IsNullOrEmpty(item.Prefix))) { separator = false; } }
                    if (separator) tblSessionDetail.ColumnStyles[i].Width = (int)(_seatWidth / 5d);
                }

            }

            if (tblSessionDetail != null)
                RefreshSeatsStatus(tblSessionDetail);


            tblSessionDetail.ResumeLayout(true);


        }

        void GetSessionTemplate()
        {

            if (_creating) return;
            _creating = true;

            using (var database = new CinemaBookingEntities())
            {
                var session = database.MovieSession.First(o => o.MovieSessionId == _movieSessionId);
                var placeTemplate = session.MovieTheatrePlace.MovieTheatrePlaceTemplate;

                tblSessionDetail = this.Controls.Find("tblSessionDetail", true).FirstOrDefault() as TableLayoutPanel;
                if (tblSessionDetail == null) return;
                tblSessionDetail.Visible = false;
                tblSessionDetail.ColumnStyles.Clear();
                tblSessionDetail.RowStyles.Clear();
                tblSessionDetail.Controls.Clear();
                tblSessionDetail.Visible = true;

                tabSession.ImageList = null;
                this.tabSession.Size = new System.Drawing.Size(834,0);
                
                var details = placeTemplate.MovieTheatrePlaceTemplateDetails.ToArray();
                var ColumnCount = details.Max(item => item.ColumnIndex) + 1;
                var RowCount = details.Max(item => item.RowIndex) + 1;

                tblSessionDetail.ColumnCount = ColumnCount + 1;
                for (var i = 0; i < ColumnCount; i++) tblSessionDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _seatWidth));

                tblSessionDetail.RowCount = RowCount + 1;
                for (var i = 0; i < RowCount; i++) tblSessionDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, _seatHeight));

                tblSessionDetail.SuspendLayout();
                foreach (var item in details)
                {
                    var detail = details.FirstOrDefault(o => o.Id == item.Id);
                    var button = new SeatItem(detail, _movieSessionId) { Font = new Font("Arial Narrow", _seatFontSize, FontStyle.Bold) };
                    button.Status = SeatItem.SeatStatus.Available;
                    button.MouseDown += SeatItem_OnClick;
                    tblSessionDetail.Controls.Add(button, item.ColumnIndex, item.RowIndex);
                }

                // Separator Control
                for (var i = 0; i < ColumnCount; i++)
                {
                    var separator = true;
                    foreach (var item in details.Where(o => o.ColumnIndex == i)) { if ((item.MovieSeatTypeId > 3) || (item.MovieSeatTypeId <= 3 && !string.IsNullOrEmpty(item.Prefix))) { separator = false; } }
                    if (separator) tblSessionDetail.ColumnStyles[i].Width = (int)(_seatWidth / 5d);
                }

                tblSessionDetail.ResumeLayout(true);
            }

            if (tblSessionDetail != null)
                RefreshSeatsStatus(tblSessionDetail);

            _creating = false;
        }

        private bool _refreshing;
        private void RefreshSeatsStatus(TableLayoutPanel tableLayoutPanel)
        {
            if (_creating) return;
            if (_refreshing) return;
            _refreshing = true;

            tblSessionDetail.SuspendLayout();
            using (var entities = new CinemaBookingEntities())
            {
                var myReservations = entities.GetMyReservations(_movieSessionId).ToArray();
                var otherReservations = entities.GetOtherReservations(_movieSessionId).ToArray();
                var bookingReservations = new List<string>(); foreach (var bookingReservation in entities.GetBookingReservations(_movieSessionId).ToArray()) bookingReservations.AddRange(bookingReservation.MovieSessionBookingDetail.Select(movieSessionBookingDetail => movieSessionBookingDetail.SeatCode));
                var sold = entities.MovieTicket.Where(t => t.MovieTicketSale.MovieSessionId == _movieSessionId).Select(t => t.SeatCode).ToArray();
                foreach (SeatItem item in tableLayoutPanel.Controls)
                {



                    if (string.IsNullOrEmpty(item.Detail.SeatCode)) continue;

                    if (_biletTarifeCompany != null)
                    {
                        if (_biletTarifeCompany.biletTarife.TarifeId == 7)
                        {
                            if (item.seatType.MovieSeatTypeId == 7)
                                item.Visible = true;
                            else
                                item.Visible = false;
                        }
                        else
                        {
                            if (item.seatType.MovieSeatTypeId == 7)
                                item.Visible = false;
                            else
                                item.Visible = true;

                        }
                    }
                    else item.Visible = true;

                    if (sold.Contains(item.Detail.SeatCode))
                    {
                        if (item.Status == SeatItem.SeatStatus.Sold) continue;
                        item.Status = SeatItem.SeatStatus.Sold;
                        //item.ContextMenuStrip = menuTicketSale;
                        item.SetBorder();
                    }
                    else if (otherReservations.Any(r => r.SeatCode == item.Detail.SeatCode && (r.Block == null ? 0 : r.Block) == item.Detail.Block))
                    {
                        if (item.Status == SeatItem.SeatStatus.Reserved) continue;
                        item.Status = SeatItem.SeatStatus.Reserved;
                        item.SetBorder();
                    }
                    else if (myReservations.Any(r => r.SeatCode == item.Detail.SeatCode && (r.Block==null?0: r.Block) == item.Detail.Block))
                    {
                        if (item.Status == SeatItem.SeatStatus.Reserving) continue;
                        item.Status = SeatItem.SeatStatus.Reserving;
                        item.SetBorder();
                    }
                    else if (bookingReservations.Contains(item.Detail.SeatCode))
                    {

                        if (item.Status == SeatItem.SeatStatus.BookingReserved) continue;
                        item.Status = SeatItem.SeatStatus.BookingReserved;
                        item.SetBorder();
                    }
                    else
                    {

                        //item.BackgroundImage = null;

                        if (item.Status == SeatItem.SeatStatus.Available) continue;
                        item.Status = SeatItem.SeatStatus.Available;
                        item.SetBorder();

                    }



                    item.Enabled = true;
                }
                Invoke(new Action(delegate
                {
                    buttonNext.Visible = myReservations.Any();
                    labelCount.Text = myReservations.Length.ToString();
                    SeatInformation.Instance?.RefreshSeatsStatus(tableLayoutPanel, myReservations, otherReservations, sold, bookingReservations.ToArray());
                    //buttonReservation.Visible = bookingReservations.Any();
                }));
            }
            UpdateNewReservations();
            _refreshing = false;
            tblSessionDetail.ResumeLayout(true);
        }
        private void UpdateNewReservations()
        {
            using (var entities = new CinemaBookingEntities())
            {
                var reservations = entities.GetMyReservations(_movieSessionId);
                foreach (var item in reservations)
                {
                    if (reservations.Any(r => r.SeatCode == item.SeatCode && r.Block == item.Block))
                    {
                        item.LastUpdate = entities.GetDate();
                        item.SessionId = LoginUser.SessionId;
                    }
                }
                entities.SaveChanges();
            }
        }
        private void DeleteOldReservations()
        {
            using (var entities = new CinemaBookingEntities())
            {
                var reservations = entities.GetOldReservations();
                foreach (var item in reservations) entities.Entry(item).State = EntityState.Deleted;
                entities.SaveChanges();
            }
        }

        private void radioButtonXS_CheckedChanged(object sender, EventArgs e) { Properties.Settings.Default.SeatSelectionZoomLevel = "XS"; Properties.Settings.Default.Save(); SetSizes(0); }
        private void radioButtonS_CheckedChanged(object sender, EventArgs e) { Properties.Settings.Default.SeatSelectionZoomLevel = "S"; Properties.Settings.Default.Save(); SetSizes(1); }
        private void radioButtonM_CheckedChanged(object sender, EventArgs e) { Properties.Settings.Default.SeatSelectionZoomLevel = "M"; Properties.Settings.Default.Save(); SetSizes(2); }
        private void radioButtonL_CheckedChanged(object sender, EventArgs e) { Properties.Settings.Default.SeatSelectionZoomLevel = "L"; Properties.Settings.Default.Save(); SetSizes(3); }
        private void radioButtonXL_CheckedChanged(object sender, EventArgs e) { Properties.Settings.Default.SeatSelectionZoomLevel = "XL"; Properties.Settings.Default.Save(); SetSizes(4); }
        private void SetSizes(float value)
        {
            _seatWidth = (int)(30 + value * 7);
            _seatHeight = (int)(35 + value * 7);
            _seatFontSize = (int)(8 + value * 2.5);
            try
            {
                using (var entities = new CinemaBookingEntities())
                {
                    var session = entities.MovieSession.First(o => o.MovieSessionId == _movieSessionId);
                    CreateSeats(session);
                    if (SeatInformation.Instance != null) SeatInformation.Instance.SetSizes(value, session);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private Thread _refreshThread;
        private void StartThread()
        {
            if (_refreshThread != null) return;
            _refreshThread = new Thread(new ThreadStart(delegate
            {
                try
                {
                    while (true)
                    {
                        RefreshSeatsStatus(tblSessionDetail);
                        Thread.Sleep(1000);
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
                if (_refreshThread != null) _refreshThread.Abort();
            }
            catch (Exception)
            {
            }
        }

        private void buttonReservation_Click(object sender, EventArgs e)
        {
            ReservationList.ShowForm(_movieSessionId);
        }





        private void tabSession_DrawItem(object sender, DrawItemEventArgs e)
        {

            int say = 0;
            //if (_biletTarife) say = this.tabSession.TabCount;
            //else

            say = this.tabSession.TabCount - 1;

            if (e.Index < say)
            {
                var CloseImage = (e.Index == 0 ? imageList1.Images[0] : (e.Index == (this.tabSession.TabCount - 2) ? imageList1.Images[3] :
                    (imageList1.Images[2])));
                Bitmap myBitmap = new Bitmap(CloseImage); // @"C:\Temp\imgSwacaa.jpg");  

                Color backColor = Color.White; // GetPixel(1, 1); 
                Color backColorGray = Color.Gray;
                Color backColorGrayLight = Color.LightGray;
                Color backColorWhiteSmoke = Color.WhiteSmoke;
                Color backColorWhite = Color.White;
                Color backColorWheat = Color.Wheat;
                Color backColorBlack = Color.Black;
                myBitmap.MakeTransparent(backColor);
                myBitmap.MakeTransparent(backColorGray);
                myBitmap.MakeTransparent(backColorGrayLight);
                myBitmap.MakeTransparent(backColorWhiteSmoke);
                myBitmap.MakeTransparent(backColorBlack);

                var tabRect = this.tabSession.GetTabRect(e.Index);
                tabRect.Inflate(-2, -2);
                var imageRect = new Rectangle(tabRect.Right - CloseImage.Width,
                                  tabRect.Top + (tabRect.Height - CloseImage.Height) / 2,
                                  CloseImage.Width,
                                  CloseImage.Height);
                string tabName = tabSession.TabPages[e.Index].Text;
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                //Find if it is selected, this one will be hightlighted...
                if (e.Index == tabSession.SelectedIndex)
                    e.Graphics.FillRectangle(Brushes.PaleTurquoise, e.Bounds);
                e.Graphics.DrawImage(myBitmap, imageRect.Location);
                e.Graphics.DrawString(tabName, new Font("Arial Black", 22), Brushes.Black, tabSession.GetTabRect(e.Index), stringFormat);
            }

            if (e.Index + 1 == this.tabSession.TabCount)
            {
                var CloseImage1 = imageList1.Images[4];
                Bitmap myBitmap1 = new Bitmap(CloseImage1); // @"C:\Temp\imgSwacaa.jpg");  
                

                if (_biletTarife)
                {
                    //if (e.Index + 1 == this.tabSession.TabCount)
                    e.Graphics.FillRectangle(Brushes.PaleTurquoise, e.Bounds);
                }

                var tabRect1 = this.tabSession.GetTabRect(e.Index);
                tabRect1.Inflate(-2, -2);
                var imageRect1 = new Rectangle(tabRect1.Right - CloseImage1.Width,
                                  tabRect1.Top + (tabRect1.Height - CloseImage1.Height) / 3,
                                  CloseImage1.Width,
                                  CloseImage1.Height);

                string tabName1 = tabSession.TabPages[e.Index].Text;
                StringFormat stringFormat1 = new StringFormat();
                stringFormat1.Alignment = StringAlignment.Center;
                stringFormat1.LineAlignment = StringAlignment.Center;
                //Find if it is selected, this one will be hightlighted...
                //if (e.Index == tabSession.SelectedIndex)
                //e.Graphics.FillRectangle(Brushes.PaleTurquoise, e.Bounds);
                e.Graphics.DrawImage(myBitmap1, imageRect1.Location);
                //e.Graphics.DrawString(tabName, new Font("Arial Black", 22), Brushes.Red, tabSession.GetTabRect(e.Index), stringFormat);
            }
        }

        private void SeatItem_OnClick(object sender, MouseEventArgs eventArgs)
        {
            try
            {
                var item = (SeatItem)sender;
                if (item.Status == SeatItem.SeatStatus.Sold)
                { item.ContextMenuStrip = menuTicketSale; }
                else
                { item.ContextMenuStrip = null; }

                if (eventArgs.Button == MouseButtons.Left)
                {
                    if (item.Status != SeatItem.SeatStatus.Available && item.Status != SeatItem.SeatStatus.Reserving) return;
                    if (string.IsNullOrEmpty(item.Detail.SeatCode)) return;

                    using (var entities = new CinemaBookingEntities())
                    {
                        var reservation = entities.GetMyReservations(_movieSessionId).FirstOrDefault(o => o.SeatCode == item.Detail.SeatCode && o.Block == item.Detail.Block);

                        //if (item.Status == SeatItem.SeatStatus.Reserving) item.Status = SeatItem.SeatStatus.Available;


                        if (entities.MovieSessionReservation.Count() == 1 && _biletTarife && item.Status == SeatItem.SeatStatus.Available)
                        {
                            InfoForm.ShowInfo("Kampanya Kodu sadece 1 Koltuk için geçerlidir.".ChangeLng());
                            return;
                        }

                        item.Enabled = false;
                        if (reservation == null)
                        {
                            reservation = new MovieSessionReservation
                            {
                                MovieTheatrePlaceTemplateDetailsId = item.Detail.Id,
                                MovieSeatTypeId = item.Detail.MovieSeatTypeId,
                                SeatPrefix = item.Detail.Prefix,
                                SeatSuffix = item.Detail.Suffix,
                                SeatCode = item.Detail.SeatCode,
                                Block = item.Detail.Block,
                                MovieSessionId = _movieSessionId,
                                LastUpdate = entities.GetDate(),
                                UserId = LoginUser.LoggedUserId,
                                SessionId = LoginUser.SessionId
                            };
                            entities.MovieSessionReservation.Add(reservation);
                        }
                        else
                        {
                            entities.MovieSessionReservation.Remove(reservation);
                        }
                        entities.SaveChanges();
                    }
                }
                else
                {
                    activeSeat = item;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void biletSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(activeSeat.Status.ToString());

            List<String> barcodeList = new List<String>();
            using (var entities = new CinemaBookingEntities())
            {
                
                var BlockName = tabSession.SelectedIndex > -1 ? tabSession.TabPages[tabSession.SelectedIndex].Text : String.Empty;
                BlockName = (tabSession.SelectedIndex > -1 ? (activeSeat.Detail.RowIndex >= 5 ? BlockName.Split('-')[1] : BlockName.Split('-')[0]) : string.Empty);

                var movieTickett = entities.MovieTicket.Where(o => o.SeatCode == activeSeat.Detail.SeatCode && o.SeatSuffix == activeSeat.Detail.Suffix && o.BlockName == BlockName && o.MovieTicketSale.MovieSessionId == _movieSessionId).FirstOrDefault();

                if (movieTickett != null)
                {
                    var MovieTicketSale = movieTickett.MovieTicketSale;
                    var MovieTicket = entities.MovieTicket.Where(o => o.MovieTicketSaleId == MovieTicketSale.MovieTicketSaleId);

                    string strInfo = String.Empty;
                    foreach (var item in MovieTicket)
                        strInfo += item.SeatCode + "-";

                    if (ConfirmForm.GetConfirm(BlockName + " " + strInfo + " bağlı koltuk(lar) - ".ChangeLng() + MovieTicketSale.Amount + " tutarlı bilet iptal edilsin mi?".ChangeLng()))
                    {


                        foreach (var item in MovieTicket.ToList())
                        {
                            var passed= entities.sp_PassageControl(item.BarcodeNumber);
                            if (passed.ToList()[0].Value>0)
                            {
                                InfoForm.ShowInfo("Bilet kullanılmıştır. İptal edilemez..".ChangeLng());
                                return;
                            }
                                
                        }
                        
                        //entities.sp_MovieTicketSale_Delete(MovieTicket.ToList()[0].BarcodeNumber);

                        entities.sp_MovieTicketSale_Delete(MovieTicketSale.MovieTicketSaleId);
                        var booking = entities.MovieSessionBooking.FirstOrDefault(o => o.MovieTicketSaleId == MovieTicketSale.MovieTicketSaleId);
                        if (booking != null) booking.MovieTicketSaleId = null;
                        foreach (var item in entities.MovieTicketSalePayment.Where(o => o.MovieTicketSaleId == MovieTicketSale.MovieTicketSaleId))
                        {
                            //entities.MovieTicketSalePaymentDeleted.Add( new MovieTicketSalePaymentDeleted { Id = item.Id, Amount = item.Amount, MovieTicketSaleId = item.MovieTicketSaleId, MovieTicketSalePaymentTypeId = item.MovieTicketSalePaymentTypeId } );
                            barcodeList.Add(item.Kod);
                            entities.MovieTicketSalePayment.Remove(item);
                        }
                        foreach (var item in entities.MovieTicketSaleOption.Where(o => o.MovieTicketSaleId == MovieTicketSale.MovieTicketSaleId))
                        {
                            entities.MovieTicketSaleOption.Remove(item);
                        }
                        foreach (var item in entities.MovieTicket.Where(o => o.MovieTicketSaleId == MovieTicketSale.MovieTicketSaleId))
                        {
                            //entities.MovieTicketDeleted.Add(new MovieTicketDeleted
                            //{
                            //    Amount = item.Amount,
                            //    BarcodeNumber = item.BarcodeNumber,
                            //    CustomerInfo = item.CustomerInfo,
                            //    IsPrinted = item.IsPrinted,
                            //    MovieSeatTypeId = item.MovieSeatTypeId,
                            //    MovieTariffId = item.MovieTariffId,
                            //    MovieTicketId = item.MovieTicketId,
                            //    MovieTicketSaleId = item.MovieTicketSaleId,
                            //    PrintDate = item.PrintDate,
                            //    PrintLocation = item.PrintLocation,
                            //    SeatCode = item.SeatCode,
                            //    SeatPrefix = item.SeatPrefix,
                            //    SeatSuffix = item.SeatSuffix,
                            //    TicketOrder = item.TicketOrder
                            //});

                            //entities.MovieTicketDeleteInsert(item.MovieTicketId);

                            entities.MovieTicket.Remove(item);
                        }
                        foreach (var item in entities.MovieTicketSale.Where(o => o.MovieTicketSaleId == MovieTicketSale.MovieTicketSaleId))
                        {
                            //entities.MovieTicketSaleDeleted.Add(new MovieTicketSaleDeleted {  Amount=item.Amount, Completed=item.Completed,
                            // DateCreated=item.DateCreated, MovieSessionId=item.MovieSessionId, MovieTicketSaleId=item.MovieTicketSaleId, SessionId=item.SessionId, UserId=item.UserId});

                            entities.MovieTicketSale.Remove(item);
                        }
                        entities.SaveChanges();



                    }
                }

            }
            using (var entities = new FFSaleEntities())
            {
                foreach (var bitem in barcodeList)
                {
                    foreach (var item in entities.BiletKotaKod.Where(o => o.Kod == bitem))
                    {
                        item.Kullanildi = false;
                        item.KullanilmaTarihi = null;
                    }
                }

                entities.SaveChanges();
            }
            
            InfoForm.ShowInfo("İptal işlemi tamamlandı.".ChangeLng());
            //CloseForm();
            if (tabSession.SelectedIndex > -1)
                GetSessionBlockTemplate();
            else GetSessionTemplate();
        }

        void getAcenteTypes()
        {
            using (var entities = new FFSaleEntities())
            {
                if (ConfirmForm.GetConfirm("Kodunuz var mı?".ChangeLng()))
                {

                    ManuelCodeInputForm2 kodInputForm = new ManuelCodeInputForm2();
                    kodInputForm.ShowDialog();
                    if (kodInputForm.DialogResult == DialogResult.OK)
                    {

                        if (kodInputForm.biletKota != null)
                        {

                            var bilettarife = entities.BiletTarife.Where(o => o.TarifeId== kodInputForm.biletKota.TarifeId).FirstOrDefault();
                            var biletKota = entities.BiletKota.Where(o => o.KotaId== kodInputForm._kotaId).FirstOrDefault();
                            _biletTarifeCompany = new BiletTarifeSale();
                            _biletTarifeCompany.biletTarife = new BiletTarife();
                            _biletTarifeCompany.biletTarife = bilettarife;
                            _biletTarifeCompany.biletTarife.Tutar = kodInputForm.biletKota.Tutar;
                            _biletTarifeCompany.OdemeKredili = biletKota.Sozlesme.Acente.OdemeKredili;
                            _biletTarifeCompany.OdemeNakit= biletKota.Sozlesme.Acente.OdemeNakit;
                            _biletTarifeCompany.Kod = kodInputForm._result;
                            _biletTarifeCompany.KotaId= kodInputForm._kotaId;
                            InfoForm.ShowInfo(bilettarife.TarifeAdi + " Tarife için Koltuk seçimi yapabilirsiniz..".ChangeLng());
                            RefreshSeatsStatus(tblSessionDetail);
                            _biletTarife = true;
                            Button btnAcenteType = this.Controls.Find("btnAcenteType", true).FirstOrDefault() as Button;
                            if (btnAcenteType != null)
                                btnAcenteType.BackColor = System.Drawing.Color.PaleTurquoise;
                        }
                        else
                        {
                            _biletTarife = false;
                            Button btnAcenteType = this.Controls.Find("btnAcenteType", true).FirstOrDefault() as Button;
                            if (btnAcenteType != null)
                                btnAcenteType.BackColor = SystemColors.Control;
                        }
                    }
                    else
                    {
                        _biletTarife = false;
                        //MessageBox.Show("Cancel");
                    }

                    //InfoForm.ShowInfo("İptal işlemi tamamlandı.");
                    //CloseForm();
                }
                else
                {
                    var acenteType = entities.AcenteTipi.ToList();
                    AcenteTariffScreen acenteTariffForm = new AcenteTariffScreen(acenteType);
                    acenteTariffForm.ShowDialog();
                    if (acenteTariffForm.DialogResult == DialogResult.OK)
                    {
                        _biletTarifeCompany = new BiletTarifeSale();
                        _biletTarifeCompany.biletTarife = new BiletTarife();
                        _biletTarifeCompany.biletTarife = acenteTariffForm.biletTarifeSale.biletTarife;
                        _biletTarifeCompany.KotaId = acenteTariffForm.biletTarifeSale.KotaId;
                        var biletKota = entities.BiletKota.Where(o => o.KotaId == acenteTariffForm.biletTarifeSale.KotaId).FirstOrDefault();
                        _biletTarifeCompany.OdemeKredili = biletKota.Sozlesme.Acente.OdemeKredili;
                        _biletTarifeCompany.OdemeNakit = biletKota.Sozlesme.Acente.OdemeNakit;
                        InfoForm.ShowInfo(_biletTarifeCompany.biletTarife.TarifeAdi + " Tarife için Koltuk seçimi yapabilirsiniz..".ChangeLng());
                        _biletTarife = true;
                        Button btnAcenteType = this.Controls.Find("btnAcenteType", true).FirstOrDefault() as Button;
                        if (btnAcenteType != null)
                            btnAcenteType.BackColor = System.Drawing.Color.PaleTurquoise;
                        RefreshSeatsStatus(tblSessionDetail);
                    }
                    else
                    {
                        _biletTarife = false;
                        Button btnAcenteType = this.Controls.Find("btnAcenteType", true).FirstOrDefault() as Button;
                        if (btnAcenteType != null)
                            btnAcenteType.BackColor = SystemColors.Control;

                    }


                }
            }
        }


        private void tabSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSession.SelectedIndex == -1) return;

            if (tabSession.SelectedIndex == tabSession.TabCount - 1) return;
            //using (var entities = new CinemaBookingEntities())
            //{
            //    entities.DeleteMyReservations(_movieSessionId);
            //    entities.SaveChanges();
            //}

            GetSessionBlockTemplate();

        }

        private void tabSession_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == -1) return;

            if (e.TabPageIndex == this.tabSession.TabCount - 1)
            {
                if (_biletTarife)
                {
                    if (ConfirmForm.GetConfirm("Aktif kampanya iptal edilsin mi?".ChangeLng()))
                    {
                        _biletTarife = false;
                        _biletTarifeCompany = null;
                        e.Cancel = true;
                        return;
                    }
                    else return;
                }

                using (var entities = new CinemaBookingEntities())
                {
                    entities.DeleteMyReservations(_movieSessionId);
                    entities.SaveChanges();
                }

                _biletTarife = !_biletTarife;
                e.Cancel = true;
                getAcenteTypes();


            }
        }
    }

    public class BiletTarifeSale 
    {
        public BiletTarife biletTarife { get; set; }

        public int? KotaId { get; set; }

        public String Kod { get; set; }

        public bool OdemeNakit { get; set; }

        public bool OdemeKredili { get; set; }

    }
}
