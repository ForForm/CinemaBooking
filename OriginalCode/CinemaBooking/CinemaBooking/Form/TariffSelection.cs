using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CinemaBooking.Class;
using CinemaBooking.Model;
using Telerik.Reporting;

namespace CinemaBooking
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class TariffSelection : Form
    {
        private const string ReceiptPrinterName = "Fiş Yazıcı";
        private SerialPort _posSerial;
        private readonly int _movieSessionId;
        private readonly int? _movieSessionBookingId;
        public static TariffSelection Instance;
        private readonly SellingActionClass SellingAction = new SellingActionClass();
        private readonly List<Label> PaymentLabels = new List<Label>();
        private Button _buttonPayment;
        private Button _buttonReservation;
        private Button _buttonReservationCancellation;
        private readonly List<string> _tagIdList = new List<string>();
        public static BiletTarifeSale _biletTarifeCompany;
        public static decimal? reservationAmount = 0;


        public TariffSelection(int movieSessionId, int? movieSessionBookingId)
        {
            reservationAmount = 0;
            InitializeComponent();
            Instance = this;
            Owner = MainForm.Instance;
            Location = Owner.Location;
            Size = Owner.Size;
            WindowState = Owner.WindowState;


            _movieSessionId = movieSessionId;
            _movieSessionBookingId = movieSessionBookingId;
            buttonBack.Click += delegate { CloseForm(); };

            buttonNext1.Click += delegate { tabControl1.SelectTab(tabPage2); };
            buttonNext2.Click += delegate { tabControl1.SelectTab(tabPage3); };
            buttonPrev1.Click += delegate { tabControl1.SelectTab(tabPage1); };
            buttonPrev2.Click += delegate { tabControl1.SelectTab(tabPage2); };

            if (movieSessionBookingId != null)
            {
                using (var entities = new CinemaBookingEntities())
                {
                    var movieSessionBookingDetail = entities.MovieSessionBookingDetail.Where(o => o.BookingId == movieSessionBookingId).FirstOrDefault();
                    reservationAmount = movieSessionBookingDetail.Amount;
                }

                tabControl1.SelectTab(tabPage2);

            }

        }
        protected override void OnLoad(EventArgs e) { base.OnLoad(e); CreateItems(); }
        protected override void OnClosed(EventArgs e) { base.OnClosed(e); Instance = null; }
        public static void ShowForm(BiletTarifeSale biletTarifeCompanySale, int movieSessionId, int? movieSessionBookingId = null)
        {
            _biletTarifeCompany = biletTarifeCompanySale;
            if (Instance == null) Instance = new TariffSelection(movieSessionId, movieSessionBookingId);
            Instance.Show();
            Instance.BringToFront();
        }
        public static void CloseForm()
        {
            if (Instance != null)
            {
                if (Instance._movieSessionBookingId != null)
                {
                    using (var entities = new CinemaBookingEntities())
                    {
                        entities.DeleteMyReservations(Instance._movieSessionId);
                        entities.SaveChanges();
                    }
                }
                Instance.Close();
            }
        }
        private void CreateItems()
        {
            Invoke(new Action(delegate
            {
                panel1.Controls.Clear();




                using (var entities = new CinemaBookingEntities())
                {
                    var session = entities.MovieSession.FirstOrDefault(item => item.MovieSessionId == _movieSessionId);
                    if (session != null)
                    {
                        labelTitle.Text = session.Movie.Title.CropIfItsLong(30);
                        labelPlace.Text = session.MovieTheatrePlace.MovieTheatrePlaceName;
                        labelTime.Text = session.SessionTime.ToString("HH:mm");

                        #region Pre
                        SellingAction.Types.Clear();
                        var reservations = entities.GetMyReservations(_movieSessionId);
                        var seatTypes = session.MovieSessionAmount.Where(o => reservations.Any(r => r.MovieSessionId == o.MovieSessionId && r.MovieSeatTypeId == o.MovieSeatTypeId)).Select(o => o.MovieSeatType).Distinct().ToArray();
                        foreach (var seatType in seatTypes)
                        {
                            var type1 = new InternalType1()
                            {
                                SeatType = seatType,
                                MustBe = reservations.Count(r => r.MovieSeatTypeId == seatType.MovieSeatTypeId),
                                Tariffs = new List<InternalType2>()
                            };

                            List<MovieTariff> tariffs = new List<MovieTariff>();
                            if (seatType.MovieSeatTypeId == 7)
                                tariffs = session.MovieSessionAmount.Where(o => o.MovieSeatTypeId == seatType.MovieSeatTypeId).Select(o => o.MovieTariff).Where(o => o.MovieTariffId == 7).Distinct().ToList();
                            else
                                tariffs = session.MovieSessionAmount.Where(o => o.MovieSeatTypeId == seatType.MovieSeatTypeId).Select(o => o.MovieTariff).Where(o => o.MovieTariffId != 7).Distinct().ToList();


                            foreach (var tariff in tariffs)
                            {

                                if (_biletTarifeCompany != null)
                                { if (tariff.MovieTariffId != _biletTarifeCompany.biletTarife.TarifeId) continue; }


                                MovieSessionAmount amount = new MovieSessionAmount();
                                if (seatType.MovieSeatTypeId == 7)
                                {
                                    int say = 0;
                                    foreach (var item in reservations.Where(o => o.MovieSeatTypeId == 7).ToList())
                                    {

                                        amount = entities.MovieSessionAmount.Where(o => o.MovieSessionId == session.MovieSessionId && o.MovieSeatTypeId == seatType.MovieSeatTypeId && o.MovieTheatrePlaceTemplateDetailsId == item.MovieTheatrePlaceTemplateDetailsId).FirstOrDefault();

                                        if (amount == null)
                                            say++;

                                        if (amount != null)
                                        {
                                            var type2 = new InternalType2()
                                            {
                                                Parent = type1,
                                                Tariff = tariff,
                                                Amount = amount.Amount,
                                                Count = item.MovieTheatrePlaceTemplateDetailsId != null ? 1 : 0
                                            };
                                            type1.Tariffs.Add(type2);

                                        }
                                    }

                                    if (say > 0)
                                    {
                                        amount = entities.MovieSessionAmount.FirstOrDefault(o => o.MovieSessionId == session.MovieSessionId && o.MovieSeatTypeId == seatType.MovieSeatTypeId && o.MovieTariffId == tariff.MovieTariffId && o.MovieTheatrePlaceTemplateDetailsId == null);

                                        var type2 = new InternalType2()
                                        {
                                            Parent = type1,
                                            Tariff = tariff,
                                            Amount = amount.Amount,
                                            Count = say
                                        };
                                        type1.Tariffs.Add(type2);
                                    }

                                }
                                else
                                {

                                    if (_biletTarifeCompany == null)
                                        amount = entities.MovieSessionAmount.FirstOrDefault(o => o.MovieSessionId == session.MovieSessionId && o.MovieSeatTypeId == seatType.MovieSeatTypeId && o.MovieTariffId == tariff.MovieTariffId);
                                    else
                                    {
                                        if (tariff.MovieTariffId == _biletTarifeCompany.biletTarife.TarifeId)
                                            amount.Amount = _biletTarifeCompany.biletTarife.Tutar;
                                        else
                                            amount.Amount = 0;

                                    }

                                    if (amount == null) continue;


                                    var type2 = new InternalType2()
                                    {
                                        Parent = type1,
                                        Tariff = tariff,
                                        Amount = amount.Amount,
                                        Count = _biletTarifeCompany != null ? (tariff.MovieTariffId == _biletTarifeCompany.biletTarife.TarifeId ? 1 : 0) : (type1.Tariffs.Count == 0 ? type1.MustBe : 0)
                                    };
                                    type1.Tariffs.Add(type2);
                                }
                            }
                            SellingAction.Types.Add(type1);
                        }

                        /*************** OPTIONAL ITEMS *****************/
                        SellingAction.Products.Clear();
                        foreach (var item in entities.MovieTicketOption) SellingAction.Products.Add(new InternalType4 { Product = item, Amount = (decimal)item.Amount });

                        /************* RESERVATION BOOKING **************/
                        if (_movieSessionBookingId != null)
                        {
                            foreach (var type in SellingAction.Types)
                                foreach (var tariff in type.Tariffs)
                                    tariff.Count = 0;

                            var details = entities.MovieSessionBookingDetail.Where(o => o.BookingId == _movieSessionBookingId.Value).ToArray();
                            _tagIdList.AddRange(details.Where(o => !string.IsNullOrEmpty(o.CustomerInfo)).Select(o => o.CustomerInfo));

                            foreach (var detail in details)
                            {
                                var type = SellingAction.Types.FirstOrDefault(o => o.SeatType.MovieSeatTypeId == detail.MovieSeatTypeId);
                                var tariff = type?.Tariffs.FirstOrDefault(o => o.Tariff.MovieTariffId == detail.MovieTariffId);
                                if (tariff != null)
                                {
                                    tariff.Count++;
                                }
                            }
                        }

                        #endregion

                        #region Panel1
                        panel1.RowStyles.Clear();
                        //panel1.Height = 100;
                        panel1.AutoScroll = true;
                        panel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 0));
                        foreach (var item in SellingAction.Types)
                        {
                            panel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                            var seatTypeLabel = GetLabelType1(item);
                            panel1.Controls.Add(seatTypeLabel, 1, panel1.RowStyles.Count - 1);
                            panel1.Controls.Add(GetLabelType2(item.Tariffs.First()), 2, panel1.RowStyles.Count - 1);
                            panel1.Controls.Add(GetLabelType2Amount(item.Tariffs.First()), 3, panel1.RowStyles.Count - 1);
                            panel1.Controls.Add(GetButtonDecrease(item.Tariffs.First()), 4, panel1.RowStyles.Count - 1);
                            panel1.Controls.Add(GetLabelType2Count(item.Tariffs.First()), 5, panel1.RowStyles.Count - 1);
                            panel1.Controls.Add(GetButtonIncrease(item.Tariffs.First()), 6, panel1.RowStyles.Count - 1);
                            panel1.Controls.Add(GetLabelType2Total(item.Tariffs.First()), 7, panel1.RowStyles.Count - 1);
                            for (var j = 1; j < item.Tariffs.Count; j++)
                            {
                                var tariff = item.Tariffs[j];
                                panel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                                panel1.Controls.Add(GetLabelType2(tariff), 2, panel1.RowStyles.Count - 1);
                                panel1.Controls.Add(GetLabelType2Amount(tariff), 3, panel1.RowStyles.Count - 1);
                                panel1.Controls.Add(GetButtonDecrease(tariff), 4, panel1.RowStyles.Count - 1);
                                panel1.Controls.Add(GetLabelType2Count(tariff), 5, panel1.RowStyles.Count - 1);
                                panel1.Controls.Add(GetButtonIncrease(tariff), 6, panel1.RowStyles.Count - 1);
                                panel1.Controls.Add(GetLabelType2Total(tariff), 7, panel1.RowStyles.Count - 1);
                            }
                            panel1.SetRowSpan(seatTypeLabel, item.Tariffs.Count);
                            panel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10));
                        }
                        panel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        panel1.Controls.Add(GetLabel("Toplam:".ChangeLng(), _defaultMarginRightFar, 4, true), 3, panel1.RowStyles.Count - 1);
                        panel1.Controls.Add(GetLabelSellingActionTotalSeat(), 7, panel1.RowStyles.Count - 1);

                        panel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        panel1.Controls.Add(GetLabel("Genel Toplam:".ChangeLng(), _defaultMarginRightFar, 4, true), 3, panel1.RowStyles.Count - 1);
                        panel1.Controls.Add(GetLabelSellingActionTotal(), 7, panel1.RowStyles.Count - 1);

                        if (_movieSessionBookingId == null && GetTotalSeatCount() == 1)
                        {
                            panel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10));
                            panel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                            panel1.Controls.Add(GetButtonReservation(), 3, panel1.RowStyles.Count - 1);
                        }
                        if (_movieSessionBookingId != null)
                        {
                            panel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10));
                            panel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                            panel1.Controls.Add(GetButtonReservationCancellation(), 3, panel1.RowStyles.Count - 1);
                        }

                        panel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                        panel1.RowCount = panel1.RowStyles.Count;
                        #endregion

                        #region Panel2
                        panel2.RowStyles.Clear();
                        panel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                        foreach (var item in SellingAction.Products)
                        {
                            panel2.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                            panel2.Controls.Add(GetLabelType4Barcode(item), 1, panel2.RowStyles.Count - 1);
                            panel2.Controls.Add(GetLabelType4Name(item), 2, panel2.RowStyles.Count - 1);
                            panel2.Controls.Add(GetLabelType4Amount(item), 3, panel2.RowStyles.Count - 1);
                            panel2.Controls.Add(GetButtonDecrease(item), 4, panel2.RowStyles.Count - 1);
                            panel2.Controls.Add(GetLabelType4Count(item), 5, panel2.RowStyles.Count - 1);
                            panel2.Controls.Add(GetButtonIncrease(item), 6, panel2.RowStyles.Count - 1);
                            panel2.Controls.Add(GetLabelType4Total(item), 7, panel2.RowStyles.Count - 1);
                        }
                        panel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 10));
                        panel2.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        panel2.Controls.Add(GetLabel("Toplam:".ChangeLng(), _defaultMarginRightFar, 4, true), 3, panel2.RowStyles.Count - 1);
                        panel2.Controls.Add(GetLabelSellingActionTotalOption(), 7, panel2.RowStyles.Count - 1);
                        panel2.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        panel2.Controls.Add(GetLabel("Genel Toplam:".ChangeLng(), _defaultMarginRightFar, 4, true), 3, panel2.RowStyles.Count - 1);
                        panel2.Controls.Add(GetLabelSellingActionTotal(), 7, panel2.RowStyles.Count - 1);
                        panel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                        panel2.RowCount = panel2.RowStyles.Count;
                        #endregion

                        #region Panel3
                        panel3.RowStyles.Clear();
                        panel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                        SellingAction.Payments.Clear();
                        foreach (var type in entities.MovieTicketSalePaymentType) SellingAction.Payments.Add(type, 0);

                        foreach (var type in entities.MovieTicketSalePaymentType)
                        {

                            //if (_biletTarifeCompany != null)
                            //{
                            //    if (_biletTarifeCompany.OdemeKredili)
                            //    {
                            //        if (type.MovieTicketSalePaymentTypeId == 1) continue;
                            //        if (type.MovieTicketSalePaymentTypeId == 2) continue;
                            //    }

                            //    if (_biletTarifeCompany.OdemeNakit)
                            //        if (type.MovieTicketSalePaymentTypeId == 3) continue;

                            //}
                            //else
                            //    if (type.MovieTicketSalePaymentTypeId == 3) continue;

                            panel3.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                            var button = GetButtonPayment(type);
                            panel3.Controls.Add(button, 3, panel3.RowStyles.Count - 1);

                            var label = GetLabel(type.MovieTicketSalePaymentTypeName, _defaultMargin, 1, true);
                            label.Tag = type;
                            PaymentLabels.Add(label);
                            panel3.Controls.Add(label, 7, panel3.RowStyles.Count - 1);
                        }

                        panel3.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        var paraustu = GetLabel("Paraüstü:".ChangeLng(), _defaultMarginRightFar, 4, true);
                        paraustu.Padding = _paymentButtonPadding;
                        panel3.Controls.Add(paraustu, 3, panel3.RowStyles.Count - 1);
                        panel3.Controls.Add(GetLabelSellingActionChange(), 7, panel3.RowStyles.Count - 1);

                        panel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 10));

                        panel3.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        panel3.Controls.Add(GetButtonPOS(), 3, panel3.RowStyles.Count - 1);

                        panel3.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        panel3.Controls.Add(GetButtonCheckout(), 3, panel3.RowStyles.Count - 1);

                        panel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                        panel3.RowCount = panel3.RowStyles.Count;
                        #endregion

                    }
                }
                SellingAction.UpdatePrices();
                RefreshPaymentLabels();
            }));
        }

        private readonly Padding _defaultMargin = Padding.Empty;
        private readonly Padding _defaultMarginLeftFar = new Padding(10, 0, 0, 0);
        private readonly Padding _defaultMarginRightFar = new Padding(0, 0, 10, 0);
        private readonly Padding _defaultPadding = new Padding(5, 5, 5, 5);
        private readonly Padding _paymentButtonPadding = new Padding(15, 15, 5, 15);
        private Label GetLabelType1(InternalType1 item)
        {
            return new Label { Text = item.SeatType.MovieSeatTypeName, AutoSize = true, Margin = _defaultMargin, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };
        }
        private Label GetLabelType2(InternalType2 item)
        {
            var result = new Label { Text = item.Tariff.MovieTariffName, AutoSize = true, Margin = _defaultMargin, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };
            if (item.Tariff.CustomerAuthorization) result.ForeColor = Color.Blue;
            return result;
        }
        private Label GetLabelType2Amount(InternalType2 item)
        {
            var result = new Label { AutoSize = true, Margin = _defaultMargin, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };
            result.DataBindings.Add("Text", item, "Amount", true, DataSourceUpdateMode.OnPropertyChanged, "", "C");
            if (item.Tariff.CustomerAuthorization) result.ForeColor = Color.Blue;
            return result;
        }
        private Label GetLabelType2Count(InternalType2 item)
        {
            var result = new Label { AutoSize = true, Margin = _defaultMargin, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };
            result.DataBindings.Add("Text", item, "Count");
            if (item.Tariff.CustomerAuthorization) result.ForeColor = Color.Blue;
            return result;
        }
        private Button GetButtonDecrease(InternalType2 item)
        {
            var button = new Button { Tag = item, Text = @"—", Margin = _defaultMarginLeftFar, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, TabStop = false, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, FlatStyle = FlatStyle.Popup };
            button.Click += Type2DecreaseButtonClick;
            return button;
        }
        private Button GetButtonIncrease(InternalType2 item)
        {
            var button = new Button { Tag = item, Text = @"+", Margin = _defaultMarginRightFar, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, TabStop = false, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, FlatStyle = FlatStyle.Popup };
            button.Click += Type2IncreaseButtonClick;
            return button;
        }
        private Label GetLabelType2Total(InternalType2 item)
        {
            var result = new Label { AutoSize = true, Margin = _defaultMargin, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };
            result.DataBindings.Add("Text", item, "Total", true, DataSourceUpdateMode.OnPropertyChanged, "", "C");
            if (item.Tariff.CustomerAuthorization) result.ForeColor = Color.Blue;
            return result;
        }

        private Label GetLabelType4Barcode(InternalType4 item)
        {
            return new Label { Text = item.Product.BarcodeNumber, AutoSize = true, Margin = _defaultMargin, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };
        }
        private Label GetLabelType4Name(InternalType4 item)
        {
            return new Label { Text = item.Product.TicketOptionName, AutoSize = true, Margin = _defaultMargin, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };
        }
        private Label GetLabelType4Amount(InternalType4 item)
        {
            var label = new Label { AutoSize = true, Margin = _defaultMargin, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };
            label.DataBindings.Add("Text", item, "Amount", true, DataSourceUpdateMode.OnPropertyChanged, "", "C");
            return label;
        }
        private Label GetLabelType4Count(InternalType4 item)
        {
            var label = new Label { AutoSize = true, Margin = _defaultMargin, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };
            label.DataBindings.Add("Text", item, "Count");
            return label;
        }
        private Button GetButtonDecrease(InternalType4 item)
        {
            var button = new Button { Tag = item, Text = @"—", Margin = _defaultMarginLeftFar, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, TabStop = false, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, FlatStyle = FlatStyle.Popup };
            button.Click += Type4DecreaseButtonClick;
            return button;
        }
        private Button GetButtonIncrease(InternalType4 item)
        {
            var button = new Button { Tag = item, Text = @"+", Margin = _defaultMarginRightFar, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, TabStop = false, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, FlatStyle = FlatStyle.Popup };
            button.Click += Type4IncreaseButtonClick;
            return button;
        }
        private Label GetLabelType4Total(InternalType4 item)
        {
            var label = new Label { AutoSize = true, Margin = _defaultMargin, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };
            label.DataBindings.Add("Text", item, "Total", true, DataSourceUpdateMode.OnPropertyChanged, "", "C");
            return label;
        }

        private Label GetLabel(string text, Padding margin, int columnSpan = 1, bool bold = false)
        {
            var label = new Label { Text = text, Font = new Font(Font, bold ? FontStyle.Bold : FontStyle.Regular), AutoSize = true, Margin = margin, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };
            panel1.SetColumnSpan(label, columnSpan);
            return label;
        }
        private Label GetLabelSellingActionTotal()
        {
            var label = new Label { AutoSize = true, Font = new Font(Font, FontStyle.Bold), Margin = _defaultMargin, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };
            label.DataBindings.Add("Text", SellingAction, "TotalAmount", true, DataSourceUpdateMode.OnPropertyChanged, "", "C");
            return label;
        }
        private Label GetLabelSellingActionTotalSeat()
        {
            var label = new Label { AutoSize = true, Font = new Font(Font, FontStyle.Bold), Margin = _defaultMargin, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };
            label.DataBindings.Add("Text", SellingAction, "TotalAmountSeat", true, DataSourceUpdateMode.OnPropertyChanged, "", "C");
            return label;
        }
        private Label GetLabelSellingActionTotalOption()
        {
            var label = new Label { AutoSize = true, Font = new Font(Font, FontStyle.Bold), Margin = _defaultMargin, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };
            label.DataBindings.Add("Text", SellingAction, "TotalAmountOption", true, DataSourceUpdateMode.OnPropertyChanged, "", "C");
            return label;
        }
        private Label GetLabelSellingActionChange()
        {
            var label = new Label { AutoSize = true, Font = new Font(Font, FontStyle.Bold), Margin = _defaultMargin, Padding = _defaultPadding, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };
            label.DataBindings.Add("Text", SellingAction, "TotalChange", true, DataSourceUpdateMode.OnPropertyChanged, "", "C");
            return label;
        }
        private Button GetButtonPayment(MovieTicketSalePaymentType type)
        {
            var button = new Button { Tag = type, Text = string.Format("{0}:", type.MovieTicketSalePaymentTypeName.ChangeLng()), AutoSize = true, Font = new Font(Font, FontStyle.Bold), Margin = _defaultMarginRightFar, Padding = _paymentButtonPadding, TextAlign = ContentAlignment.MiddleRight, Dock = DockStyle.Fill, TabStop = false, AutoSizeMode = AutoSizeMode.GrowAndShrink, FlatStyle = FlatStyle.Popup };
            panel1.SetColumnSpan(button, 4);
            button.Click += PaymentButtonClick;
            return button;
        }
        private Button GetButtonCheckout()
        {
            var button = new Button { Text = @"İşlemi Tamamla".ChangeLng(), AutoSize = true, Font = new Font(Font, FontStyle.Bold), Margin = _defaultMargin, Padding = _paymentButtonPadding, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill, TabStop = false, AutoSizeMode = AutoSizeMode.GrowAndShrink, FlatStyle = FlatStyle.Popup };
            panel1.SetColumnSpan(button, 5);
            button.Click += CheckoutButtonClick;
            _buttonPayment = button;
            return button;
        }
        private Button GetButtonReservation()
        {
            var button = new Button { Text = @"Rezervasyon Yap".ChangeLng(), AutoSize = true, Font = new Font(Font, FontStyle.Bold), Margin = _defaultMargin, Padding = _paymentButtonPadding, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill, TabStop = false, AutoSizeMode = AutoSizeMode.GrowAndShrink, FlatStyle = FlatStyle.Popup };
            panel1.SetColumnSpan(button, 5);
            button.Click += ReservationButtonClick;
            _buttonReservation = button;
            return button;
        }
        private Button GetButtonReservationCancellation()
        {
            var button = new Button { Text = @"Rezervasyonu İptal Et".ChangeLng(), AutoSize = true, Font = new Font(Font, FontStyle.Bold), Margin = _defaultMargin, Padding = _paymentButtonPadding, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill, TabStop = false, AutoSizeMode = AutoSizeMode.GrowAndShrink, FlatStyle = FlatStyle.Popup, BackColor = Color.Red, ForeColor = Color.White };
            panel1.SetColumnSpan(button, 5);
            button.Click += ReservationCancellationButtonClick;
            _buttonReservationCancellation = button;
            return button;
        }
        private Button GetButtonPOS()
        {
            var button = new Button { Text = @"POS'a Gönder".ChangeLng(), AutoSize = true, Font = new Font(Font, FontStyle.Bold), Margin = _defaultMargin, Padding = _paymentButtonPadding, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill, TabStop = false, AutoSizeMode = AutoSizeMode.GrowAndShrink, FlatStyle = FlatStyle.Popup };
            panel1.SetColumnSpan(button, 5);
            button.Click += POSButtonClick;
            return button;
        }

        private void Type2DecreaseButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (InternalType2)button.Tag;
            if (item.Parent.Tariffs.Count > 1 && item.Count > 0)
            {
                var other = item.Parent.Tariffs.Where(o => !o.Equals(item) && !o.Tariff.CustomerAuthorization).OrderByDescending(o => o.Count).FirstOrDefault();
                if (other != null)
                {
                    var authorized = false;
                    if (!item.Tariff.CustomerAuthorization)
                    {
                        authorized = true;
                    }
                    else if (_movieSessionBookingId == null)
                    {
                        var tagId = TapYourCardForm.GetConfirm();
                        if (!string.IsNullOrEmpty(tagId))
                        {
                            if (!_tagIdList.Contains(tagId))
                            {
                                InfoForm.ShowInfo("Bu kartı daha önce okutmamışsınız.\nLütfen başka bir kart deneyin.");
                            }
                            else
                            {
                                _tagIdList.Remove(tagId);
                                authorized = true;
                            }
                        }
                    }
                    if (authorized)
                    {
                        other.Count++;
                        item.Count--;
                        SellingAction.UpdatePrices();
                    }
                }
            }
            RefreshPaymentLabels();
        }
        private void Type2IncreaseButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (InternalType2)button.Tag;
            if (item.Parent.Tariffs.Count > 1)
            {
                var other = item.Parent.Tariffs.Where(o => !o.Equals(item) && o.Count > 0 && !o.Tariff.CustomerAuthorization).OrderByDescending(o => o.Count).FirstOrDefault();
                if (other != null)
                {
                    var authorized = false;
                    if (!item.Tariff.CustomerAuthorization)
                    {
                        authorized = true;
                    }
                    else if (_movieSessionBookingId == null)
                    {
                        var tagId = TapYourCardForm.GetConfirm();
                        if (!string.IsNullOrEmpty(tagId))
                        {
                            if (_tagIdList.Contains(tagId))
                            {
                                InfoForm.ShowInfo("Bu kartı zaten okuttunuz.\nLütfen başka bir kart deneyin.");
                            }
                            else
                            {
                                var tagResult = CustomerAuthorizationCheckViewModel.Get(tagId);
                                if (tagResult != null)
                                {
                                    if (tagResult.Result)
                                    {
                                        authorized = true;
                                        _tagIdList.Add(tagId);
                                    }
                                    else
                                    {
                                        InfoForm.ShowInfo(tagResult.Description);
                                    }
                                }
                                else
                                {
                                    InfoForm.ShowInfo("Bir hata meydana geldi.".ChangeLng());
                                }
                            }
                        }
                    }
                    if (authorized)
                    {
                        other.Count--;
                        item.Count++;
                        SellingAction.UpdatePrices();
                    }
                }
            }
            RefreshPaymentLabels();
        }
        private void Type4DecreaseButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (InternalType4)button.Tag;
            if (item.Count > 0)
            {
                item.Count--;
                SellingAction.UpdatePrices();
            }
            RefreshPaymentLabels();
        }
        private void Type4IncreaseButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (InternalType4)button.Tag;
            item.Count++;
            SellingAction.UpdatePrices();
            RefreshPaymentLabels();
        }
        private void PaymentButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (MovieTicketSalePaymentType)button.Tag;

            //MovieTicketSalePaymentType aa = new MovieTicketSalePaymentType();
            //aa.MovieTicketSalePaymentTypeId = 1;
            //aa.MovieTicketSalePaymentTypeName= "Nakit";
     

            var otherSum = SellingAction.Payments.Where(o => o.Key != item).Sum(o => o.Value);
            var left = SellingAction.TotalAmount - otherSum;
            decimal? value = 0M;
            if (_biletTarifeCompany != null)
            {
                value = _biletTarifeCompany.biletTarife.Tutar;
                _buttonPayment.Enabled = true;
            }
            else
                value = AmountSelection.GetSelection(left, SellingAction.Payments[item]);

            if (value != null)
            {
                SellingAction.PaymentType = button.Text;
                SellingAction.Payments[item] = value.Value;
                SellingAction.UpdatePrices();
                RefreshPaymentLabels();
            }
        }




        private void CheckoutButtonClick(object sender, EventArgs e)
        {
            if (SellingAction.TotalChange < 0) return;

            PrintInternalClass(SellingAction, false);
            using (var entities = new CinemaBookingEntities())
            {
                var reservations = entities.GetMyReservations(_movieSessionId);
                var products = SellingAction.Products.Where(o => o.Count > 0);

                var sale = new MovieTicketSale
                {
                    MovieSessionId = _movieSessionId,
                    Amount = SellingAction.TotalAmount,
                    DateCreated = entities.GetDate(),
                    UserId = LoginUser.LoggedUserId,
                    SessionId = LoginUser.SessionId,
                    Completed = false
                };
                entities.MovieTicketSale.Add(sale);
                entities.SaveChanges();

                if (_movieSessionBookingId != null)
                {
                    var booking = entities.MovieSessionBooking.Single(o => o.Id == _movieSessionBookingId.Value);
                    booking.MovieTicketSaleId = sale.MovieTicketSaleId;
                    entities.SaveChanges();
                }

                foreach (var type in SellingAction.Payments.Keys)
                {
                    if (SellingAction.Payments[type] == 0) continue;
                    var payment = new MovieTicketSalePayment
                    {
                        MovieTicketSaleId = sale.MovieTicketSaleId,
                        MovieTicketSalePaymentTypeId = type.MovieTicketSalePaymentTypeId,
                        Amount = (type.IsDefault ? SellingAction.TotalAmountOfDefaultPaymentType : SellingAction.Payments[type]),
                        Kod = _biletTarifeCompany != null ? _biletTarifeCompany.Kod : null,
                        KotaId = _biletTarifeCompany != null ? _biletTarifeCompany.KotaId : null,
                        KodUsed= _biletTarifeCompany != null ? (_biletTarifeCompany.Kod== null ? false :true ) : false
                    };
                    entities.MovieTicketSalePayment.Add(payment);
                }
                entities.SaveChanges();

                var queue = new List<InternalType3>();
                foreach (var type in SellingAction.Types)
                {
                    foreach (var tariff in type.Tariffs.Where(o => o.Count > 0))
                    {
                        for (var i = 0; i < tariff.Count; i++)
                        {
                            queue.Add(new InternalType3 { SeatTypeId = type.SeatType.MovieSeatTypeId, TariffId = tariff.Tariff.MovieTariffId, Amount = tariff.Amount });
                        }
                    }
                }

                //if (SellingAction.Types.Count==0)
                //{
                //    queue.Add(new InternalType3 { SeatTypeId = type.SeatType.MovieSeatTypeId, TariffId = tariff.Tariff.MovieTariffId, Amount = 0 });
                //}

                var array = reservations.ToArray();
                for (var i = 0; i < array.Length; i++)
                {
                    var item = array[i];

                    var rowIndex = entities.MovieTheatrePlaceTemplateDetails.Where(o => o.Id== item.MovieTheatrePlaceTemplateDetailsId).FirstOrDefault().RowIndex;

                    string strBlockName = string.Empty;
                    var aa = item.MovieSession.MovieTheatrePlace.MovieTheatrePlaceTemplate.MovieTheatrePlaceTemplateBlock.Where(o => o.BlockIndex == item.Block).FirstOrDefault();
                    if (aa != null) strBlockName = rowIndex > 6 ? aa.MovieTheaterBlockName.Split('-')[1] : aa.MovieTheaterBlockName.Split('-')[0];
                    //item.MovieSession.MovieTheatrePlace.MovieTheatrePlaceTemplate.MovieTheatrePlaceTemplateBlock.Where(o=>o.)
                    var tariff = queue.First(o => o.SeatTypeId == item.MovieSeatTypeId);
                    var ticket = new MovieTicket
                    {
                        BlockName = strBlockName,
                        MovieTicketSaleId = sale.MovieTicketSaleId,
                        MovieSeatTypeId = item.MovieSeatTypeId,
                        MovieTariffId = tariff.TariffId,
                        SeatPrefix = item.SeatPrefix,
                        SeatSuffix = item.SeatSuffix,
                        SeatCode = item.SeatCode,
                        Amount = reservationAmount == 0? tariff.Amount: reservationAmount ?? 0,
                        TicketOrder = string.Format("{0}/{1}", i + 1, array.Length),
                        BarcodeNumber = StaticClass.GetNewBarcodeId()
                    };
                    if (entities.MovieTariff.Single(o => o.MovieTariffId == tariff.TariffId).CustomerAuthorization && _tagIdList.Any())
                    {
                        ticket.CustomerInfo = _tagIdList[0];
                        _tagIdList.RemoveAt(0);
                    }
                    entities.MovieTicket.Add(ticket);
                    queue.Remove(tariff);
                }

                foreach (var product in products)
                {
                    entities.MovieTicketSaleOption.Add(new MovieTicketSaleOption
                    {
                        MovieTicketSaleId = sale.MovieTicketSaleId,
                        TicketOptionId = product.Product.TicketOptionId,
                        Amount = product.Amount,
                        Count = product.Count,
                        TotalAmount = product.Total
                    });
                }

                entities.SaveChanges();

                TicketPrint.ShowForm(sale.MovieTicketSaleId, _biletTarifeCompany);
                SeatSelection.CloseForm();
                TariffSelection.CloseForm();

            }
        }
        private void ReservationButtonClick(object sender, EventArgs e)
        {
            if (_tagIdList.Count == 0) return;
            var tagId = _tagIdList[0];
            var tagResult = CustomerAuthorizationCheckViewModel.GetForBooking(tagId, _movieSessionId);
            if (tagResult != null)
            {
                if (tagResult.Result)
                {
                    #region
                    string resultPhone, resultName, resultEmail;
                    var result = CustomerInfoForm.GetPrompt(out resultPhone, out resultName, out resultEmail);
                    if (!result) return;
                    using (var entities = new CinemaBookingEntities())
                    {
                        var reservations = entities.GetMyReservations(_movieSessionId);
                        var tolerance = 0;
                        var parameter = entities.SystemParameter.FirstOrDefault(o => o.ParameterName == "MovieSessionBookingTolerance");
                        if (parameter != null) int.TryParse(parameter.ParameterValue, out tolerance);
                        var session = entities.MovieSession.Single(item => item.MovieSessionId == _movieSessionId);

                        var booking = new MovieSessionBooking
                        {
                            ReservationId = StaticClass.GetNewBarcodeId(),
                            CustomerPhone = resultPhone,
                            CustomerName = resultName,
                            CustomerEmail = resultEmail,
                            MovieSessionId = _movieSessionId,
                            BookingTime = entities.GetDate(),
                            ExpirationTime = session.SessionTime.AddMinutes(-1 * tolerance),
                            UserId = LoginUser.LoggedUserId,
                            SessionId = LoginUser.SessionId,
                            MovieTicketSaleId = null
                        };
                        entities.MovieSessionBooking.Add(booking);
                        entities.SaveChanges();

                        var queue = new List<InternalType3>();
                        foreach (var type in SellingAction.Types)
                            foreach (var tariff in type.Tariffs.Where(o => o.Count > 0))
                                for (var i = 0; i < tariff.Count; i++)
                                    queue.Add(new InternalType3 { SeatTypeId = type.SeatType.MovieSeatTypeId, TariffId = tariff.Tariff.MovieTariffId, Amount = tariff.Amount });

                        var array = reservations.ToArray();
                        foreach (var item in array)
                        {
                            var tariff = queue.First(o => o.SeatTypeId == item.MovieSeatTypeId);
                            var bookingDetail = new MovieSessionBookingDetail
                            {
                                BookingId = booking.Id,
                                MovieSeatTypeId = item.MovieSeatTypeId,
                                SeatPrefix = item.SeatPrefix,
                                SeatSuffix = item.SeatSuffix,
                                SeatCode = item.SeatCode,
                                MovieTariffId = tariff.TariffId
                            };
                            if (entities.MovieTariff.Single(o => o.MovieTariffId == tariff.TariffId).CustomerAuthorization && _tagIdList.Any())
                            {
                                bookingDetail.CustomerInfo = _tagIdList[0];
                                _tagIdList.RemoveAt(0);
                            }
                            entities.MovieSessionBookingDetail.Add(bookingDetail);
                            queue.Remove(tariff);
                        }

                        entities.SaveChanges();

                        InfoForm.ShowInfo("Rezervasyon oluşturuldu.");
                        SeatSelection.CloseForm();
                        TariffSelection.CloseForm();
                    }
                    #endregion
                }
                else
                {
                    InfoForm.ShowInfo(tagResult.Description);
                }
            }
            else
            {
                InfoForm.ShowInfo("Bir hata meydana geldi.".ChangeLng());
            }
        }
        private void ReservationCancellationButtonClick(object sender, EventArgs e)
        {
            if (!ConfirmForm.GetConfirm("Rezervasyon iptal edilsin mi?".ChangeLng())) return;
            try
            {
                var cancelled = false;
                using (var entities = new CinemaBookingEntities())
                {
                    var booking = entities.MovieSessionBooking.FirstOrDefault(o => o.Id == _movieSessionBookingId);
                    if (booking != null)
                    {
                        booking.CancellationTime = entities.GetDate();
                        booking.CancellationUserId = LoginUser.LoggedUserId;
                        booking.CancellationSessionId = LoginUser.SessionId;
                        entities.SaveChanges();
                        cancelled = true;
                    }
                }
                if (cancelled)
                {
                    InfoForm.ShowInfo("Rezervasyon iptal edildi.");
                    CloseForm();
                }
            }
            catch (Exception exception)
            {
                InfoForm.ShowInfo(exception.ToString());
            }
        }
        private void POSButtonClick(object sender, EventArgs e)
        {
            try
            {
                _posSerial = new SerialPort("COM1") { BaudRate = 9600 };
                _posSerial.Open();

                var button = (Button)sender;
                button.Enabled = false;

                string command;

                _posSerial.Write(Environment.NewLine);

                if (SellingAction.TotalAmountSeat > 0)
                {
                    command = string.Format("1,{0}" + Environment.NewLine, (int)(SellingAction.TotalAmountSeat * 100));
                    Thread.Sleep(1000);
                    _posSerial.Write(command);
                    Console.Write(command);
                }

                if (SellingAction.TotalAmountOption > 0)
                {
                    command = string.Format("2,{0}" + Environment.NewLine, (int)(SellingAction.TotalAmountOption * 100));
                    Thread.Sleep(1000);
                    _posSerial.Write(command);
                    Console.Write(command);
                }

                button.Enabled = true;
                //UserLog.Add(new
                //{
                //    Application = "Funfair-" + Module.AppType.ToString(),
                //    Operation = "PosAction",
                //    AppType = Module.AppType.ToString(),
                //    Data = commandList
                //});
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                try
                {
                    if (_posSerial != null && _posSerial.IsOpen) _posSerial.Close();
                }
                catch (Exception)
                {
                }
                _posSerial = null;
            }
        }
        private void RefreshPaymentLabels()
        {
            foreach (var type in SellingAction.Payments.Keys)
            {
                var amount = SellingAction.Payments[type];
                var label = PaymentLabels.FirstOrDefault(o => o.Tag == type);
                if (label == null) continue;

                if (_biletTarifeCompany != null && SellingAction.PaymentType!=null)
                {
                    if (!SellingAction.PaymentType.Contains(type.MovieTicketSalePaymentTypeName.ChangeLng())) label.Text = 0.ToString("C");
                    else label.Text = amount.ToString("C");
                } else label.Text = amount.ToString("C");
            }

            if (_buttonPayment != null)
            {

                //if (_biletTarifeCompany != null && SellingAction.PaymentType != null)
                //    SellingAction.TotalChange = 0;
                if (_biletTarifeCompany != null && SellingAction.TotalPayment==0) _buttonPayment.Enabled = false;
                else 
                _buttonPayment.Enabled = SellingAction.TotalChange >= 0;

            }
            if (_buttonReservation != null)
            {
                var noCustomerAuthorizedCount = 0;
                var customerAuthorizedCount = 0;
                foreach (var type in SellingAction.Types)
                {
                    foreach (var tariff in type.Tariffs)
                    {
                        if (tariff.Tariff.CustomerAuthorization) customerAuthorizedCount += tariff.Count;
                        else noCustomerAuthorizedCount += tariff.Count;
                    }
                }
                _buttonReservation.Visible = customerAuthorizedCount == 1 && noCustomerAuthorizedCount == 0;
            }
        }
        private int GetTotalSeatCount()
        {
            var totalSeatCount = 0;
            foreach (var type in SellingAction.Types)
                foreach (var tariff in type.Tariffs)
                    totalSeatCount += tariff.Count;
            return totalSeatCount;
        }

        private class SellingActionClass : INotifyPropertyChanged
        {
            private decimal _totalAmountSeat;
            private decimal _totalAmountOption;
            private decimal _totalAmount;
            private decimal _totalChange;

            public readonly List<InternalType1> Types = new List<InternalType1>();
            public readonly List<InternalType4> Products = new List<InternalType4>();
            public readonly Dictionary<MovieTicketSalePaymentType, decimal> Payments = new Dictionary<MovieTicketSalePaymentType, decimal>();
            public string _paymentType;

            public decimal TotalAmountSeat { get { return _totalAmountSeat; } private set { _totalAmountSeat = value; NotifyPropertyChanged("TotalAmountSeat"); } }
            public decimal TotalAmountOption { get { return _totalAmountOption; } private set { _totalAmountOption = value; NotifyPropertyChanged("TotalAmountOption"); } }
            public decimal TotalAmount { get { return _totalAmount; } private set { _totalAmount = value; NotifyPropertyChanged("TotalAmount"); } }
            public string PaymentType { get { return _paymentType; } set { _paymentType = value; } }
            public decimal TotalPayment { get; set; }
            public decimal TotalChange { get { return _totalChange; } private set { _totalChange = value; NotifyPropertyChanged("TotalChange"); } }
            public decimal TotalAmountOfDefaultPaymentType { get; set; }
            public void UpdatePrices()
            {
                if (reservationAmount == 0)
                    TotalAmountSeat = Types.Sum(o => o.Tariffs.Sum(t => t.Total));
                else
                    TotalAmountSeat = reservationAmount??0;

                TotalAmountOption = Products.Sum(o => o.Total);
                TotalAmount = TotalAmountSeat + TotalAmountOption;
                TotalPayment = Payments.Sum(o => o.Value);
                if (_biletTarifeCompany != null)
                    TotalChange = 0;
                else
                    TotalChange = TotalPayment - TotalAmount;
                TotalAmountOfDefaultPaymentType = TotalAmount - Payments.Where(o => !o.Key.IsDefault).Sum(o => o.Value);
            }

            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private class InternalType1
        {
            public MovieSeatType SeatType { get; set; }
            public List<InternalType2> Tariffs { get; set; }
            public int MustBe { get; set; }
        }
        private class InternalType2 : INotifyPropertyChanged
        {
            private int _count;
            private decimal _amount;
            private decimal _total;

            public InternalType1 Parent { get; set; }
            public MovieTariff Tariff { get; set; }

            public decimal Amount { get { return _amount; } set { _amount = value; NotifyPropertyChanged("Amount"); UpdateTotal(); } }
            public int Count { get { return _count; } set { _count = value; NotifyPropertyChanged("Count"); UpdateTotal(); } }
            public decimal Total { get { return _total; } private set { _total = value; NotifyPropertyChanged("Total"); } }

            private void UpdateTotal() { Total = Amount * _count; }

            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private class InternalType3
        {
            public int SeatTypeId { get; set; }
            public int TariffId { get; set; }
            public decimal Amount { get; set; }
        }
        private class InternalType4 : INotifyPropertyChanged
        {
            private int _count;
            private decimal _amount;
            private decimal _total;

            public MovieTicketOption Product { get; set; }
            public decimal Amount { get { return _amount; } set { _amount = value; NotifyPropertyChanged("Amount"); UpdateTotal(); } }
            public int Count { get { return _count; } set { _count = value; NotifyPropertyChanged("Count"); UpdateTotal(); } }
            public decimal Total { get { return _total; } private set { _total = value; NotifyPropertyChanged("Total"); } }

            private void UpdateTotal() { Total = Amount * _count; }

            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static bool PrinterIsExists(string printerName)
        {
            return PrinterSettings.InstalledPrinters.Cast<string>().Any(printer => printer == printerName);
        }


        private void PrintInternalClass(SellingActionClass item, bool confirm)
        {

            if (!PrinterIsExists(ReceiptPrinterName))
            {
                InfoForm.ShowInfo("Fiş yazıcısı bulunamadı.".ChangeLng());
                return;
            }

            if (string.IsNullOrEmpty(PrinterTemplates.TicketTemplate))
            {
                InfoForm.ShowInfo("Fiş şablonu bulunamadı.".ChangeLng());
                return;
            }

            var source = GetReportSourceFromXml(item, PrinterTemplates.ReceiptTemplate);
            var settings = new PrinterSettings { PrinterName = ReceiptPrinterName };
            CancelAllJobs(settings.PrinterName);
            var mStandardPrintController = new StandardPrintController();
            var processor = new Telerik.Reporting.Processing.ReportProcessor { PrintController = mStandardPrintController };
            processor.PrintReport(source, settings);
        }

        public static void CancelAllJobs(string printerName)
        {
            try
            {
                var classInstance = new ManagementObject("root\\CIMV2", "Win32_Printer.DeviceID='" + printerName + "'", null);
                var outParams = classInstance.InvokeMethod("CancelAllJobs", null, null);
                //}
            }
            catch (ManagementException)
            {
            }
        }

        private static XmlReportSource GetReportSourceFromXml(SellingActionClass item, string data)
        {
            XmlReportSource xmlReportSource = null;
            try
            {
                #region
                xmlReportSource = new XmlReportSource { Xml = data };
                xmlReportSource.Parameters.Add("ISLEMIYAPAN", LoginUser.LoggedUserName);
                xmlReportSource.Parameters.Add("GISE", LoginUser.LoggedUserName);
                xmlReportSource.Parameters.Add("TOPLAMTUTAR", item.TotalAmount.ToString("C"));
                xmlReportSource.Parameters.Add("TOPLAMNAKIT", item.PaymentType.Contains("Kredi Kart") ? 0.ToString("C") : item.TotalPayment.ToString("C"));
                xmlReportSource.Parameters.Add("TOPLAMKART", item.PaymentType.Contains("Kredi Kart") ? item.TotalPayment.ToString("C") : 0.ToString("C"));
                //xmlReportSource.Parameters.Add("TOPLAMKREDILI", item.PaymentType.Contains("Kredili") ? "EVET" : "HAYIR");
                xmlReportSource.Parameters.Add("PARAUSTU", item.TotalChange.ToString("C"));
                #endregion
            }
            catch (Exception)
            {
            }
            return xmlReportSource;
        }


    }
}
