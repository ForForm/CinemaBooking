using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using CineBookManager.Models;
using CineBookManager.Classes;

namespace CineBookManager.Forms
{
    public partial class MovieAmountEditForm : Form
    {
        static bool _blSetForm;
        static SeatItem _seatItem;

        private readonly List<TariffAndAmount> _items = new List<TariffAndAmount>();
        private readonly MovieSession _movieSession;
        public MovieAmountEditForm(MovieSession movieSession)
        {
            InitializeComponent(); Owner = Main.Instance; _movieSession = movieSession;

            button4.Visible = false;
            //button5.Visible = false;

            if (_seatItem != null)
            {
                
                button1.Visible = !(_seatItem.Detail.MovieSeatTypeId == 7);
                button2.Visible = !(_seatItem.Detail.MovieSeatTypeId == 7);
                button3.Visible = !(_seatItem.Detail.MovieSeatTypeId == 7);
                button4.Visible = (_seatItem.Detail.MovieSeatTypeId == 7);


                if (_seatItem.Detail.SeatCode == null)
                {
                        var movieTheatrePlaceTemplateDetails = _seatItem.Detail.MovieTheatrePlaceTemplate.MovieTheatrePlaceTemplateDetails.Where(o => o.MovieTheatrePlaceTemplateId == _movieSession.MovieTheatrePlace.MovieTheatrePlaceTemplateId && o.RowIndex == _seatItem.Detail.RowIndex);
                        bool isAllVip = true;
                        foreach (var item2 in movieTheatrePlaceTemplateDetails)
                            if (item2.MovieSeatTypeId != 7 && item2.SeatCode != null) { isAllVip = false; break; }

                        if (isAllVip)
                        {
                            button1.Visible = button2.Visible = button3.Visible = false;
                            button4.Visible = true;
                        }

                    
                }
            }




        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MovieTariffName", Name = "MovieTariffName", HeaderText = StringConsts.Column_Tariff, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, ReadOnly = true });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Amount", Name = "Amount", HeaderText = StringConsts.Column_Amount, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });

            _items.Clear();

            //if (!_blSetForm)
            //{
            //    using (var entities = new CineBookEntities())
            //    {
            //        var movieSessionAmount = entities.MovieSessionAmount.Where(o => o.MovieSessionId == movieSession.MovieSessionId).FirstOrDefault();



            //    }

            //}
            using (var database = CineBookEntitiesExt.New())
            {
                //if (_blSetForm)
                //    foreach (var tariff in database.MovieTariff) _items.Add(new TariffAndAmount { MovieTariffId = tariff.MovieTariffId, MovieTariffName = tariff.MovieTariffName });
                //else
                //{
                foreach (var tariff in database.MovieTariff)
                {
                    if (_seatItem == null)
                    {
                        var movieSessionAmount = database.MovieSessionAmount.Where(o => o.MovieSessionId == _movieSession.MovieSessionId
                  && o.MovieTariffId == tariff.MovieTariffId && o.MovieTheatrePlaceTemplateDetailsId==null).FirstOrDefault();
                        _items.Add(new TariffAndAmount { MovieTariffId = tariff.MovieTariffId, MovieTariffName = tariff.MovieTariffName, Amount = movieSessionAmount == null ? 0 : movieSessionAmount.Amount });
                    }
                    else
                    {
                        if (_seatItem.Detail.MovieSeatType.MovieSeatTypeName == "VIP" || _seatItem.Detail.SeatCode==null)
                        {
                            if (tariff.MovieTariffName == _seatItem.Detail.MovieSeatType.MovieSeatTypeName || tariff.MovieTariffName=="VIP")
                            {
                                var movieSessionAmount = database.MovieSessionAmount.Where(o => o.MovieSessionId == _movieSession.MovieSessionId
                      && o.MovieTariffId == tariff.MovieTariffId && o.MovieSeatTypeId == _seatItem.Detail.MovieSeatTypeId && o.MovieTheatrePlaceTemplateDetailsId == _seatItem.Detail.Id).FirstOrDefault();
                                if (movieSessionAmount == null) // VIP custom fiyat atanmadıysa default....
                                {
                                    movieSessionAmount = database.MovieSessionAmount.Where(o => o.MovieSessionId == _movieSession.MovieSessionId
                      && o.MovieTariffId == tariff.MovieTariffId && o.MovieSeatTypeId == _seatItem.Detail.MovieSeatTypeId && o.MovieTheatrePlaceTemplateDetailsId == null).FirstOrDefault();
                                    _items.Add(new TariffAndAmount { MovieTariffId = tariff.MovieTariffId, MovieTariffName = tariff.MovieTariffName, Amount = movieSessionAmount == null ? 0 : movieSessionAmount.Amount });
                                }
                                else // VIP custom fiyat ....
                                    _items.Add(new TariffAndAmount { MovieTariffId = tariff.MovieTariffId, MovieTariffName = tariff.MovieTariffName, Amount = movieSessionAmount == null ? 0 : movieSessionAmount.Amount });
                                break;
                            }
                        }
                        else
                        {
                            var movieSessionAmount = database.MovieSessionAmount.Where(o => o.MovieSessionId == _movieSession.MovieSessionId
                      && o.MovieTariffId == tariff.MovieTariffId && o.MovieSeatTypeId == _seatItem.Detail.MovieSeatTypeId).FirstOrDefault();
                            if (tariff.MovieTariffName != "VIP")
                                _items.Add(new TariffAndAmount { MovieTariffId = tariff.MovieTariffId, MovieTariffName = tariff.MovieTariffName, Amount = movieSessionAmount == null ? 0 : movieSessionAmount.Amount });
                        }
                    }

                }
                //}

            }
            dataGridView.AutoGenerateColumns = false;
            dataGridView.DataSource = _items;

            using (var database = CineBookEntitiesExt.New())
            {
                var _session = database.MovieSession.Single(o => o.MovieSessionId == _movieSession.MovieSessionId);
                button2.Text += string.Format(" ({0})", database.MovieSession.Count(o => o.MovieId == _session.MovieId && DbFunctions.TruncateTime(o.SessionTime) == DbFunctions.TruncateTime(_session.SessionTime)));
                button3.Text += string.Format(" ({0})", database.MovieSession.Count(o => DbFunctions.TruncateTime(o.SessionTime) == DbFunctions.TruncateTime(_session.SessionTime)));
            }

        }
        public static bool ShowForm(MovieSession movieSession, bool blSetForm, SeatItem seatItem)
        {
            _blSetForm = blSetForm;
            _seatItem = seatItem;
            return new MovieAmountEditForm(movieSession).ShowDialog() == DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var items = _items.Where(o => o.Amount != null).ToArray();
                if (!items.Any()) { StaticClass.ShowWarning(StringConsts.Thereisnovalueforsave); return; }
                using (var database = CineBookEntitiesExt.New())
                {
                    var session = database.MovieSession.Single(o => o.MovieSessionId == _movieSession.MovieSessionId);
                    var seatTypes = database.MovieSeatType.Where(o => o.Salable).ToArray();
                    foreach (var amount in database.MovieSessionAmount.Where(o => o.MovieSessionId == _movieSession.MovieSessionId && o.MovieTheatrePlaceTemplateDetailsId==null)) database.MovieSessionAmount.Remove(amount);
                    foreach (var item in items)
                        foreach (var seatType in seatTypes)
                            session.MovieSessionAmount.Add(new MovieSessionAmount { MovieSessionId = session.MovieSessionId, MovieTariffId = item.MovieTariffId, MovieSeatTypeId = seatType.MovieSeatTypeId, Amount = (decimal)item.Amount });
                    database.SaveChanges();
                }
                StaticClass.ShowInfo(StringConsts.MessageBox_Operationsuccessful);
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
                var items = _items.Where(o => o.Amount != null).ToArray();
                if (!items.Any()) { StaticClass.ShowWarning(StringConsts.Thereisnovalueforsave); return; }
                using (var database = CineBookEntitiesExt.New())
                {
                    var sessionIdList = database.MovieSession.Where(o => o.MovieId == _movieSession.MovieId && DbFunctions.TruncateTime(o.SessionTime) == DbFunctions.TruncateTime(_movieSession.SessionTime)).Select(o => o.MovieSessionId).Distinct().ToArray();
                    var sessions = database.MovieSession.Where(o => sessionIdList.Contains(o.MovieSessionId)).ToArray();
                    var seatTypes = database.MovieSeatType.Where(o => o.Salable).ToArray();
                    foreach (var session in sessions)
                    {
                        foreach (var amount in database.MovieSessionAmount.Where(o => o.MovieSessionId == session.MovieSessionId)) database.MovieSessionAmount.Remove(amount);
                        foreach (var item in items)
                            foreach (var seatType in seatTypes)
                                session.MovieSessionAmount.Add(new MovieSessionAmount { MovieSessionId = session.MovieSessionId, MovieTariffId = item.MovieTariffId, MovieSeatTypeId = seatType.MovieSeatTypeId, Amount = (decimal)item.Amount });
                    }
                    database.SaveChanges();
                }
                StaticClass.ShowInfo(StringConsts.MessageBox_Operationsuccessful);
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var items = _items.Where(o => o.Amount != null).ToArray();
                if (!items.Any()) { StaticClass.ShowWarning(StringConsts.Thereisnovalueforsave); return; }
                using (var database = CineBookEntitiesExt.New())
                {
                    var sessionIdList = database.MovieSession.Where(o => DbFunctions.TruncateTime(o.SessionTime) == DbFunctions.TruncateTime(_movieSession.SessionTime)).Select(o => o.MovieSessionId).Distinct().ToArray();
                    var sessions = database.MovieSession.Where(o => sessionIdList.Contains(o.MovieSessionId)).ToArray();
                    var seatTypes = database.MovieSeatType.Where(o => o.Salable).ToArray();
                    foreach (var session in sessions)
                    {
                        foreach (var amount in database.MovieSessionAmount.Where(o => o.MovieSessionId == session.MovieSessionId)) database.MovieSessionAmount.Remove(amount);
                        foreach (var item in items)
                            foreach (var seatType in seatTypes)
                                session.MovieSessionAmount.Add(new MovieSessionAmount { MovieSessionId = session.MovieSessionId, MovieTariffId = item.MovieTariffId, MovieSeatTypeId = seatType.MovieSeatTypeId, Amount = (decimal)item.Amount });
                    }
                    database.SaveChanges();
                }
                StaticClass.ShowInfo(StringConsts.MessageBox_Operationsuccessful);
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }

        public class TariffAndAmount
        {
            public int MovieTariffId { get; set; }
            public string MovieTariffName { get; set; }
            public decimal? Amount { get; set; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var entities = CineBookEntitiesExt.New())
            {
                if (_seatItem.Detail.SeatCode == null)
                {
                    var movieTheatrePlaceTemplateDetails = entities.MovieTheatrePlaceTemplateDetails.Where(o => o.MovieTheatrePlaceTemplateId == _movieSession.MovieTheatrePlace.MovieTheatrePlaceTemplateId && o.RowIndex == _seatItem.Detail.RowIndex);

                    foreach (var mitem in movieTheatrePlaceTemplateDetails)
                    {
                        if (mitem.SeatCode == null) continue;
                        var movieSessionAmount = entities.MovieSessionAmount.Where(o => o.MovieSessionId == _movieSession.MovieSessionId && o.MovieTariffId == 7 && o.MovieSeatTypeId == mitem.MovieSeatTypeId && o.MovieTheatrePlaceTemplateDetailsId == mitem.Id).FirstOrDefault();

                        if (movieSessionAmount != null)
                            foreach (var item in _items)
                            {
                                if (item.MovieTariffId == mitem.MovieSeatTypeId)
                                {
                                    movieSessionAmount.Amount = item.Amount ?? 0;
                                    movieSessionAmount.MovieTheatrePlaceTemplateDetailsId = mitem.Id;
                                }
                            }
                        else
                        {
                            foreach (var item in _items)
                            {
                                entities.MovieSessionAmount.Add(new MovieSessionAmount { MovieSessionId = _movieSession.MovieSessionId, MovieTariffId = item.MovieTariffId, MovieSeatTypeId = mitem.MovieSeatTypeId, Amount = (decimal)item.Amount,
                                    MovieTheatrePlaceTemplateDetailsId = mitem.Id });
                            }
                        }


                    }




                }
                else
                {
                    var movieSessionAmount = entities.MovieSessionAmount.Where(o => o.MovieSessionId == _movieSession.MovieSessionId && o.MovieTariffId == 7 && o.MovieSeatTypeId == _seatItem.Detail.MovieSeatTypeId && o.MovieTheatrePlaceTemplateDetailsId == _seatItem.Detail.Id).FirstOrDefault();
                    //var aa = placeTemplate.MovieTheatrePlaceTemplateDetails.Where(o => o.Id == _seatItem.Detail.Id).FirstOrDefault();
                    if (movieSessionAmount != null)
                        foreach (var item in _items)
                        {
                            if (item.MovieTariffName == _seatItem.Detail.MovieSeatType.MovieSeatTypeName)
                            {
                                movieSessionAmount.Amount = item.Amount ?? 0;
                                movieSessionAmount.MovieTheatrePlaceTemplateDetailsId = _seatItem.Detail.Id;
                            }
                        }
                    else
                    {
                        foreach (var item in _items)
                        {
                            entities.MovieSessionAmount.Add(new MovieSessionAmount { MovieSessionId = _movieSession.MovieSessionId, MovieTariffId = item.MovieTariffId, MovieSeatTypeId = _seatItem.Detail.MovieSeatTypeId, Amount = (decimal)item.Amount, MovieTheatrePlaceTemplateDetailsId = _seatItem.Detail.Id });
                        }
                    }
                }


                entities.SaveChanges();
            }
        }

       
    }
}
