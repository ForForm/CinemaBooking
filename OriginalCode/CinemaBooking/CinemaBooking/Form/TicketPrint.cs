using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CinemaBooking.Class;
using Telerik.Reporting;

namespace CinemaBooking
{
    public partial class TicketPrint : Form
    {
        private const string TicketPrinterName = "Bilet Yazıcı";
        //private const string ReceiptPrinterName = "Fiş Yazıcı";

        private List<InternalClass> _items = new List<InternalClass>();
        public int MovieTicketSaleId;
        public static TicketPrint Instance;
        public static BiletTarifeSale _biletTarifeCompany;
        public TicketPrint(int movieTicketSaleId, BiletTarifeSale biletTarifeCompany)
        {
            InitializeComponent();
            Instance = this;
            Owner = MainForm.Instance;
            Location = Owner.Location;
            Size = Owner.Size;
            WindowState = Owner.WindowState;

            CheckForIllegalCrossThreadCalls = false;
            MovieTicketSaleId = movieTicketSaleId;
            _biletTarifeCompany = biletTarifeCompany;
        }
        protected override void OnLoad(EventArgs e) { base.OnLoad(e); RefreshGrid(); }
        protected override void OnClosed(EventArgs e) { base.OnClosed(e); Instance = null; }
        public static void ShowForm(int movieTicketSaleId, BiletTarifeSale biletTarifeCompany)
        {
            if (Instance == null) Instance = new TicketPrint(movieTicketSaleId, biletTarifeCompany);
            Instance.Show();
            Instance.BringToFront();
        }
        public static void CloseForm() { Instance?.Close(); }
        private void RefreshGrid()
        {
            _items = new List<InternalClass>();
            using (var entities = new CinemaBookingEntities())
            {
                var sale = entities.MovieTicketSale.First(o => o.MovieTicketSaleId == MovieTicketSaleId);
                var session = entities.MovieSession.First(o => o.MovieSessionId == sale.MovieSessionId);
                labelTitle.Text = session.Movie.Title;
                labelPlace.Text = session.MovieTheatrePlace.MovieTheatrePlaceName;
                labelTime.Text = session.SessionTime.ToString("HH:mm");

                var tickets = entities.MovieTicket.Where(o => o.MovieTicketSaleId == MovieTicketSaleId);
                foreach (var ticket in tickets)
                {
                    _items.Add(new InternalClass()
                    {
                        SeatType = ticket.MovieSeatType.MovieSeatTypeName,
                        Tariff = ticket.MovieTariff.MovieTariffName,
                        BlockName =  ticket.BlockName,
                        SeatCode = ticket.SeatCode,
                        Amount = ticket.Amount,
                        IsPrinted = ticket.IsPrinted,
                        Tag = ticket
                    });
                }
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _items;
        }
        private class InternalClass
        {
            public string SeatType { get; set; }
            public string Tariff { get; set; }
            public string BlockName { get; set; }
            public string SeatCode { get; set; }
            public decimal Amount { get; set; }
            public bool IsPrinted { get; set; }
            public MovieTicket Tag { get; set; }
            public string Status => IsPrinted ? "Yazdırıldı" : "Bekliyor";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridViewColumn = dataGridView1.Columns["Print"];
            if (e.ColumnIndex != dataGridViewColumn?.Index || e.RowIndex == -1) return;
            var item = dataGridView1.Rows[e.RowIndex].DataBoundItem as InternalClass;
            if (item == null) return;
            PrintInternalClass(item, true);
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            foreach (var item in _items) PrintInternalClass(item, false);
            if (!ConfirmForm.GetConfirm("Tüm biletler yazdırıldı mı?".ChangeLng()))
            {
                //try
                //{
                //    using (var entities = new CinemaBookingEntities())
                //    {
                //        var booking = entities.MovieSessionBooking.FirstOrDefault(o => o.MovieTicketSaleId == MovieTicketSaleId);
                //        if (booking != null) booking.MovieTicketSaleId = null;
                //        foreach (var item in entities.MovieTicketSalePayment.Where(o => o.MovieTicketSaleId == MovieTicketSaleId)) entities.MovieTicketSalePayment.Remove(item);
                //        foreach (var item in entities.MovieTicketSaleOption.Where(o => o.MovieTicketSaleId == MovieTicketSaleId)) entities.MovieTicketSaleOption.Remove(item);
                //        foreach (var item in entities.MovieTicket.Where(o => o.MovieTicketSaleId == MovieTicketSaleId)) entities.MovieTicket.Remove(item);
                //        foreach (var item in entities.MovieTicketSale.Where(o => o.MovieTicketSaleId == MovieTicketSaleId)) entities.MovieTicketSale.Remove(item);
                //        entities.SaveChanges();
                  
                //    }
                //}
                //catch 
                //{}
                return;
            }

            DateTime date = new DateTime();
            using (var entities = new CinemaBookingEntities())
            {
                date = entities.GetDate();
                foreach (var item in _items)
                {
                    var ticket = entities.MovieTicket.First(o => o.MovieTicketId == item.Tag.MovieTicketId);
                    ticket.IsPrinted = true;
                    ticket.PrintDate = date;
                }
                entities.SaveChanges();

                //if (entities.MovieTicketSalePayment.Any(o => o.MovieTicketSaleId == MovieTicketSaleId))
                //    strKod = entities.MovieTicketSalePayment.First(o => o.MovieTicketSaleId == MovieTicketSaleId).Kod;

                if (!entities.MovieTicket.Any(o => o.MovieTicketSaleId == MovieTicketSaleId && !o.IsPrinted))
                {
                    var sale = entities.MovieTicketSale.First(o => o.MovieTicketSaleId == MovieTicketSaleId);
                    sale.Completed = true;
                    entities.SaveChanges();


                    try
                    {
                        var movieSessionBooking = entities.MovieSessionBooking.Where(o => o.MovieTicketSaleId == sale.MovieTicketSaleId).FirstOrDefault();

                        if (movieSessionBooking!=null)
                        {
                            var detailId = entities.MovieSessionBookingDetail.Where(p => p.BookingId == movieSessionBooking.Id).FirstOrDefault().Id;
                            var movieBookingSerialReservation = entities.MovieBookingSerialReservation.Where(o => o.MovieSessionBookingDetailId== detailId).FirstOrDefault();
                            movieBookingSerialReservation.Used = true;
                        }

                    }
                    catch { }

                    try
                    {

                        var salePayment = entities.MovieTicketSalePayment.First(o => o.MovieTicketSaleId == MovieTicketSaleId);
                        if (_biletTarifeCompany != null)
                        {
                            using (var fentities = new FFSaleEntities())
                            {

                                if (_biletTarifeCompany.Kod != null)
                                {
                                    var fsale = fentities.BiletKotaKod.First(o => o.Kod == _biletTarifeCompany.Kod);
                                    fsale.Kullanildi = true;
                                    fsale.KullanilmaTarihi = date;
                                    fentities.SaveChanges();
                                }
                                else
                                {

                                    string strKod = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();

                                    var item = new BiletKotaKod
                                    {
                                        KotaId = _biletTarifeCompany.KotaId ?? 0, //kotaId,
                                        Kod = strKod,
                                        KullaniciId = LoginUser.LoggedUserId,
                                        OlusturmaTarihi = DateTime.Now,
                                        KullanilmaTarihi = DateTime.Now,
                                        Kullanildi = true
                                    };
                                    salePayment.Kod = strKod;
                                    fentities.BiletKotaKod.Add(item);
                                    fentities.SaveChanges();
                                }
                            }
                        }

                    }
                    catch (Exception){
                    }
                    

                    
                    entities.SaveChanges();


                    InfoForm.ShowInfo("Satış işlemi tamamlandı.".ChangeLng());
                    CloseForm();
                }
            }

            //if (_biletTarifeCompany != null)
            //{
            //    using (var entities = new FFSaleEntities())
            //    {
            //        if (_biletTarifeCompany.Kod != null)
            //        {
            //            var sale = entities.BiletKotaKod.First(o => o.Kod == strKod);
            //            sale.Kullanildi = true;
            //            sale.KullanilmaTarihi = date;
            //            entities.SaveChanges();
            //        }
            //        else
            //        {
            //          var item = new KartKotaKod
            //            {
            //                KotaId = kotaId,
            //                Kod = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper(),
            //                KullaniciId = userId,
            //                OlusturmaTarihi = DateTime.Now
            //            };
            //            entities.KartKotaKod.Add(item);
            //        }
            //    }

            //}
            RefreshGrid();
        }
        private void PrintInternalClass(InternalClass item, bool confirm)
        {
            if (!PrinterIsExists(TicketPrinterName))
            {
                InfoForm.ShowInfo("Bilet yazıcısı bulunamadı.".ChangeLng());
                return;
            }
            if (string.IsNullOrEmpty(PrinterTemplates.TicketTemplate))
            {
                InfoForm.ShowInfo("Bilet şablonu bulunamadı.".ChangeLng());
                return;
            }

            DateTime date = new DateTime();
            using (var entities = new CinemaBookingEntities())
            {
                date= entities.GetDate();
                var ticket = entities.MovieTicket.First(o => o.MovieTicketId == item.Tag.MovieTicketId);
                PrinterTemplates.RefreshTemplates(ticket);
                var source = GetReportSourceFromXml(ticket, PrinterTemplates.TicketTemplate);
                var settings = new PrinterSettings { PrinterName = TicketPrinterName };
                CancelAllJobs(settings.PrinterName);
                var mStandardPrintController = new StandardPrintController();
                var processor = new Telerik.Reporting.Processing.ReportProcessor { PrintController = mStandardPrintController };
                processor.PrintReport(source, settings);
                if (confirm)
                {
                    if (ConfirmForm.GetConfirm(ticket.BarcodeNumber + " barkodlu bilet yazdırıldı mı?".ChangeLng()))
                    {
                        ticket.IsPrinted = true;
                        ticket.PrintDate = date;
                        entities.SaveChanges();
                        if (!entities.MovieTicket.Any(o => o.MovieTicketSaleId == MovieTicketSaleId && !o.IsPrinted))
                        {
                            var sale = entities.MovieTicketSale.First(o => o.MovieTicketSaleId == MovieTicketSaleId);
                            sale.Completed = true;

                            var salePayment = entities.MovieTicketSalePayment.First(o => o.MovieTicketSaleId == MovieTicketSaleId);

                            if (_biletTarifeCompany != null)
                            {
                                using (var fentities = new FFSaleEntities())
                                {

                                    if (_biletTarifeCompany.Kod != null)
                                    {
                                        var fsale = fentities.BiletKotaKod.First(o => o.Kod == _biletTarifeCompany.Kod);
                                        fsale.Kullanildi = true;
                                        fsale.KullanilmaTarihi = date;
                                        fentities.SaveChanges();
                                    }
                                    else
                                    {
                                        string strKod = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
                                        var sitem = new BiletKotaKod
                                        {
                                            KotaId = _biletTarifeCompany.KotaId ?? 0, 
                                            Kod = strKod,
                                            KullaniciId = LoginUser.LoggedUserId,
                                            OlusturmaTarihi = DateTime.Now,
                                            KullanilmaTarihi = DateTime.Now,
                                            Kullanildi = true
                                        };

                                        salePayment.Kod = strKod;
                                        fentities.BiletKotaKod.Add(sitem);
                                        fentities.SaveChanges();
                                    }
                                }


                            }

                            entities.SaveChanges();

                            InfoForm.ShowInfo("Satış işlemi tamamlandı.".ChangeLng());
                            CloseForm();
                        }
                    }
                }
            }
            if (confirm) RefreshGrid();
        }

        public static void CancelAllJobs(string printerName)
        {
            try
            {
                //if (LocalPrintServer.GetDefaultPrintQueue().NumberOfJobs > 0)
                //{
                //var settings = new PrinterSettings();
                //var DefaultPrinterName = settings.PrinterName;
                var classInstance = new ManagementObject("root\\CIMV2", "Win32_Printer.DeviceID='" + printerName + "'", null);
                var outParams = classInstance.InvokeMethod("CancelAllJobs", null, null);
                //}
            }
            catch (ManagementException)
            {
            }
        }
        public static bool PrinterIsExists(string printerName)
        {
            return PrinterSettings.InstalledPrinters.Cast<string>().Any(printer => printer == printerName);
            //var result = false;
            //foreach (string printer in PrinterSettings.InstalledPrinters)
            //{
            //    if (printer == printerName) { result = true; break; }
            //}
            //return result;
        }
        private static XmlReportSource GetReportSourceFromXml(MovieTicket ticket, string data)
        {
            XmlReportSource xmlReportSource = null;
            try
            {
                #region
                xmlReportSource = new XmlReportSource { Xml = data };
                if (Regex.IsMatch(xmlReportSource.Xml, "<Report .*?(.*?)>", RegexOptions.Multiline))
                { // Set ReportName Value
                    foreach (Match mMatch in Regex.Matches(xmlReportSource.Xml, "<Report .*?(.*?)>", RegexOptions.Multiline))
                    {
                        if (mMatch.Success)
                        {
                            var mMatchValue = mMatch.Value;
                            var newMatchValue = Regex.Replace(mMatchValue, @"(?<=\bName="")[^""]*", ticket.BarcodeNumber);
                            xmlReportSource.Xml = xmlReportSource.Xml.Replace(mMatchValue, newMatchValue);
                        }
                    }
                }
                #endregion
                #region

                xmlReportSource.Parameters.Add("Title", ticket.MovieTicketSale.MovieSession.Movie.Title);
                xmlReportSource.Parameters.Add("Description", ticket.MovieTicketSale.MovieSession.Movie.Description);
                xmlReportSource.Parameters.Add("Duration", ticket.MovieTicketSale.MovieSession.Movie.Duration);
                xmlReportSource.Parameters.Add("TheatrePlaceName", ticket.MovieTicketSale.MovieSession.MovieTheatrePlace.MovieTheatrePlaceName);
                xmlReportSource.Parameters.Add("SessionTime", ticket.MovieTicketSale.MovieSession.SessionTime);
                xmlReportSource.Parameters.Add("SeatTypeName", ticket.MovieSeatType.MovieSeatTypeName);
                xmlReportSource.Parameters.Add("BlockName", ticket.BlockName);
                xmlReportSource.Parameters.Add("SeatPrefix", ticket.SeatPrefix);
                xmlReportSource.Parameters.Add("SeatSuffix", ticket.SeatSuffix);
                xmlReportSource.Parameters.Add("SeatCode", ticket.SeatCode);
                xmlReportSource.Parameters.Add("BarcodeNumber", ticket.BarcodeNumber);
                xmlReportSource.Parameters.Add("Amount", ticket.Amount.ToString("C"));
                xmlReportSource.Parameters.Add("TariffName", ticket.MovieTariff.MovieTariffName);
                xmlReportSource.Parameters.Add("UserCode", LoginUser.LoggedUserCode);
                //source.Parameters.Add("PrintDate", "Title");
                xmlReportSource.Parameters.Add("TicketId", ticket.MovieTicketId);
                xmlReportSource.Parameters.Add("TicketOrder", ticket.TicketOrder);
                foreach (var item in xmlReportSource.Parameters) if (item.Value != null && item.Value.Equals("-")) item.Value = "";

                #endregion
            }
            catch (Exception)
            {
            }
            return xmlReportSource;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (ConfirmForm.GetConfirm("Satış işlemi iptal edilsin mi?".ChangeLng()))
            {
                using (var entities = new CinemaBookingEntities())
                {
                    var booking = entities.MovieSessionBooking.FirstOrDefault(o => o.MovieTicketSaleId == MovieTicketSaleId);
                    if (booking != null) booking.MovieTicketSaleId = null;
                    foreach (var item in entities.MovieTicketSalePayment.Where(o => o.MovieTicketSaleId == MovieTicketSaleId)) entities.MovieTicketSalePayment.Remove(item);
                    foreach (var item in entities.MovieTicketSaleOption.Where(o => o.MovieTicketSaleId == MovieTicketSaleId)) entities.MovieTicketSaleOption.Remove(item);
                    foreach (var item in entities.MovieTicket.Where(o => o.MovieTicketSaleId == MovieTicketSaleId)) entities.MovieTicket.Remove(item);
                    foreach (var item in entities.MovieTicketSale.Where(o => o.MovieTicketSaleId == MovieTicketSaleId)) entities.MovieTicketSale.Remove(item);
                    entities.SaveChanges();
                    InfoForm.ShowInfo("İptal işlemi tamamlandı.".ChangeLng());
                    CloseForm();
                }
            }
        }
    }
}
