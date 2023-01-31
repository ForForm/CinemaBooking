using System;
using System.Windows.Forms;
using CineBookManager.Models;

namespace CineBookManager.Forms
{
    public partial class MovieCastEditForm : Form
    {
        private readonly MovieCast _movieCast;
        public MovieCastEditForm(MovieCast movieCast) { InitializeComponent(); Owner = Main.Instance; _movieCast = movieCast; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            textBoxName.Text = _movieCast.CastName;
        }
        public static bool ShowForm(MovieCast movieCast)
        {
            return new MovieCastEditForm(movieCast).ShowDialog() == DialogResult.OK;
        }
        private void buttonCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; }
        private void buttonOkay_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "") return;
            _movieCast.CastName = textBoxName.Text;
            DialogResult = DialogResult.OK;
        }
        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) buttonOkay_Click(null, null);
            else if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
