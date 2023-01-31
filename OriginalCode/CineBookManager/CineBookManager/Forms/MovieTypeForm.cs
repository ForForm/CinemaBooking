using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using CineBookManager.Classes;
using CineBookManager.Models;

namespace CineBookManager.Forms
{
    public partial class MovieTypeForm : Form
    {
        private readonly BindingList<MovieType> _items = new BindingList<MovieType>();
        private MovieType SelectedItem { get { MovieType item = null; if (dataGridView.SelectedRows.Count > 0) item = dataGridView.SelectedRows[0].DataBoundItem as MovieType; return item; } }

        public static MovieTypeForm Instance;
        public MovieTypeForm() { InitializeComponent(); Instance = this; Instance.MdiParent = Main.Instance; }
        protected override void OnClosed(EventArgs e) { Instance = null; base.OnClosed(e); }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GridInit();
            RefrehsItems();
        }
        public static void ShowForm()
        {
            if (Instance == null) Instance = new MovieTypeForm();
            Instance.WindowState = FormWindowState.Maximized;
            Instance.Show();
        }
        public static void CloseForm()
        {
            Instance?.Close();
        }
        private void GridInit()
        {
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "MovieTypeId", Name = "MovieTypeId", HeaderText = "Movie Type Id", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "MovieTypeName", Name = "MovieTypeName", HeaderText = "Movie Type Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dataGridView.AutoGenerateColumns = false;
            dataGridView.DataSource = _items;
        }
        private void RefrehsItems(int? selectedId = null)
        {
            try
            {
                _items.Clear();
                using (var database = CineBookEntitiesExt.New())
                {
                    if (textBoxSearch.Text == "")
                        foreach (var item in database.MovieType.ToList().OrderBy(o => o.MovieTypeName)) _items.Add(item);
                    else
                        foreach (var item in database.MovieType.Where(o => o.MovieTypeName.Contains(textBoxSearch.Text)).ToList().OrderBy(o => o.MovieTypeName)) _items.Add(item);
                }
                if (selectedId != null)
                {
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        var item = row.DataBoundItem as MovieType;
                        if (item != null && item.MovieTypeId == selectedId)
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void ClearFields()
        {
            textBoxName.Text = "";
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
            ClearFields();
            textBoxName.Focus();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var database = CineBookEntitiesExt.New())
                {
                    MovieType entity;
                    if (SelectedItem == null)
                    {
                        entity = new MovieType();
                        entity.MovieTypeName = textBoxName.Text;
                        database.MovieType.Add(entity);
                    }
                    else
                    {
                        entity = database.MovieType.Single(o => o.MovieTypeId == SelectedItem.MovieTypeId);
                        entity.MovieTypeName = textBoxName.Text;
                    }
                    database.SaveChanges();
                    RefrehsItems(entity.MovieTypeId);
                    StaticClass.ShowInfo("Operation successful.");
                }
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (SelectedItem == null) return;
            try
            {
                if (!StaticClass.ShowQuestion("Are you sure?")) return;
                using (var database = CineBookEntitiesExt.New())
                {
                    var entity = database.MovieType.Include(o => o.Movie_MovieType).Single(o => o.MovieTypeId == SelectedItem.MovieTypeId);
                    if (entity.Movie_MovieType.Count > 0) { StaticClass.ShowWarning("This record is being used by another record.\nYou cannot delete this record."); return; }
                    database.MovieType.Remove(entity);
                    database.SaveChanges();
                    RefrehsItems();
                    StaticClass.ShowInfo("Operation successful.");
                }
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefrehsItems();
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            RefrehsItems();
        }
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var item = SelectedItem;
            if (item != null)
            {
                textBoxName.Text = item.MovieTypeName;
            }
        }   

    }
}
