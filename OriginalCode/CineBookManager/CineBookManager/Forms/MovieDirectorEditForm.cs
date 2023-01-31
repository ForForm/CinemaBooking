using System;
using System.Windows.Forms;
using CineBookManager.Models;

namespace CineBookManager.Forms
{
    public partial class MovieDirectorEditForm : Form
    {
        private readonly MovieDirector _movieDirector;
        public MovieDirectorEditForm(MovieDirector movieDirector) { InitializeComponent(); Owner = Main.Instance; _movieDirector = movieDirector; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            textBoxName.Text = _movieDirector.MovieDirectorName;
        }
        public static bool ShowForm(MovieDirector movieDirector)
        {
            return new MovieDirectorEditForm(movieDirector).ShowDialog() == DialogResult.OK;
        }
        private void buttonCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; }
        private void buttonOkay_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "") return;
            _movieDirector.MovieDirectorName = textBoxName.Text;
            DialogResult = DialogResult.OK;
        }
        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) buttonOkay_Click(null, null);
            else if (e.KeyCode == Keys.Escape) Close();
        }
    }
}