using System;
using System.Windows.Forms;
using CineBookManager.Models;

namespace CineBookManager.Forms
{
    public partial class MovieTypeEditForm : Form
    {
        private readonly MovieType _movieType;
        public MovieTypeEditForm(MovieType movieType) { InitializeComponent(); Owner = Main.Instance; _movieType = movieType; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            textBoxName.Text = _movieType.MovieTypeName;
        }
        public static bool ShowForm(MovieType movieType)
        {
            return new MovieTypeEditForm(movieType).ShowDialog() == DialogResult.OK;
        }
        private void buttonCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; }
        private void buttonOkay_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "") return;
            _movieType.MovieTypeName = textBoxName.Text;
            DialogResult = DialogResult.OK;
        }
        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) buttonOkay_Click(null, null);
            else if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
