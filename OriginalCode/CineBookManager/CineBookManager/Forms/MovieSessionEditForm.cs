using System;
using System.Linq;
using System.Windows.Forms;
using CineBookManager.Models;

namespace CineBookManager.Forms
{
    public partial class MovieSessionEditForm : Form
    {
        private readonly MovieSession _movieSession;
        public MovieSessionEditForm(MovieSession movieSession) { InitializeComponent(); Owner = Main.Instance; _movieSession = movieSession; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            using (var database = CineBookEntitiesExt.New())
            {
                comboBoxTheatrePlace.DataSource = database.MovieTheatrePlace.OrderBy(o => o.MovieTheatrePlaceName).ToList();
            }
            comboBoxTheatrePlace.SelectedValue = _movieSession.MovieTheatrePlaceId;
            timePickerSessionTime.Value = _movieSession.SessionTime;
            timePickerSessionTime.MinDate = _movieSession.SessionTime.Date;
            timePickerSessionTime.MaxDate = _movieSession.SessionTime.Date.AddDays(1).AddMinutes(-1);
            if (comboBoxTheatrePlace.SelectedItem == null) comboBoxTheatrePlace.SelectedIndex = 0;
        }
        public static bool ShowForm(MovieSession movieSession)
        {
            return new MovieSessionEditForm(movieSession).ShowDialog() == DialogResult.OK;
        }
        private void buttonCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; }
        private void buttonOkay_Click(object sender, EventArgs e)
        {
            var movieTheatrePlace = comboBoxTheatrePlace.SelectedItem as MovieTheatrePlace;
            if (movieTheatrePlace == null) return;
            _movieSession.MovieTheatrePlaceId = movieTheatrePlace.MovieTheatrePlaceId;
            _movieSession.SessionTime = timePickerSessionTime.Value;
            DialogResult = DialogResult.OK;
        }
    }
}