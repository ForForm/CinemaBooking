using System;
using System.Windows.Forms;
using CineBookManager.Models;

namespace CineBookManager.Forms
{
    public partial class MovieFormatEditForm : Form
    {
        private readonly MovieFormat _movieFormat;
        public MovieFormatEditForm(MovieFormat movieFormat) { InitializeComponent(); Owner = Main.Instance; _movieFormat = movieFormat; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            textBoxCode.Text = _movieFormat.MovieFormatCode;
            textBoxName.Text = _movieFormat.MovieFormatName;
        }
        public static bool ShowForm(MovieFormat movieFormat)
        {
            return new MovieFormatEditForm(movieFormat).ShowDialog() == DialogResult.OK;
        }
        private void buttonCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; }
        private void buttonOkay_Click(object sender, EventArgs e)
        {
            if (textBoxCode.Text == "") { textBoxCode.Focus(); return; }
            if (textBoxName.Text == "") { textBoxName.Focus(); return; }
            _movieFormat.MovieFormatCode = textBoxCode.Text;
            _movieFormat.MovieFormatName = textBoxName.Text;
            DialogResult = DialogResult.OK;
        }
        private void textBoxCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) textBoxName.Focus();
            else if (e.KeyCode == Keys.Escape) Close();
        }
        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) buttonOkay_Click(null, null);
            else if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
