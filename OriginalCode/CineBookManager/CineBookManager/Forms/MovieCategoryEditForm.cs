using System;
using System.Windows.Forms;
using CineBookManager.Classes;
using CineBookManager.Models;
using System.IO;

namespace CineBookManager.Forms
{
    public partial class MovieCategoryEditForm : Form
    {
        private readonly MovieCategory _movieCategory;
        public MovieCategoryEditForm(MovieCategory movieCategory) { InitializeComponent(); Owner = Main.Instance; _movieCategory = movieCategory; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            textBoxCode.Text = _movieCategory.MovieCategoryCode;
            textBoxName.Text = _movieCategory.MovieCategoryName;
            pictureBoxIcon.Image = _movieCategory.MovieCategoryImage.ToImage();
        }
        public static bool ShowForm(MovieCategory movieCategory)
        {
            return new MovieCategoryEditForm(movieCategory).ShowDialog() == DialogResult.OK;
        }
        private void buttonCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; }
        private void buttonOkay_Click(object sender, EventArgs e)
        {
            if (textBoxCode.Text == "") { textBoxCode.Focus(); return; }
            if (textBoxName.Text == "") { textBoxName.Focus(); return; }
            _movieCategory.MovieCategoryCode = textBoxCode.Text;
            _movieCategory.MovieCategoryName = textBoxName.Text;
            _movieCategory.MovieCategoryImage = pictureBoxIcon.Image.ToByteArray();
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
        private void buttonChangeIcon_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog { Filter = @"*.png|*.png" };
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                pictureBoxIcon.Image = File.ReadAllBytes(openFileDialog.FileName).ToImage();
            }
        }
    }
}
