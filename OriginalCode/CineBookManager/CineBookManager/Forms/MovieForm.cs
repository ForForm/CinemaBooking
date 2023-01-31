using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CineBookManager.Classes;
using CineBookManager.Models;
using System.IO;
using Telerik.Reporting;
using System.Collections.Generic;

namespace CineBookManager.Forms
{

    public partial class MovieForm : Form
    {
        #region Head

        public SeatItem _seatItem;
        MovieTheatrePlaceTemplateBlock[] blockArray;
        private readonly BindingList<Movie> _movieList = new BindingList<Movie>();
        private readonly BindingList<MovieType> _movieTypeListLeft = new BindingList<MovieType>();
        private readonly BindingList<MovieType> _movieTypeListRight = new BindingList<MovieType>();
        private readonly BindingList<MovieFormat> _movieFormatListLeft = new BindingList<MovieFormat>();
        private readonly BindingList<MovieFormat> _movieFormatListRight = new BindingList<MovieFormat>();
        private readonly BindingList<MovieDirector> _movieDirectorListLeft = new BindingList<MovieDirector>();
        private readonly BindingList<MovieDirector> _movieDirectorListRight = new BindingList<MovieDirector>();
        private readonly BindingList<MovieCast> _movieCastListLeft = new BindingList<MovieCast>();
        private readonly BindingList<MovieCast> _movieCastListRight = new BindingList<MovieCast>();
        private readonly BindingList<MovieCategory> _movieCategoryListLeft = new BindingList<MovieCategory>();
        private readonly BindingList<MovieCategory> _movieCategoryListRight = new BindingList<MovieCategory>();
        private readonly BindingList<MovieSession> _movieSessionList = new BindingList<MovieSession>();
        private readonly BindingList<MovieFormat> _movieSessionMovieFormatListLeft = new BindingList<MovieFormat>();
        private readonly BindingList<MovieFormat> _movieSessionMovieFormatListRight = new BindingList<MovieFormat>();
        private readonly BindingList<MovieTheatrePlace> _movieTheatrePlace = new BindingList<MovieTheatrePlace>();
        private readonly BindingList<MovieTheatrePlaceTemplate> _movieTheatrePlaceTemplate = new BindingList<MovieTheatrePlaceTemplate>();
        private readonly BindingList<User> _userList = new BindingList<User>();
        private Movie SelectedMovie { get { Movie item = null; if (dataGridViewMovie.SelectedRows.Count > 0) item = dataGridViewMovie.SelectedRows[0].DataBoundItem as Movie; return item; } }
        private User SelectedUser { get { User item = null; if (dataGridViewUser.SelectedRows.Count > 0) item = dataGridViewUser.SelectedRows[0].DataBoundItem as User; return item; } }
        public bool IsInsertMode => SelectedMovie == null;
        public bool IsUpdateMode => SelectedMovie != null;
        private MovieSession SelectedMovieSession { get { MovieSession item = null; if (dataGridViewMovieSession.SelectedRows.Count > 0) item = dataGridViewMovieSession.SelectedRows[0].DataBoundItem as MovieSession; return item; } }

        public static MovieForm Instance;
        public MovieForm() { InitializeComponent(); Instance = this; MdiParent = Main.Instance; }
        protected override void OnClosed(EventArgs e) { Instance = null; base.OnClosed(e); }
        protected override void OnLoad(EventArgs e) { base.OnLoad(e); RefreshResources(); getNames(); GridInit(); RefreshMovieList(); RefreshUserList(); RefreshDesignViewer(); }
        public static void ShowForm() { if (Instance == null) Instance = new MovieForm(); Instance.WindowState = FormWindowState.Maximized; Instance.Show(); }
        public static void CloseForm() { Instance?.Close(); }
        #endregion

        #region MovieDetails
        private void textBoxMovieSearch_TextChanged(object sender, EventArgs e) { RefreshMovieList(); }
        private void dataGridViewMovie_SelectionChanged(object sender, EventArgs e)
        {
            if (SelectedMovie != null)
            {
                textBoxMovieTitle.Text = SelectedMovie.Title;
                textBoxMovieDescription.Text = SelectedMovie.Description;
                txtTicketTemplate.Text = SelectedMovie.TemplateName;
                chkActive.Checked = SelectedMovie.Active??false;
                numericUpDownMovieDuration.Value = SelectedMovie.Duration;
                dateTimePickerMovieReleaseDate.Value = SelectedMovie.ReleaseDate ?? DateTime.Now.Date;
                textBoxMovieSummary.Text = SelectedMovie.Summary;
                textBoxMovieStory.Text = SelectedMovie.Story;
                pictureBoxMoviePosterPreview.Image = SelectedMovie.PosterPreview.ToImage();
                pictureBoxMoviePosterOriginal.Image = SelectedMovie.PosterOriginal.ToImage();
                labelMoviePosterPreviewLeft.Text = pictureBoxMoviePosterPreview.Image.GetImageResolution();
                labelMoviePosterOriginalLeft.Text = pictureBoxMoviePosterOriginal.Image.GetImageResolution();
                labelMoviePosterPreviewRight.Text = pictureBoxMoviePosterPreview.Image.GetImageSizeKB();
                labelMoviePosterOriginalRight.Text = pictureBoxMoviePosterOriginal.Image.GetImageSizeKB();
                RefreshMovieTypeList();
                RefreshMovieFormatList();
                RefreshMovieDirectorList();
                RefreshMovieCastList();
                RefresMovieTheatrePlaceList();
                RefresMovieTheatrePlaceTemplateList();
                RefreshMovieCategoryList();
                RefreshMovieSessionList();
            }
            else
            {
                ClearAllFields();
            }
            GeneralCheck();
        }
        private void buttonMovieDetailsNew_Click(object sender, EventArgs e) { dataGridViewMovie.ClearSelection(); ClearAllFields(); GeneralCheck(); textBoxMovieTitle.Focus(); }
        private void buttonMovieDetailsSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var database = CineBookEntitiesExt.New())
                {
                    Movie entity;
                    if (IsInsertMode)
                    {
                        entity = new Movie();
                        entity.Title = textBoxMovieTitle.Text;
                        entity.Description = textBoxMovieDescription.Text;
                        entity.TemplateName = txtTicketTemplate.Text;
                        entity.Duration = (int)numericUpDownMovieDuration.Value;
                        entity.ReleaseDate = dateTimePickerMovieReleaseDate.Value;
                        entity.Summary = textBoxMovieSummary.Text;
                        entity.Story = textBoxMovieStory.Text;
                        entity.Active = chkActive.Checked;
                        database.Movie.Add(entity);
                    }
                    else
                    {
                        entity = database.Movie.Single(o => o.MovieId == SelectedMovie.MovieId);
                        entity.Title = textBoxMovieTitle.Text;
                        entity.Description = textBoxMovieDescription.Text;
                        entity.TemplateName = txtTicketTemplate.Text;
                        entity.Duration = (int)numericUpDownMovieDuration.Value;
                        entity.ReleaseDate = dateTimePickerMovieReleaseDate.Value;
                        entity.Summary = textBoxMovieSummary.Text;
                        entity.Active = chkActive.Checked;
                        entity.Story = textBoxMovieStory.Text;
                    }
                    database.SaveChanges();
                    RefreshMovieList(entity.MovieId);
                }
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void buttonMovieDetailsDelete_Click(object sender, EventArgs e)
        {
            if (!IsUpdateMode) return;
            try
            {
                using (var database = CineBookEntitiesExt.New(true, true))
                {
                    var entity = database.Movie.Single(o => o.MovieId == SelectedMovie.MovieId);
                    if (entity.Movie_MovieType.Count > 0) { StaticClass.ShowWarning(StringConsts.ThisrecordisbeingusedbyanotherrecordYoucannotdeletethisrecord); return; }
                    if (entity.Movie_MovieCast.Count > 0) { StaticClass.ShowWarning(StringConsts.ThisrecordisbeingusedbyanotherrecordYoucannotdeletethisrecord); return; }
                    if (entity.Movie_MovieCategory.Count > 0) { StaticClass.ShowWarning(StringConsts.ThisrecordisbeingusedbyanotherrecordYoucannotdeletethisrecord); return; }
                    if (entity.Movie_MovieDirector.Count > 0) { StaticClass.ShowWarning(StringConsts.ThisrecordisbeingusedbyanotherrecordYoucannotdeletethisrecord); return; }
                    if (entity.Movie_MovieFormat.Count > 0) { StaticClass.ShowWarning(StringConsts.ThisrecordisbeingusedbyanotherrecordYoucannotdeletethisrecord); return; }
                    if (entity.MovieSession.Count > 0) { StaticClass.ShowWarning(StringConsts.ThisrecordisbeingusedbyanotherrecordYoucannotdeletethisrecord); return; }
                    if (!StaticClass.ShowQuestion()) return;
                    database.Movie.Remove(entity);
                    database.SaveChanges();
                    RefreshMovieList();
                }
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void buttonMovieDetailsRefresh_Click(object sender, EventArgs e) { RefreshMovieList(); }
        private void buttonMovieUpdatePosterPreview_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog { Filter = @"*.jpg|*.jpg" };
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                try
                {
                    using (var entities = CineBookEntitiesExt.New())
                    {
                        entities.Movie.Single(o => o.MovieId == SelectedMovie.MovieId).PosterPreview = File.ReadAllBytes(openFileDialog.FileName);
                        entities.SaveChanges();
                    }
                    RefreshMovieList();
                }
                catch (Exception exception)
                {
                    StaticClass.ShowError(exception.ToString());
                }
            }
        }
        private void buttonMovieUpdatePosterOriginal_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog { Filter = @"*.jpg|*.jpg" };
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                try
                {
                    using (var entities = CineBookEntitiesExt.New())
                    {
                        entities.Movie.Single(o => o.MovieId == SelectedMovie.MovieId).PosterOriginal = File.ReadAllBytes(openFileDialog.FileName);
                        entities.SaveChanges();
                    }
                    RefreshMovieList();
                }
                catch (Exception exception)
                {
                    StaticClass.ShowError(exception.ToString());
                }
            }
        }
        #endregion

        #region MovieType
        private void textBoxMovieTypeSearch_TextChanged(object sender, EventArgs e) { RefreshMovieTypeList(); GeneralCheck(); }
        private void buttonMovieTypeRight_Click(object sender, EventArgs e)
        {
            var items = listBoxMovieTypeLeft.SelectedItems.Cast<MovieType>().ToArray();
            if (!items.Any()) return;
            try
            {
                using (var database = CineBookEntitiesExt.New())
                {
                    foreach (var item in items)
                    {
                        var entity = new Movie_MovieType { MovieId = SelectedMovie.MovieId, MovieTypeId = item.MovieTypeId };
                        database.Movie_MovieType.Add(entity);
                    }
                    database.SaveChanges();
                }
                RefreshMovieTypeList();
                GeneralCheck();
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void buttonMovieTypeLeft_Click(object sender, EventArgs e)
        {
            var items = listBoxMovieTypeRight.SelectedItems.Cast<MovieType>().Select(o => o.MovieTypeId).ToArray();
            if (!items.Any()) return;
            try
            {
                using (var database = CineBookEntitiesExt.New())
                {
                    foreach (var entity in database.Movie_MovieType.Where(o => o.MovieId == SelectedMovie.MovieId && items.Contains(o.MovieTypeId))) database.Movie_MovieType.Remove(entity);
                    database.SaveChanges();
                }
                RefreshMovieTypeList();
                GeneralCheck();
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void menuMovieType_Opening(object sender, CancelEventArgs e)
        {
            menuMovieTypeEdit.Visible = listBoxMovieTypeLeft.SelectedItems.Count == 1;
            menuMovieTypeDelete.Visible = listBoxMovieTypeLeft.SelectedItems.Count == 1;
        }
        private void menuMovieTypeRefresh_Click(object sender, EventArgs e) { RefreshMovieTypeList(); }
        private void menuMovieTypeNew_Click(object sender, EventArgs e)
        {
            var entity = new MovieType();
        Retry:
            if (!MovieTypeEditForm.ShowForm(entity)) return;
            using (var database = CineBookEntitiesExt.New())
            {
                if (database.MovieType.Any(o => o.MovieTypeName == entity.MovieTypeName)) { StaticClass.ShowWarning(StringConsts.Thesamenameditemalreadyexists); goto Retry; }
                database.MovieType.Add(entity);
                database.SaveChanges();
                RefreshMovieTypeList(entity.MovieTypeId);
                GeneralCheck();
            }
        }
        private void menuMovieTypeEdit_Click(object sender, EventArgs e)
        {
            var item = listBoxMovieTypeLeft.SelectedItem as MovieType;
            if (item == null) return;
            Retry:
            if (!MovieTypeEditForm.ShowForm(item)) { RefreshMovieTypeList(item.MovieTypeId); return; }
            using (var database = CineBookEntitiesExt.New())
            {
                if (database.MovieType.Any(o => o.MovieTypeName == item.MovieTypeName && o.MovieTypeId != item.MovieTypeId)) { StaticClass.ShowWarning(StringConsts.Thesamenameditemalreadyexists); goto Retry; }
                var entity = database.MovieType.Single(o => o.MovieTypeId == item.MovieTypeId);
                entity.MovieTypeName = item.MovieTypeName;
                database.SaveChanges();
                RefreshMovieTypeList(entity.MovieTypeId);
                GeneralCheck();
            }
        }
        private void menuMovieTypeDelete_Click(object sender, EventArgs e)
        {
            var item = listBoxMovieTypeLeft.SelectedItem as MovieType;
            if (item == null) return;
            using (var database = CineBookEntitiesExt.New())
            {
                var entity = database.MovieType.Single(o => o.MovieTypeId == item.MovieTypeId);
                if (database.Movie_MovieType.Any(o => o.MovieTypeId == item.MovieTypeId)) { StaticClass.ShowWarning(StringConsts.ThisrecordisbeingusedbyanotherrecordYoucannotdeletethisrecord); return; }
                if (!StaticClass.ShowQuestion()) return;
                database.MovieType.Remove(entity);
                database.SaveChanges();
                RefreshMovieTypeList(entity.MovieTypeId);
                GeneralCheck();
            }
        }
        #endregion

        #region MovieFormat
        private void textBoxMovieFormatSearch_TextChanged(object sender, EventArgs e) { RefreshMovieFormatList(); GeneralCheck(); }
        private void buttonMovieFormatRight_Click(object sender, EventArgs e)
        {
            var items = listBoxMovieFormatLeft.SelectedItems.Cast<MovieFormat>().ToArray();
            if (!items.Any()) return;
            try
            {
                using (var database = CineBookEntitiesExt.New())
                {
                    foreach (var item in items)
                    {
                        var entity = new Movie_MovieFormat { MovieId = SelectedMovie.MovieId, MovieFormatId = item.MovieFormatId };
                        database.Movie_MovieFormat.Add(entity);
                    }
                    database.SaveChanges();
                }
                RefreshMovieFormatList();
                GeneralCheck();
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void buttonMovieFormatLeft_Click(object sender, EventArgs e)
        {
            var items = listBoxMovieFormatRight.SelectedItems.Cast<MovieFormat>().Select(o => o.MovieFormatId).ToArray();
            if (!items.Any()) return;
            try
            {
                using (var database = CineBookEntitiesExt.New())
                {
                    foreach (var entity in database.Movie_MovieFormat.Where(o => o.MovieId == SelectedMovie.MovieId && items.Contains(o.MovieFormatId))) database.Movie_MovieFormat.Remove(entity);
                    database.SaveChanges();
                }
                RefreshMovieFormatList();
                GeneralCheck();
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void menuMovieFormat_Opening(object sender, CancelEventArgs e)
        {
            menuMovieFormatEdit.Visible = listBoxMovieFormatLeft.SelectedItems.Count == 1;
            menuMovieFormatDelete.Visible = listBoxMovieFormatLeft.SelectedItems.Count == 1;
        }
        private void menuMovieFormatRefresh_Click(object sender, EventArgs e) { RefreshMovieFormatList(); }
        private void menuMovieFormatNew_Click(object sender, EventArgs e)
        {
            var entity = new MovieFormat();
        Retry:
            if (!MovieFormatEditForm.ShowForm(entity)) return;
            using (var database = CineBookEntitiesExt.New())
            {
                if (database.MovieFormat.Any(o => o.MovieFormatCode == entity.MovieFormatCode || o.MovieFormatName == entity.MovieFormatName)) { StaticClass.ShowWarning(StringConsts.Thesamenameditemalreadyexists); goto Retry; }
                database.MovieFormat.Add(entity);
                database.SaveChanges();
                RefreshMovieFormatList(entity.MovieFormatId);
                GeneralCheck();
            }
        }
        private void menuMovieFormatEdit_Click(object sender, EventArgs e)
        {
            var item = listBoxMovieFormatLeft.SelectedItem as MovieFormat;
            if (item == null) return;
            Retry:
            if (!MovieFormatEditForm.ShowForm(item)) { RefreshMovieFormatList(item.MovieFormatId); return; }
            using (var database = CineBookEntitiesExt.New())
            {
                if (database.MovieFormat.Any(o => (o.MovieFormatCode == item.MovieFormatCode || o.MovieFormatName == item.MovieFormatName) && o.MovieFormatId != item.MovieFormatId)) { StaticClass.ShowWarning(StringConsts.Thesamenameditemalreadyexists); goto Retry; }
                var entity = database.MovieFormat.Single(o => o.MovieFormatId == item.MovieFormatId);
                entity.MovieFormatCode = item.MovieFormatCode;
                entity.MovieFormatName = item.MovieFormatName;
                database.SaveChanges();
                RefreshMovieFormatList(entity.MovieFormatId);
                GeneralCheck();
            }
        }
        private void menuMovieFormatDelete_Click(object sender, EventArgs e)
        {
            var item = listBoxMovieFormatLeft.SelectedItem as MovieFormat;
            if (item == null) return;
            using (var database = CineBookEntitiesExt.New())
            {
                var entity = database.MovieFormat.Single(o => o.MovieFormatId == item.MovieFormatId);
                if (database.Movie_MovieFormat.Any(o => o.MovieFormatId == item.MovieFormatId)) { StaticClass.ShowWarning(StringConsts.ThisrecordisbeingusedbyanotherrecordYoucannotdeletethisrecord); return; }
                if (!StaticClass.ShowQuestion()) return;
                database.MovieFormat.Remove(entity);
                database.SaveChanges();
                RefreshMovieFormatList(entity.MovieFormatId);
                GeneralCheck();
            }
        }
        #endregion

        #region MovieDirector
        private void textBoxMovieDirectorSearch_TextChanged(object sender, EventArgs e) { RefreshMovieDirectorList(); GeneralCheck(); }
        private void buttonMovieDirectorRight_Click(object sender, EventArgs e)
        {
            var items = listBoxMovieDirectorLeft.SelectedItems.Cast<MovieDirector>().ToArray();
            if (!items.Any()) return;
            try
            {
                using (var database = CineBookEntitiesExt.New())
                {
                    foreach (var item in items)
                    {
                        var entity = new Movie_MovieDirector { MovieId = SelectedMovie.MovieId, MovieDirectorId = item.MovieDirectorId };
                        database.Movie_MovieDirector.Add(entity);
                    }
                    database.SaveChanges();
                }
                RefreshMovieDirectorList();
                GeneralCheck();
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void buttonMovieDirectorLeft_Click(object sender, EventArgs e)
        {
            var items = listBoxMovieDirectorRight.SelectedItems.Cast<MovieDirector>().Select(o => o.MovieDirectorId).ToArray();
            if (!items.Any()) return;
            try
            {
                using (var database = CineBookEntitiesExt.New())
                {
                    foreach (var entity in database.Movie_MovieDirector.Where(o => o.MovieId == SelectedMovie.MovieId && items.Contains(o.MovieDirectorId))) database.Movie_MovieDirector.Remove(entity);
                    database.SaveChanges();
                }
                RefreshMovieDirectorList();
                GeneralCheck();
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void menuMovieDirector_Opening(object sender, CancelEventArgs e)
        {
            menuMovieDirectorEdit.Visible = listBoxMovieDirectorLeft.SelectedItems.Count == 1;
            menuMovieDirectorDelete.Visible = listBoxMovieDirectorLeft.SelectedItems.Count == 1;
        }
        private void menuMovieDirectorRefresh_Click(object sender, EventArgs e) { RefreshMovieDirectorList(); }
        private void menuMovieDirectorNew_Click(object sender, EventArgs e)
        {
            var entity = new MovieDirector();
        Retry:
            if (!MovieDirectorEditForm.ShowForm(entity)) return;
            using (var database = CineBookEntitiesExt.New())
            {
                if (database.MovieDirector.Any(o => o.MovieDirectorName == entity.MovieDirectorName)) { StaticClass.ShowWarning(StringConsts.Thesamenameditemalreadyexists); goto Retry; }
                database.MovieDirector.Add(entity);
                database.SaveChanges();
                RefreshMovieDirectorList(entity.MovieDirectorId);
                GeneralCheck();
            }
        }
        private void menuMovieDirectorEdit_Click(object sender, EventArgs e)
        {
            var item = listBoxMovieDirectorLeft.SelectedItem as MovieDirector;
            if (item == null) return;
            Retry:
            if (!MovieDirectorEditForm.ShowForm(item)) { RefreshMovieDirectorList(item.MovieDirectorId); return; }
            using (var database = CineBookEntitiesExt.New())
            {
                if (database.MovieDirector.Any(o => o.MovieDirectorName == item.MovieDirectorName && o.MovieDirectorId != item.MovieDirectorId)) { StaticClass.ShowWarning(StringConsts.Thesamenameditemalreadyexists); goto Retry; }
                var entity = database.MovieDirector.Single(o => o.MovieDirectorId == item.MovieDirectorId);
                entity.MovieDirectorName = item.MovieDirectorName;
                database.SaveChanges();
                RefreshMovieDirectorList(entity.MovieDirectorId);
                GeneralCheck();
            }
        }
        private void menuMovieDirectorDelete_Click(object sender, EventArgs e)
        {
            var item = listBoxMovieDirectorLeft.SelectedItem as MovieDirector;
            if (item == null) return;
            using (var database = CineBookEntitiesExt.New())
            {
                var entity = database.MovieDirector.Single(o => o.MovieDirectorId == item.MovieDirectorId);
                if (database.Movie_MovieDirector.Any(o => o.MovieDirectorId == item.MovieDirectorId)) { StaticClass.ShowWarning(StringConsts.ThisrecordisbeingusedbyanotherrecordYoucannotdeletethisrecord); return; }
                if (!StaticClass.ShowQuestion()) return;
                database.MovieDirector.Remove(entity);
                database.SaveChanges();
                RefreshMovieDirectorList(entity.MovieDirectorId);
                GeneralCheck();
            }
        }
        #endregion

        #region MovieCast
        private void textBoxMovieCastSearch_TextChanged(object sender, EventArgs e) { RefreshMovieCastList(); GeneralCheck(); }
        private void buttonMovieCastRight_Click(object sender, EventArgs e)
        {
            var items = listBoxMovieCastLeft.SelectedItems.Cast<MovieCast>().ToArray();
            if (!items.Any()) return;
            try
            {
                using (var database = CineBookEntitiesExt.New())
                {
                    foreach (var item in items)
                    {
                        var entity = new Movie_MovieCast { MovieId = SelectedMovie.MovieId, MovieCastId = item.MovieCastId };
                        database.Movie_MovieCast.Add(entity);
                    }
                    database.SaveChanges();
                }
                RefreshMovieCastList();
                GeneralCheck();
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void buttonMovieCastLeft_Click(object sender, EventArgs e)
        {
            var items = listBoxMovieCastRight.SelectedItems.Cast<MovieCast>().Select(o => o.MovieCastId).ToArray();
            if (!items.Any()) return;
            try
            {
                using (var database = CineBookEntitiesExt.New())
                {
                    foreach (var entity in database.Movie_MovieCast.Where(o => o.MovieId == SelectedMovie.MovieId && items.Contains(o.MovieCastId))) database.Movie_MovieCast.Remove(entity);
                    database.SaveChanges();
                }
                RefreshMovieCastList();
                GeneralCheck();
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void menuMovieCast_Opening(object sender, CancelEventArgs e)
        {
            menuMovieCastEdit.Visible = listBoxMovieCastLeft.SelectedItems.Count == 1;
            menuMovieCastDelete.Visible = listBoxMovieCastLeft.SelectedItems.Count == 1;
        }
        private void menuMovieCastRefresh_Click(object sender, EventArgs e) { RefreshMovieCastList(); }
        private void menuMovieCastNew_Click(object sender, EventArgs e)
        {
            var entity = new MovieCast();
        Retry:
            if (!MovieCastEditForm.ShowForm(entity)) return;
            using (var database = CineBookEntitiesExt.New())
            {
                if (database.MovieCast.Any(o => o.CastName == entity.CastName)) { StaticClass.ShowWarning(StringConsts.Thesamenameditemalreadyexists); goto Retry; }
                database.MovieCast.Add(entity);
                database.SaveChanges();
                RefreshMovieCastList(entity.MovieCastId);
                GeneralCheck();
            }
        }
        private void menuMovieCastEdit_Click(object sender, EventArgs e)
        {
            var item = listBoxMovieCastLeft.SelectedItem as MovieCast;
            if (item == null) return;
            Retry:
            if (!MovieCastEditForm.ShowForm(item)) { RefreshMovieCastList(item.MovieCastId); return; }
            using (var database = CineBookEntitiesExt.New())
            {
                if (database.MovieCast.Any(o => o.CastName == item.CastName && o.MovieCastId != item.MovieCastId)) { StaticClass.ShowWarning(StringConsts.Thesamenameditemalreadyexists); goto Retry; }
                var entity = database.MovieCast.Single(o => o.MovieCastId == item.MovieCastId);
                entity.CastName = item.CastName;
                database.SaveChanges();
                RefreshMovieCastList(entity.MovieCastId);
                GeneralCheck();
            }
        }
        private void menuMovieCastDelete_Click(object sender, EventArgs e)
        {
            var item = listBoxMovieCastLeft.SelectedItem as MovieCast;
            if (item == null) return;
            using (var database = CineBookEntitiesExt.New())
            {
                var entity = database.MovieCast.Single(o => o.MovieCastId == item.MovieCastId);
                if (database.Movie_MovieCast.Any(o => o.MovieCastId == item.MovieCastId)) { StaticClass.ShowWarning(StringConsts.ThisrecordisbeingusedbyanotherrecordYoucannotdeletethisrecord); return; }
                if (!StaticClass.ShowQuestion()) return;
                database.MovieCast.Remove(entity);
                database.SaveChanges();
                RefreshMovieCastList(entity.MovieCastId);
                GeneralCheck();
            }
        }
        #endregion

        #region MovieCategory
        private void textBoxMovieCategorySearch_TextChanged(object sender, EventArgs e) { RefreshMovieCategoryList(); GeneralCheck(); }
        private void buttonMovieCategoryRight_Click(object sender, EventArgs e)
        {
            var items = listBoxMovieCategoryLeft.SelectedItems.Cast<MovieCategory>().ToArray();
            if (!items.Any()) return;
            try
            {
                using (var database = CineBookEntitiesExt.New())
                {
                    foreach (var item in items)
                    {
                        var entity = new Movie_MovieCategory { MovieId = SelectedMovie.MovieId, MovieCategoryId = item.MovieCategoryId };
                        database.Movie_MovieCategory.Add(entity);
                    }
                    database.SaveChanges();
                }
                RefreshMovieCategoryList();
                GeneralCheck();
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void buttonMovieCategoryLeft_Click(object sender, EventArgs e)
        {
            var items = listBoxMovieCategoryRight.SelectedItems.Cast<MovieCategory>().Select(o => o.MovieCategoryId).ToArray();
            if (!items.Any()) return;
            try
            {
                using (var database = CineBookEntitiesExt.New())
                {
                    foreach (var entity in database.Movie_MovieCategory.Where(o => o.MovieId == SelectedMovie.MovieId && items.Contains(o.MovieCategoryId))) database.Movie_MovieCategory.Remove(entity);
                    database.SaveChanges();
                }
                RefreshMovieCategoryList();
                GeneralCheck();
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void menuMovieCategory_Opening(object sender, CancelEventArgs e)
        {
            menuMovieCategoryEdit.Visible = listBoxMovieCategoryLeft.SelectedItems.Count == 1;
            menuMovieCategoryDelete.Visible = listBoxMovieCategoryLeft.SelectedItems.Count == 1;
        }
        private void menuMovieCategoryRefresh_Click(object sender, EventArgs e) { RefreshMovieCategoryList(); }
        private void menuMovieCategoryNew_Click(object sender, EventArgs e)
        {
            var entity = new MovieCategory();
        Retry:
            if (!MovieCategoryEditForm.ShowForm(entity)) return;
            using (var database = CineBookEntitiesExt.New())
            {
                if (database.MovieCategory.Any(o => o.MovieCategoryName == entity.MovieCategoryName)) { StaticClass.ShowWarning(StringConsts.Thesamenameditemalreadyexists); goto Retry; }
                database.MovieCategory.Add(entity);
                database.SaveChanges();
                RefreshMovieCategoryList(entity.MovieCategoryId);
                GeneralCheck();
            }
        }
        private void menuMovieCategoryEdit_Click(object sender, EventArgs e)
        {
            var item = listBoxMovieCategoryLeft.SelectedItem as MovieCategory;
            if (item == null) return;
            Retry:
            if (!MovieCategoryEditForm.ShowForm(item)) { RefreshMovieCategoryList(item.MovieCategoryId); return; }
            using (var database = CineBookEntitiesExt.New())
            {
                if (database.MovieCategory.Any(o => o.MovieCategoryName == item.MovieCategoryName && o.MovieCategoryId != item.MovieCategoryId)) { StaticClass.ShowWarning(StringConsts.Thesamenameditemalreadyexists); goto Retry; }
                var entity = database.MovieCategory.Single(o => o.MovieCategoryId == item.MovieCategoryId);
                entity.MovieCategoryName = item.MovieCategoryName;
                database.SaveChanges();
                RefreshMovieCategoryList(entity.MovieCategoryId);
                GeneralCheck();
            }
        }
        private void menuMovieCategoryDelete_Click(object sender, EventArgs e)
        {
            var item = listBoxMovieCategoryLeft.SelectedItem as MovieCategory;
            if (item == null) return;
            using (var database = CineBookEntitiesExt.New())
            {
                var entity = database.MovieCategory.Single(o => o.MovieCategoryId == item.MovieCategoryId);
                if (database.Movie_MovieCategory.Any(o => o.MovieCategoryId == item.MovieCategoryId)) { StaticClass.ShowWarning(StringConsts.ThisrecordisbeingusedbyanotherrecordYoucannotdeletethisrecord); return; }
                if (!StaticClass.ShowQuestion()) return;
                database.MovieCategory.Remove(entity);
                database.SaveChanges();
                RefreshMovieCategoryList(entity.MovieCategoryId);
                GeneralCheck();
            }
        }
        #endregion

        #region User
        private void textBoxUserSearch_TextChanged(object sender, EventArgs e) { RefreshUserList(); }
        private void menuUser_Opening(object sender, CancelEventArgs e)
        {
            menuUserEdit.Visible = dataGridViewUser.SelectedRows.Count == 1;
            menuUserDelete.Visible = dataGridViewUser.SelectedRows.Count == 1;
        }
        private void menuUserRefresh_Click(object sender, EventArgs e) { RefreshUserList(); }
        private void menuUserNew_Click(object sender, EventArgs e)
        {
            var entity = new User();
        Retry:
            if (!UserEditForm.ShowForm(entity)) return;
            using (var database = CineBookEntitiesExt.New())
            {
                if (database.User.Any(o => o.UserCode == entity.UserCode)) { StaticClass.ShowWarning(StringConsts.Thesamenameditemalreadyexists); goto Retry; }
                database.User.Add(entity);
                database.SaveChanges();
                RefreshUserList(entity.UserId);
            }
        }
        private void menuUserEdit_Click(object sender, EventArgs e)
        {
            var item = SelectedUser;
            if (item == null) return;
            Retry:
            if (!UserEditForm.ShowForm(item)) { RefreshUserList(item.UserId); return; }
            using (var database = CineBookEntitiesExt.New())
            {
                if (database.User.Any(o => o.UserCode == item.UserCode && o.UserId != item.UserId)) { StaticClass.ShowWarning(StringConsts.Thesamenameditemalreadyexists); goto Retry; }
                var entity = database.User.Single(o => o.UserId == item.UserId);
                entity.UserCode = item.UserCode;
                entity.UserName = item.UserName;
                entity.MailAddress = item.MailAddress;
                entity.Password = item.Password;
                entity.Deleted = item.Deleted;
                database.SaveChanges();
                RefreshUserList(entity.UserId);
            }
        }
        private void menuUserDelete_Click(object sender, EventArgs e)
        {
            var item = SelectedUser;
            if (item == null) return;
            using (var database = CineBookEntitiesExt.New())
            {
                var entity = database.User.Single(o => o.UserId == item.UserId);
                if (database.ModuleAuth.Any(o => o.UserId == item.UserId) ||
                    database.MovieSessionReservation.Any(o => o.UserId == item.UserId) ||
                    database.MovieTicketSale.Any(o => o.UserId == item.UserId) ||
                    database.UserGroup_User.Any(o => o.UserId == item.UserId) ||
                    database.UserSession.Any(o => o.UserId == item.UserId)
                ) { StaticClass.ShowWarning(StringConsts.ThisrecordisbeingusedbyanotherrecordYoucannotdeletethisrecord); return; }
                if (!StaticClass.ShowQuestion()) return;
                database.User.Remove(entity);
                database.SaveChanges();
                RefreshUserList(entity.UserId);
            }
        }
        #endregion

        #region Design
        private void buttonDesignUpdate_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog { Filter = @"*.trdx|*.trdx" };
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                try
                {
                    using (var database = CineBookEntitiesExt.New())
                    {
                        var template = database.PrinterTemplate.FirstOrDefault(o => o.TemplateName == "Ticket");
                        if (template == null) { template = new PrinterTemplate { TemplateName = "Ticket" }; database.PrinterTemplate.Add(template); }
                        template.TemplateContent = File.ReadAllText(openFileDialog.FileName);
                        database.SaveChanges();
                    }
                    RefreshDesignViewer();
                }
                catch (Exception exception)
                {
                    StaticClass.ShowError(exception.ToString());
                }
            }
        }
        private void buttonDesignRefresh_Click(object sender, EventArgs e) { RefreshDesignViewer(); }
        private void buttonDesignExport_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog { Filter = @"*.trdx|*.trdx" };
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    using (var database = CineBookEntitiesExt.New())
                    {
                        var template = database.PrinterTemplate.FirstOrDefault(o => o.TemplateName == "Ticket");
                        if (template != null)
                        {
                            File.WriteAllText(saveFileDialog.FileName, template.TemplateContent);
                        }
                    }
                }
                catch (Exception exception)
                {
                    StaticClass.ShowError(exception.ToString());
                }
            }
        }
        #endregion

        #region Custom Methods
        private void GridInit()
        {
            dataGridViewMovie.Columns.Clear();
            dataGridViewMovie.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MovieId", Name = "MovieId", HeaderText = @"#", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dataGridViewMovie.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Title", Name = "MovieTitle", HeaderText = StringConsts.Column_Title, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dataGridViewMovie.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Description", Name = "MovieDescription", HeaderText = StringConsts.Column_Description, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dataGridViewMovie.AutoGenerateColumns = false;
            dataGridViewMovie.DataSource = _movieList;
            listBoxMovieTypeLeft.DataSource = _movieTypeListLeft;
            listBoxMovieTypeRight.DataSource = _movieTypeListRight;
            listBoxMovieFormatLeft.DataSource = _movieFormatListLeft;
            listBoxMovieFormatRight.DataSource = _movieFormatListRight;
            listBoxMovieDirectorLeft.DataSource = _movieDirectorListLeft;
            listBoxMovieDirectorRight.DataSource = _movieDirectorListRight;
            listBoxMovieCastLeft.DataSource = _movieCastListLeft;
            listBoxMovieCastRight.DataSource = _movieCastListRight;
            listBoxMovieCategoryLeft.DataSource = _movieCategoryListLeft;
            listBoxMovieCategoryRight.DataSource = _movieCategoryListRight;
            dataGridViewMovieSession.Columns.Clear();
            dataGridViewMovieSession.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "MovieTheatrePlace.MovieTheatrePlaceName", Name = "MovieTheatrePlaceName", HeaderText = "TheatrePlace", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dataGridViewMovieSession.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "SessionTime", Name = "SessionTime", HeaderText = "SessionTime", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dataGridViewMovieSession.AutoGenerateColumns = false;
            dataGridViewMovieSession.DataSource = _movieSessionList;
            listBoxMovieSessionMovieFormatLeft.DataSource = _movieSessionMovieFormatListLeft;
            listBoxMovieSessionMovieFormatRight.DataSource = _movieSessionMovieFormatListRight;
            dataGridViewUser.Columns.Clear();
            dataGridViewUser.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UserId", Name = "UserId", HeaderText = @"#", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dataGridViewUser.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UserCode", Name = "UserCode", HeaderText = StringConsts.Column_Code, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dataGridViewUser.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UserName", Name = "UserName", HeaderText = StringConsts.Column_Name, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dataGridViewUser.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MailAddress", Name = "MailAddress", HeaderText = StringConsts.Column_MailAddress, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dataGridViewUser.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "Deleted", Name = "Deleted", HeaderText = StringConsts.Column_Deleted, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dataGridViewUser.AutoGenerateColumns = false;
            dataGridViewUser.DataSource = _userList;
            //cmbSaloons.DataSource = _movieTheatrePlace;
            //cmbSaloons.DisplayMember = "MovieTheatrePlaceName";
            cmbTemp.DataSource = _movieTheatrePlaceTemplate;
            cmbTemp.DisplayMember = "Description";

        }
        private void RefreshMovieList(int? selectedId = null)
        {
            if (selectedId == null && IsUpdateMode) selectedId = SelectedMovie.MovieId;
            try
            {
                _movieList.Clear();
                using (var database = CineBookEntitiesExt.New())
                {
                    if (textBoxMovieSearch.Text == "")
                        foreach (var item in database.Movie.OrderByDescending(o => o.MovieId).Take(StaticClass.LinqTopRowsCount).ToList()) _movieList.Add(item);
                    else
                        foreach (var item in database.Movie.Where(o => o.Title.Contains(textBoxMovieSearch.Text) || o.Description.Contains(textBoxMovieSearch.Text)).OrderByDescending(o => o.MovieId).Take(StaticClass.LinqTopRowsCount).ToList()) _movieList.Add(item);
                }
                if (selectedId != null) { foreach (DataGridViewRow row in dataGridViewMovie.Rows) { var item = row.DataBoundItem as Movie; if (item == null || item.MovieId != selectedId) continue; row.Selected = true; break; } }
            }
            catch (Exception)
            {
            }
        }
        private void RefreshMovieTypeList(int? selectedId = null)
        {
            _movieTypeListLeft.Clear();
            _movieTypeListRight.Clear();
            if (!IsUpdateMode) return;
            try
            {
                using (var database = CineBookEntitiesExt.New(true, true))
                {
                    var movie = database.Movie.Single(o => o.MovieId == SelectedMovie.MovieId);
                    foreach (var item in movie.Movie_MovieType.Select(o => o.MovieType).Distinct().OrderBy(o => o.MovieTypeName)) _movieTypeListRight.Add(item);
                    var rightItems = _movieTypeListRight.Select(o => o.MovieTypeId);

                    if (textBoxMovieTypeSearch.Text == "")
                        foreach (var item in database.MovieType.Where(o => !rightItems.Contains(o.MovieTypeId)).OrderBy(o => o.MovieTypeName).ToList()) _movieTypeListLeft.Add(item);
                    else
                        foreach (var item in database.MovieType.Where(o => !rightItems.Contains(o.MovieTypeId) && (o.MovieTypeName.Contains(textBoxMovieTypeSearch.Text) || o.MovieTypeName.Contains(textBoxMovieTypeSearch.Text))).OrderBy(o => o.MovieTypeName).ToList()) _movieTypeListLeft.Add(item);

                }
                if (selectedId != null) { listBoxMovieTypeLeft.ClearSelected(); listBoxMovieTypeLeft.SelectedItem = _movieTypeListLeft.FirstOrDefault(o => o.MovieTypeId == selectedId); }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
        private void RefreshMovieFormatList(int? selectedId = null)
        {
            _movieFormatListLeft.Clear();
            _movieFormatListRight.Clear();
            if (!IsUpdateMode) return;
            try
            {
                using (var database = CineBookEntitiesExt.New(true, true))
                {
                    var movie = database.Movie.Single(o => o.MovieId == SelectedMovie.MovieId);
                    foreach (var item in movie.Movie_MovieFormat.Select(o => o.MovieFormat).Distinct().OrderBy(o => o.MovieFormatName)) _movieFormatListRight.Add(item);
                    var rightItems = _movieFormatListRight.Select(o => o.MovieFormatId);

                    if (textBoxMovieFormatSearch.Text == "")
                        foreach (var item in database.MovieFormat.Where(o => !rightItems.Contains(o.MovieFormatId)).OrderBy(o => o.MovieFormatName).ToList()) _movieFormatListLeft.Add(item);
                    else
                        foreach (var item in database.MovieFormat.Where(o => !rightItems.Contains(o.MovieFormatId) && (o.MovieFormatName.Contains(textBoxMovieFormatSearch.Text) || o.MovieFormatName.Contains(textBoxMovieFormatSearch.Text))).OrderBy(o => o.MovieFormatName).ToList()) _movieFormatListLeft.Add(item);

                }
                if (selectedId != null) { listBoxMovieFormatLeft.ClearSelected(); listBoxMovieFormatLeft.SelectedItem = _movieFormatListLeft.FirstOrDefault(o => o.MovieFormatId == selectedId); }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
        private void RefreshMovieDirectorList(int? selectedId = null)
        {
            _movieDirectorListLeft.Clear();
            _movieDirectorListRight.Clear();
            if (!IsUpdateMode) return;
            try
            {
                using (var database = CineBookEntitiesExt.New(true, true))
                {
                    var movie = database.Movie.Single(o => o.MovieId == SelectedMovie.MovieId);
                    foreach (var item in movie.Movie_MovieDirector.Select(o => o.MovieDirector).Distinct().OrderBy(o => o.MovieDirectorName)) _movieDirectorListRight.Add(item);
                    var rightItems = _movieDirectorListRight.Select(o => o.MovieDirectorId);

                    if (textBoxMovieDirectorSearch.Text == "")
                        foreach (var item in database.MovieDirector.Where(o => !rightItems.Contains(o.MovieDirectorId)).OrderBy(o => o.MovieDirectorName).Take(StaticClass.LinqTopRowsCount).ToList()) _movieDirectorListLeft.Add(item);
                    else
                        foreach (var item in database.MovieDirector.Where(o => !rightItems.Contains(o.MovieDirectorId) && (o.MovieDirectorName.Contains(textBoxMovieDirectorSearch.Text) || o.MovieDirectorName.Contains(textBoxMovieDirectorSearch.Text))).OrderBy(o => o.MovieDirectorName).Take(StaticClass.LinqTopRowsCount).ToList()) _movieDirectorListLeft.Add(item);

                }
                if (selectedId != null) { listBoxMovieDirectorLeft.ClearSelected(); listBoxMovieDirectorLeft.SelectedItem = _movieDirectorListLeft.FirstOrDefault(o => o.MovieDirectorId == selectedId); }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
        private void RefreshMovieCastList(int? selectedId = null)
        {
            _movieCastListLeft.Clear();
            _movieCastListRight.Clear();
            if (!IsUpdateMode) return;
            try
            {
                using (var database = CineBookEntitiesExt.New(true, true))
                {
                    var movie = database.Movie.Single(o => o.MovieId == SelectedMovie.MovieId);
                    foreach (var item in movie.Movie_MovieCast.Select(o => o.MovieCast).Distinct().OrderBy(o => o.CastName)) _movieCastListRight.Add(item);
                    var rightItems = _movieCastListRight.Select(o => o.MovieCastId);

                    if (textBoxMovieCastSearch.Text == "")
                        foreach (var item in database.MovieCast.Where(o => !rightItems.Contains(o.MovieCastId)).OrderBy(o => o.CastName).Take(StaticClass.LinqTopRowsCount).ToList()) _movieCastListLeft.Add(item);
                    else
                        foreach (var item in database.MovieCast.Where(o => !rightItems.Contains(o.MovieCastId) && o.CastName.Contains(textBoxMovieCastSearch.Text)).OrderBy(o => o.CastName).Take(StaticClass.LinqTopRowsCount).ToList()) _movieCastListLeft.Add(item);

                }
                if (selectedId != null) { listBoxMovieCastLeft.ClearSelected(); listBoxMovieCastLeft.SelectedItem = _movieCastListLeft.FirstOrDefault(o => o.MovieCastId == selectedId); }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        private void RefresMovieTheatrePlaceList(int? selectedId = null)
        {
            _movieTheatrePlace.Clear();

            if (!IsUpdateMode) return;
            try
            {
                using (var database = CineBookEntitiesExt.New(true, true))
                {
                    var movie = database.MovieTheatrePlace;
                    foreach (var item in movie) _movieTheatrePlace.Add(item);

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }


        private void RefresMovieTheatrePlaceTemplateList(int? selectedId = null)
        {
            _movieTheatrePlaceTemplate.Clear();

            if (!IsUpdateMode) return;
            try
            {
                using (var database = CineBookEntitiesExt.New(true, true))
                {
                    var movie = database.MovieTheatrePlaceTemplate;
                    foreach (var item in movie) _movieTheatrePlaceTemplate.Add(item);

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        private void RefreshMovieCategoryList(int? selectedId = null)
        {
            _movieCategoryListLeft.Clear();
            _movieCategoryListRight.Clear();
            if (!IsUpdateMode) return;
            try
            {
                using (var database = CineBookEntitiesExt.New(true, true))
                {
                    var movie = database.Movie.Single(o => o.MovieId == SelectedMovie.MovieId);
                    foreach (var item in movie.Movie_MovieCategory.Select(o => o.MovieCategory).Distinct().OrderBy(o => o.MovieCategoryName)) _movieCategoryListRight.Add(item);
                    var rightItems = _movieCategoryListRight.Select(o => o.MovieCategoryId);

                    if (textBoxMovieCategorySearch.Text == "")
                        foreach (var item in database.MovieCategory.Where(o => !rightItems.Contains(o.MovieCategoryId)).OrderBy(o => o.MovieCategoryName).ToList()) _movieCategoryListLeft.Add(item);
                    else
                        foreach (var item in database.MovieCategory.Where(o => !rightItems.Contains(o.MovieCategoryId) && (o.MovieCategoryName.Contains(textBoxMovieCategorySearch.Text) || o.MovieCategoryName.Contains(textBoxMovieCategorySearch.Text))).OrderBy(o => o.MovieCategoryName).ToList()) _movieCategoryListLeft.Add(item);

                }
                if (selectedId != null) { listBoxMovieCategoryLeft.ClearSelected(); listBoxMovieCategoryLeft.SelectedItem = _movieCategoryListLeft.FirstOrDefault(o => o.MovieCategoryId == selectedId); }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }



        private void RefreshMovieSessionList(int? selectedId = null)
        {
            _movieSessionList.Clear();
            if (!IsUpdateMode) return;
            try
            {
                using (var database = CineBookEntitiesExt.New(true, true))
                {
                    var movie = database.Movie.Single(o => o.MovieId == SelectedMovie.MovieId);
                    var startDate = datePickerMovieSession.Value.Date;
                    var finishDate = datePickerMovieSession.Value.Date.AddDays(1);
                    foreach (var item in movie.MovieSession.Where(o => o.SessionTime >= startDate && o.SessionTime < finishDate).OrderBy(o => o.MovieTheatrePlace.MovieTheatrePlaceName).ThenBy(o => o.SessionTime)) _movieSessionList.Add(item);
                }
                dataGridViewMovieSession.ClearSelection();
                if (selectedId != null) { foreach (DataGridViewRow row in dataGridViewMovieSession.Rows) { var item = row.DataBoundItem as MovieSession; if (item == null || item.MovieSessionId != selectedId) continue; row.Selected = true; break; } }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
        private void RefreshMovieSessionMovieFormatList(int? selectedId = null)
        {
            _movieSessionMovieFormatListLeft.Clear();
            _movieSessionMovieFormatListRight.Clear();
            if (!IsUpdateMode) return;
            if (SelectedMovieSession == null) return;
            try
            {
                using (var database = CineBookEntitiesExt.New(true, true))
                {
                    var movieSession = database.MovieSession.Single(o => o.MovieSessionId == SelectedMovieSession.MovieSessionId);
                    foreach (var item in movieSession.MovieSession_MovieFormat.Select(o => o.MovieFormat).Distinct().OrderBy(o => o.MovieFormatName)) _movieSessionMovieFormatListRight.Add(item);
                    var rightItems = _movieSessionMovieFormatListRight.Select(o => o.MovieFormatId);

                    if (textBoxMovieSessionMovieFormatSearch.Text == "")
                        foreach (var item in database.MovieFormat.Where(o => !rightItems.Contains(o.MovieFormatId)).OrderBy(o => o.MovieFormatName).ToList()) _movieSessionMovieFormatListLeft.Add(item);
                    else
                        foreach (var item in database.MovieFormat.Where(o => !rightItems.Contains(o.MovieFormatId) && (o.MovieFormatName.Contains(textBoxMovieSessionMovieFormatSearch.Text) || o.MovieFormatName.Contains(textBoxMovieSessionMovieFormatSearch.Text))).OrderBy(o => o.MovieFormatName).ToList()) _movieSessionMovieFormatListLeft.Add(item);

                    //cmbSaloons.SelectedItem = database.MovieTheatrePlace.Where(o => o.MovieTheatrePlaceId == SelectedMovieSession.MovieTheatrePlaceId).FirstOrDefault();
                    //cmbSaloons.SelectedItem = _movieTheatrePlace.Where(o => o.MovieTheatrePlaceId == SelectedMovieSession.MovieTheatrePlaceId).FirstOrDefault();

                    //database.MovieTheatrePlace.Where(o => o.MovieTheatrePlaceId == movieSession.MovieTheatrePlaceId).FirstOrDefault();
                    //((MovieTheatrePlace)cmbSaloons.SelectedItem).MovieTheatrePlaceId = movieSession.MovieTheatrePlaceId; 
                    //((MovieTheatrePlace) movieSession.MovieTheatrePlaceId;
                }




                if (selectedId != null) { listBoxMovieSessionMovieFormatLeft.ClearSelected(); listBoxMovieSessionMovieFormatLeft.SelectedItem = _movieSessionMovieFormatListLeft.FirstOrDefault(o => o.MovieFormatId == selectedId); }

                CreateSessionTemplate();


            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
        private void RefreshUserList(int? selectedId = null)
        {
            if (selectedId == null && IsUpdateMode) selectedId = SelectedMovie.MovieId;
            try
            {
                _userList.Clear();
                using (var database = CineBookEntitiesExt.New())
                {
                    if (textBoxUserSearch.Text == "")
                        foreach (var item in database.User.ToList()) _userList.Add(item);
                    else
                        foreach (var item in database.User.Where(o => o.UserCode.Contains(textBoxUserSearch.Text) || o.UserName.Contains(textBoxUserSearch.Text)).ToList()) _userList.Add(item);
                }
                if (selectedId != null) { foreach (DataGridViewRow row in dataGridViewUser.Rows) { var item = row.DataBoundItem as User; if (item == null || item.UserId != selectedId) continue; row.Selected = true; break; } }
            }
            catch (Exception)
            {
            }
        }
        private void RefreshDesignViewer()
        {
            try
            {
                reportViewerDesign.ReportSource = null;
                using (var database = CineBookEntitiesExt.New())
                {
                    var template = database.PrinterTemplate.FirstOrDefault(o => o.TemplateName == "Ticket");
                    if (template != null && template.TemplateContent != null)
                    {
                        var source = new XmlReportSource();
                        source.Xml = template.TemplateContent;
                        reportViewerDesign.ReportSource = source;
                    }
                }
            }
            catch (Exception)
            {
            }
            reportViewerDesign.RefreshReport();
        }
        private void ClearAllFields()
        {
            textBoxMovieTitle.Text = "";
            textBoxMovieDescription.Text = "";
            numericUpDownMovieDuration.Value = 90;
            dateTimePickerMovieReleaseDate.Value = DateTime.Now.Date;
            textBoxMovieSummary.Text = "";
            textBoxMovieStory.Text = "";
            pictureBoxMoviePosterPreview.Image = null;
            pictureBoxMoviePosterOriginal.Image = null;
            _movieTypeListLeft.Clear();
            _movieTypeListRight.Clear();
            _movieFormatListLeft.Clear();
            _movieFormatListRight.Clear();
            _movieDirectorListLeft.Clear();
            _movieDirectorListRight.Clear();
            _movieCastListLeft.Clear();
            _movieCastListRight.Clear();
            _movieCategoryListLeft.Clear();
            _movieCategoryListRight.Clear();
            _movieSessionMovieFormatListLeft.Clear();
            _movieSessionMovieFormatListRight.Clear();
        }
        private void GeneralCheck()
        {
            toolStripLabelMovieStatus.Text = IsInsertMode ? StringConsts.Status_InsertMode : StringConsts.Status_UpdateMode;
            buttonMovieUpdatePosterPreview.Enabled = IsUpdateMode;
            buttonMovieUpdatePosterOriginal.Enabled = IsUpdateMode;
            buttonMovieDetailsDelete.Enabled = IsUpdateMode;
            buttonMovieDetailsNew.Enabled = IsUpdateMode;
            tabPageMovieType.Enabled = IsUpdateMode;
            tabPageMovieFormat.Enabled = IsUpdateMode;
            tabPageMovieDirector.Enabled = IsUpdateMode;
            tabPageMovieCast.Enabled = IsUpdateMode;
            tabPageMovieCategory.Enabled = IsUpdateMode;
            tabPageMovieSession.Enabled = IsUpdateMode;
            buttonMovieTypeLeft.Enabled = _movieTypeListRight.Any();
            buttonMovieTypeRight.Enabled = _movieTypeListLeft.Any();
            buttonMovieFormatLeft.Enabled = _movieFormatListRight.Any();
            buttonMovieFormatRight.Enabled = _movieFormatListLeft.Any();
            buttonMovieDirectorLeft.Enabled = _movieDirectorListRight.Any();
            buttonMovieDirectorRight.Enabled = _movieDirectorListLeft.Any();
            buttonMovieCastLeft.Enabled = _movieCastListRight.Any();
            buttonMovieCastRight.Enabled = _movieCastListLeft.Any();
            buttonMovieCategoryLeft.Enabled = _movieCategoryListRight.Any();
            buttonMovieCategoryRight.Enabled = _movieCategoryListLeft.Any();
            groupBoxMovieSessionMovieFormat.Enabled = SelectedMovieSession != null;
            buttonMovieSessionMovieFormatLeft.Enabled = _movieSessionMovieFormatListRight.Any();
            buttonMovieSessionMovieFormatRight.Enabled = _movieSessionMovieFormatListLeft.Any();
        }
        private void RefreshResources()
        {
            Text = StringConsts.MovieForm_Title;
            labelMovieSearch.Text = StringConsts.MovieForm_Search;
            tabPageMovie.Text = StringConsts.MovieForm_MovieDetail;
            tabPageMovieType.Text = StringConsts.MovieForm_MovieType;
            buttonMovieDetailsNew.Text = StringConsts.Menu_New;
            buttonMovieDetailsSave.Text = StringConsts.Menu_Save;
            buttonMovieDetailsDelete.Text = StringConsts.Menu_Delete;
            buttonMovieDetailsRefresh.Text = StringConsts.Menu_Refresh;

            menuMovieTypeRefresh.Text = StringConsts.Menu_Refresh;
            menuMovieTypeNew.Text = StringConsts.Menu_New;
            menuMovieTypeEdit.Text = StringConsts.Menu_Edit;
            menuMovieTypeDelete.Text = StringConsts.Menu_Delete;

        }

        #endregion

        #region MovieSession
        private void dataGridViewMovieSession_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewMovieSession.Rows[e.RowIndex].DataBoundItem != null && dataGridViewMovieSession.Columns[e.ColumnIndex].DataPropertyName.Contains("."))
                e.Value = StaticClass.BindProperty(dataGridViewMovieSession.Rows[e.RowIndex].DataBoundItem, dataGridViewMovieSession.Columns[e.ColumnIndex].DataPropertyName);
            var session = dataGridViewMovieSession.Rows[e.RowIndex].DataBoundItem as MovieSession;
            if (session != null)
            {

            }
        }
        private void dataGridViewMovieSession_SelectionChanged(object sender, EventArgs e)
        {
            RefreshMovieSessionMovieFormatList();
            GeneralCheck();
        }
        private void dataGridViewMovieSession_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemDeleted) return;

            var red = dataGridViewMovieSession.DefaultCellStyle.Clone();
            //red.BackColor = System.Drawing.Color.LightCoral;
            red.ForeColor = Color.Red;
            //red.Font = new Font(red.Font, FontStyle.Bold);

            foreach (DataGridViewRow row in dataGridViewMovieSession.Rows)
            {
                var item = row.DataBoundItem as MovieSession;
                if (item == null) return;
                if (item.MovieSessionAmount.Count == 0) row.DefaultCellStyle = red;
            }
        }
        private void dataGridViewMovieSession_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) dataGridViewMovieSession.ClearSelection();
        }
        private void textBoxMovieSessionMovieFormatSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshMovieSessionMovieFormatList();
        }
        private void buttonSessionTimePrev_Click(object sender, EventArgs e)
        {
            datePickerMovieSession.Value = datePickerMovieSession.Value.AddDays(-1);
            RefreshMovieSessionList();
            GeneralCheck();
        }
        private void buttonSessionTimeNext_Click(object sender, EventArgs e)
        {
            datePickerMovieSession.Value = datePickerMovieSession.Value.AddDays(1);
            RefreshMovieSessionList();
            GeneralCheck();
        }
        private void datePickerMovieSession_ValueChanged(object sender, EventArgs e)
        {
            RefreshMovieSessionList();
            GeneralCheck();
        }
        private void menuMovieSession_Opening(object sender, CancelEventArgs e)
        {
            menuMovieSessionEdit.Visible = SelectedMovieSession != null;
            menuMovieSessionDelete.Visible = SelectedMovieSession != null;
            menuMovieSessionSeparator1.Visible = SelectedMovieSession != null;
            menuMovieSessionAmount.Visible = SelectedMovieSession != null;
            menuMovieSessionSaveAs.Visible = SelectedMovieSession != null;
        }
        private void menuMovieSessionRefresh_Click(object sender, EventArgs e)
        {
            RefreshMovieSessionList();
            GeneralCheck();
        }
        private void menuMovieSessionNew_Click(object sender, EventArgs e)
        {
            var entity = new MovieSession { MovieId = SelectedMovie.MovieId, SessionTime = datePickerMovieSession.Value.Date.AddHours(12) };
        Retry:
            if (!MovieSessionEditForm.ShowForm(entity)) return;
            using (var database = CineBookEntitiesExt.New())
            {
                if (database.MovieSession.Any(o => o.MovieTheatrePlaceId == entity.MovieTheatrePlaceId && o.SessionTime == entity.SessionTime)) { StaticClass.ShowWarning(StringConsts.Thesameitemalreadyexists); goto Retry; }
                database.MovieSession.Add(entity);
                database.SaveChanges();
                RefreshMovieSessionList(entity.MovieSessionId);
                GeneralCheck();
            }
        }
        private void menuMovieSessionEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewMovieSession.SelectedRows.Count == 0) return;
            var item = dataGridViewMovieSession.SelectedRows[0].DataBoundItem as MovieSession;
            if (item == null) return;
            Retry:
            if (!MovieSessionEditForm.ShowForm(item)) { RefreshMovieSessionList(item.MovieSessionId); return; }
            using (var database = CineBookEntitiesExt.New())
            {
                if (database.MovieSession.Any(o => o.MovieTheatrePlaceId == item.MovieTheatrePlaceId && o.SessionTime == item.SessionTime && o.MovieSessionId != item.MovieSessionId)) { StaticClass.ShowWarning(StringConsts.Thesameitemalreadyexists); goto Retry; }
                var entity = database.MovieSession.Single(o => o.MovieSessionId == item.MovieSessionId);
                entity.MovieTheatrePlaceId = item.MovieTheatrePlaceId;
                entity.SessionTime = item.SessionTime;
                database.SaveChanges();
                RefreshMovieSessionList(entity.MovieSessionId);
                GeneralCheck();
            }
        }
        private void menuMovieSessionDelete_Click(object sender, EventArgs e)
        {
            if (!IsUpdateMode) return;
            if (dataGridViewMovieSession.SelectedRows.Count == 0) return;
            var item = dataGridViewMovieSession.SelectedRows[0].DataBoundItem as MovieSession;
            if (item == null) return;
            try
            {
                using (var database = CineBookEntitiesExt.New(true, true))
                {
                    var entity = database.MovieSession.Single(o => o.MovieSessionId == item.MovieSessionId);
                    //if (entity.MovieSession_MovieFormat.Count > 0) { StaticClass.ShowWarning(StringConsts.ThisrecordisbeingusedbyanotherrecordYoucannotdeletethisrecord); return; }
                    //if (entity.MovieSessionAmount.Count > 0) { StaticClass.ShowWarning(StringConsts.ThisrecordisbeingusedbyanotherrecordYoucannotdeletethisrecord); return; }
                    if (entity.MovieSessionReservation.Count > 0) { StaticClass.ShowWarning(StringConsts.ThisrecordisbeingusedbyanotherrecordYoucannotdeletethisrecord); return; }
                    if (entity.MovieTicketSale.Count > 0) { StaticClass.ShowWarning(StringConsts.ThisrecordisbeingusedbyanotherrecordYoucannotdeletethisrecord); return; }
                    if (!StaticClass.ShowQuestion()) return;
                    foreach (var rmitem in database.MovieSession_MovieFormat.Where(o => o.MovieSessionId == entity.MovieSessionId)) database.MovieSession_MovieFormat.Remove(rmitem);
                    foreach (var rmitem in database.MovieSessionAmount.Where(o => o.MovieSessionId == entity.MovieSessionId)) database.MovieSessionAmount.Remove(rmitem);
                    database.MovieSession.Remove(entity);
                    database.SaveChanges();
                    RefreshMovieSessionList();
                    GeneralCheck();
                }
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void buttonMovieSessionMovieFormatRight_Click(object sender, EventArgs e)
        {
            var items = listBoxMovieSessionMovieFormatLeft.SelectedItems.Cast<MovieFormat>().ToArray();
            if (!items.Any()) return;
            if (SelectedMovieSession == null) return;
            try
            {
                using (var database = CineBookEntitiesExt.New())
                {
                    foreach (var item in items)
                    {
                        var entity = new MovieSession_MovieFormat { MovieSessionId = SelectedMovieSession.MovieSessionId, MovieFormatId = item.MovieFormatId };
                        database.MovieSession_MovieFormat.Add(entity);
                        MessageBox.Show(entity.Id.ToString());
                    }
                    database.SaveChanges();
                }
                RefreshMovieSessionMovieFormatList();
                GeneralCheck();
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void buttonMovieSessionMovieFormatLeft_Click(object sender, EventArgs e)
        {
            var items = listBoxMovieSessionMovieFormatRight.SelectedItems.Cast<MovieFormat>().Select(o => o.MovieFormatId).ToArray();
            if (!items.Any()) return;
            if (SelectedMovieSession == null) return;
            try
            {
                using (var database = CineBookEntitiesExt.New())
                {
                    foreach (var entity in database.MovieSession_MovieFormat.Where(o => o.MovieSessionId == SelectedMovieSession.MovieSessionId && items.Contains(o.MovieFormatId))) database.MovieSession_MovieFormat.Remove(entity);
                    database.SaveChanges();
                }
                RefreshMovieSessionMovieFormatList();
                GeneralCheck();
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }
        private void menuMovieSessionAmount_Click(object sender, EventArgs e)
        {
            if (dataGridViewMovieSession.SelectedRows.Count == 0) return;
            var item = dataGridViewMovieSession.SelectedRows[0].DataBoundItem as MovieSession;
            if (item == null) return;
            MovieAmountEditForm.ShowForm(item, true, null);
            RefreshMovieSessionList(SelectedMovieSession?.MovieSessionId);
            //GetSessionTemplate();

        }
        private void menuMovieSessionSaveAs_Click(object sender, EventArgs e)
        {
            if (dataGridViewMovieSession.SelectedRows.Count == 0) return;
            var item = dataGridViewMovieSession.SelectedRows[0].DataBoundItem as MovieSession;
            if (item == null) return;
            MovieSessionSaveAsForm.ShowForm(item);
        }






        #endregion


        protected void getNames()
        {
            var c = StaticClass.GetAll(this);
            foreach (var item in c) StaticClass.ChangeNames(item);

        }

        private int SeatWidth = 30;
        private int SeatHeight = 25;
        private float SeatFontSize = 7;

        //EventArgs
        private void SeatItem_OnClick(object sender, MouseEventArgs eventArgs)
        {

            var item = (SeatItem)sender;
            //if (item.Detail.SeatCode == null)
            //{ item.ContextMenuStrip = null; menuSeats.Visible = false; return; }
            //else
            //{ item.ContextMenuStrip = menuSeats; menuSeats.Visible = true; }
            bool isAllVip = true;
            using (var entities = new CineBookEntities())
            {
                if (item.Detail.SeatCode == null)
                {
                    var placeTemplate = entities.MovieTheatrePlaceTemplate.Where(o => o.MovieTheatrePlaceTemplateId == SelectedMovieSession.MovieTheatrePlace.MovieTheatrePlaceTemplateId).FirstOrDefault();
                    var movieTheatrePlaceTemplateDetails = placeTemplate.MovieTheatrePlaceTemplateDetails.Where(o => o.MovieTheatrePlaceTemplateId == SelectedMovieSession.MovieTheatrePlace.MovieTheatrePlaceTemplateId && o.RowIndex == item.Detail.RowIndex);

                    foreach (var item2 in movieTheatrePlaceTemplateDetails)
                        if (item2.MovieSeatTypeId != 7 && item2.SeatCode != null) { isAllVip = false; break; }

                }
                else { if (item.Detail.MovieSeatTypeId!=7) isAllVip = false; }
            }

            if (isAllVip) { toolStripMenuItem2.Visible = true; toolStripSeparator2.Visible = true; }
            else
            { toolStripMenuItem2.Visible = false; toolStripSeparator2.Visible = false; }

            standardSeatToolStripMenuItem.Checked = false;
            disabledSeatToolStripMenuItem.Checked = false;
            doubleSeatToolStripMenuItem.Checked = false;
            vIPToolStripMenuItem.Checked = false;
            if (eventArgs.Button == MouseButtons.Right)
            {
                //item.Font.Size=
                _seatItem = item;
                if (item.Detail.MovieSeatType.MovieSeatTypeName == "Standard Koltuk")
                    standardSeatToolStripMenuItem.Checked = true;
                else if (item.Detail.MovieSeatType.MovieSeatTypeName == "Engelli Koltuğu")
                    disabledSeatToolStripMenuItem.Checked = true;
                else if (item.Detail.MovieSeatType.MovieSeatTypeName == "İkili Koltuk")
                    doubleSeatToolStripMenuItem.Checked = true;
                else if (item.Detail.MovieSeatType.MovieSeatTypeName == "VIP")
                    vIPToolStripMenuItem.Checked = true;
            }
            else
            { item.ContextMenuStrip = null; menuSeats.Visible = false; return; }
            //disabled.Checked = true;
            //if (item.Status != SeatItem.SeatStatus.Available && item.Status != SeatItem.SeatStatus.Reserving) return;
            //if (string.IsNullOrEmpty(item.Detail.SeatCode)) return;
            //item.Enabled = false;
            //using (var entities = new CinemaBookingEntities())
            //{
            //    var reservation = entities.GetMyReservations(_movieSessionId).FirstOrDefault(o => o.SeatCode == item.Detail.SeatCode);
            //    if (reservation == null)
            //    {
            //        reservation = new MovieSessionReservation { MovieSeatTypeId = item.Detail.MovieSeatTypeId, SeatPrefix = item.Detail.Prefix, SeatSuffix = item.Detail.Suffix, SeatCode = item.Detail.SeatCode, MovieSessionId = _movieSessionId, LastUpdate = entities.GetDate(), UserId = LoginUser.LoggedUserId, SessionId = LoginUser.SessionId };
            //        entities.MovieSessionReservation.Add(reservation);
            //    }
            //    else
            //    {
            //        entities.MovieSessionReservation.Remove(reservation);
            //    }
            //    entities.SaveChanges();
            //}
        }

        void ChangeSeatType(int seatTypeId)
        {
            using (var entities = new CineBookEntities())
            {
                var placeTemplate = entities.MovieTheatrePlaceTemplate.Where(o => o.MovieTheatrePlaceTemplateId == SelectedMovieSession.MovieTheatrePlace.MovieTheatrePlaceTemplateId).FirstOrDefault();
                
                var movieTheatrePlaceTemplateDetails = placeTemplate.MovieTheatrePlaceTemplateDetails.Where(o => o.Id == _seatItem.Detail.Id && o.Block== tabSession.SelectedIndex).FirstOrDefault();



                //MessageBox.Show(.ToString());
                if (movieTheatrePlaceTemplateDetails.SeatCode == null)
                {
                    var movieTheatrePlaceTemplateDetailsNew = placeTemplate.MovieTheatrePlaceTemplateDetails.Where(o => o.Prefix == movieTheatrePlaceTemplateDetails.Prefix && o.Block == tabSession.SelectedIndex);


                    foreach (var item in movieTheatrePlaceTemplateDetailsNew)
                    {
                        //if (item.MovieTheatrePlaceTemplate.Block>0)
                        if (item.SeatCode != null)
                        {
                            if (seatTypeId!=7)
                            {
                                foreach (var entity in entities.MovieSessionAmount.Where(o => o.MovieTheatrePlaceTemplateDetailsId == item.Id))
                                    entities.MovieSessionAmount.Remove(entity);                                
                            }

                            item.MovieSeatTypeId = seatTypeId;
                            var itemNew = dataGridViewMovieSession.SelectedRows[0].DataBoundItem as MovieSession; if (itemNew == null) return;
                            var _amount = entities.MovieSessionAmount.Where(o => o.MovieSessionId == itemNew.MovieSessionId && o.MovieTheatrePlaceTemplateDetailsId == item.Id).FirstOrDefault();
                            if (_amount != null)
                            {
                                _amount.MovieTheatrePlaceTemplateDetailsId = null;
                                var _amountNew = entities.MovieSessionAmount.Where(o => o.MovieSessionId == itemNew.MovieSessionId && o.MovieSeatTypeId == seatTypeId).FirstOrDefault();
                                if (_amountNew!=null)
                                _amount.Amount = _amountNew.Amount;
                            }
                        }
                    }

                }
                else
                {

                    movieTheatrePlaceTemplateDetails.MovieSeatTypeId = seatTypeId;
                    var item = dataGridViewMovieSession.SelectedRows[0].DataBoundItem as MovieSession; if (item == null) return;
                    var _amount = entities.MovieSessionAmount.Where(o => o.MovieSessionId == item.MovieSessionId && o.MovieTheatrePlaceTemplateDetailsId == movieTheatrePlaceTemplateDetails.Id).FirstOrDefault();
                    if (_amount != null)
                    {
                        _amount.MovieTheatrePlaceTemplateDetailsId = null;
                        var _amountNew = entities.MovieSessionAmount.Where(o => o.MovieSessionId == item.MovieSessionId && o.MovieSeatTypeId == seatTypeId).FirstOrDefault();
                        _amount.Amount = _amountNew.Amount;
                    }
                }
                entities.SaveChanges();

            }

            
        }


        private void standardSeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSeatType(4);
            GetSessionTemplate();

        }

        private void disabledSeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSeatType(5);
            GetSessionTemplate();
        }

        private void doubleSeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSeatType(6);
            GetSessionTemplate();
        }

        private void vIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSeatType(7);
            GetSessionTemplate();

            //using (var entities = new CineBookEntities())
            //{
            //    var placeTemplate = entities.MovieTheatrePlaceTemplate.Where(o => o.MovieTheatrePlaceTemplateId == SelectedMovieSession.MovieTheatrePlace.MovieTheatrePlaceTemplateId).FirstOrDefault();
            //    var aa = placeTemplate.MovieTheatrePlaceTemplateDetails.Where(o => o.Id == _seatItem.Detail.Id).FirstOrDefault();
            //    if (aa.SeatCode==null)
            //    {
            //        var bb = placeTemplate.MovieTheatrePlaceTemplateDetails.Where(o => o.Prefix== aa.Prefix);
            //        foreach (var item in bb)
            //            if (item.SeatCode!=null) item.MovieSeatTypeId = 7;
            //    }
            //    else
            //    aa.MovieSeatTypeId = 7;

            //    entities.SaveChanges();
            //}
            //GetSessionTemplate();
        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dataGridViewMovieSession.SelectedRows.Count == 0) return;
            var item = dataGridViewMovieSession.SelectedRows[0].DataBoundItem as MovieSession;
            if (item == null) return;
            MovieAmountEditForm.ShowForm(item, true, _seatItem);
            //RefreshMovieSessionList(SelectedMovieSession?.MovieSessionId);
            GetSessionTemplate();
        }


        private int _seatWidth = 30;
        private int _seatHeight = 25;
        private float _seatFontSize = 7;

        private void SetSizes(float value)
        {
            _seatWidth = (int)(30 + value * 7);
            _seatHeight = (int)(35 + value * 7);
            _seatFontSize = (int)(8 + value * 2.5);

        }




        int[] tempRow = new int[100];
        int[] tempCols = new int[100];
        //TempColumns tempColumns1 = new TempColumns();
        int[,,] tempColumns = new int[100, 100, 100];
        string[,] tempColumnsNames = new string[100, 100];

        List<MovieTheatrePlaceTemplateDetails> list;
        Dictionary<int, List<MovieTheatrePlaceTemplateDetails>> dList;


        public string GetAlphabets(int say)
        {
            say = say + 64;
            string strAlpha = string.Empty;
            strAlpha = ((char)say).ToString();
            return strAlpha;

        }

        private void SeatItemC_OnClick(object sender, MouseEventArgs eventArgs)
        {
            var item = (SeatItem)sender;
            if (eventArgs.Button == MouseButtons.Right)
            {
                _seatItem = item;
            }
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (tempRow[tabSaloon.SelectedIndex] > 1)
            {
                for (int j = 0; j < 100; j++)
                {
                    tempColumns[tabSaloon.SelectedIndex, tempRow[tabSaloon.SelectedIndex] - 1, j] = 0;
                }

                tempRow[tabSaloon.SelectedIndex]--;
                int say = 1;
                for (int i = 0; i < 100; i++)
                {
                    if (tempColumns[tabSaloon.SelectedIndex, _seatItem.Detail.RowIndex, i] != 0) say++;
                }

                getTemplate(tempRow[tabSaloon.SelectedIndex], 4, false);
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //SetSizes(4);
            try
            {
                for (int k = 0; k < 10; k++)
                {
                    int say = 1;
                    for (int i = 0; i < 100; i++)
                    {
                        if (tempColumns[tabSaloon.SelectedIndex, _seatItem.Detail.RowIndex, i] != 0) say++;
                    }

                    if (tempCols[tabSaloon.SelectedIndex] < say) tempCols[tabSaloon.SelectedIndex] = say;
                    getTemplate(tempRow[tabSaloon.SelectedIndex], 4, false);
                }

            }
            catch { }


        }

        private void toolStripDeleteRow_Click(object sender, EventArgs e)
        {
            if (tempRow[tabSaloon.SelectedIndex] > 1)
            {
                for (int j = 0; j < 100; j++)
                {
                    tempColumns[tabSaloon.SelectedIndex, _seatItem.Detail.RowIndex, j] = 0;
                }




                int activeRowLength = _seatItem.Detail.RowIndex;
                while (tempRow[tabSaloon.SelectedIndex] - 1 >= activeRowLength)
                {
                    activeRowLength++;
                    for (int j = 0; j < 100; j++)
                    {
                        tempColumns[tabSaloon.SelectedIndex, activeRowLength - 1, j] = 0;
                        tempColumns[tabSaloon.SelectedIndex, activeRowLength - 1, j] = tempColumns[tabSaloon.SelectedIndex, activeRowLength, j];
                    }


                }

                //for (int j = 0; j < 100; j++)
                //    tempColumns[activeRowLength, j] = 0;

                tempRow[tabSaloon.SelectedIndex]--;
                //int say = 1;
                //for (int i = 0; i < 100; i++)
                //{
                //    if (tempColumns[_seatItem.Detail.RowIndex, i] != 0) say++;
                //}

                getTemplate(tempRow[tabSaloon.SelectedIndex], 4, false);
            }



        }


        private void toolStripMenuCreateSeatDelete_Click(object sender, EventArgs e)
        {
            tempColumns[tabSaloon.SelectedIndex, _seatItem.Detail.RowIndex, Convert.ToInt32(_seatItem.Detail.ColumnIndex) + 1] = 0;

            //int say = 1;
            //for (int i = 0; i < 100; i++)
            //    if (tempColumns[_seatItem.Detail.RowIndex, i] != 0) say++;

            //if (tempCols[tabSaloon.SelectedIndex]> say) tempCols[tabSaloon.SelectedIndex]= say;

            btnRefresh_Click(null, null);

        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripSaloon.SelectedIndex == 6)
            {
                dList = new Dictionary<int, List<MovieTheatrePlaceTemplateDetails>>();
                for (int i = 0; i < 100; i++)
                    tempRow[i] = 2;
                chkBlock.Checked = false;
                btnClear_Click(null, null);
            }

            if (toolStripSaloon.SelectedIndex == 7)
            {
                //using (var database = new CineBookEntities())
                //{

                //    var placeTemplate = database.MovieTheatrePlaceTemplate.Where(o => o.MovieTheatrePlaceTemplateId == SelectedMovieSession.MovieTheatrePlace.MovieTheatrePlaceTemplateId).FirstOrDefault();
                //    TableLayoutPanel tblSessionDetail = this.Controls.Find("tblSessionDetail" + tabSession.SelectedIndex.ToString(), true).FirstOrDefault() as TableLayoutPanel;
                //    tblSessionDetail.Controls.Clear();
                //}

                //MessageBox.Show(dataGridViewMovieSession.RowCount.ToString());
                
                RefresMovieTheatrePlaceList();
                cmbTemp.SelectedIndex = -1;
                
                RefreshMovieSessionList();
                GetSessionTemplate();
                panel2.Controls.Clear();
                tabSession.SelectedIndex = -1;
            }

        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            //var items = listBoxMovieTypeLeft.SelectedItems.Cast<MovieType>().ToArray();
            //if (!items.Any()) return;
            try
            {
                using (var database = CineBookEntitiesExt.New())
                {

                    //MovieTheatrePlaceTemplate

                    foreach (var entity in database.MovieTheatrePlaceTemplate.Where(o => o.Description == "Deneme"))
                        database.MovieTheatrePlaceTemplate.Remove(entity);


                    foreach (var entity in database.MovieTheatrePlaceTemplateDetails.Where(o => o.MovieTheatrePlaceTemplate.Description == "Deneme"))
                        database.MovieTheatrePlaceTemplateDetails.Remove(entity);

                    foreach (var entity in database.MovieSessionReservation.Where(o => o.MovieSession.MovieTheatrePlace.MovieTheatrePlaceTemplate.Description == "Deneme"))
                        database.MovieSessionReservation.Remove(entity);


                    foreach (var entity in database.MovieSessionAmount.Where(o => o.MovieSession.MovieTheatrePlace.MovieTheatrePlaceTemplate.Description == "Deneme"))
                        database.MovieSessionAmount.Remove(entity);


                    foreach (var entity in database.MovieSession.Where(o => o.MovieTheatrePlace.MovieTheatrePlaceTemplate.Description == "Deneme"))
                        database.MovieSession.Remove(entity);

                    foreach (var entity in database.MovieTheatrePlace.Where(o => o.MovieTheatrePlaceTemplate.Description == "Deneme"))
                        database.MovieTheatrePlace.Remove(entity);

                    foreach (var entity in database.MovieTheatrePlaceTemplate.Where(o => o.Description == "Deneme"))
                        database.MovieTheatrePlaceTemplate.Remove(entity);
                    database.SaveChanges();


                    MovieTheatrePlaceTemplate temp = new MovieTheatrePlaceTemplate();
                    temp.Description = "Deneme";
                    temp.Block = dList.Count;
                    database.MovieTheatrePlaceTemplate.Add(temp);
                    database.SaveChanges();

                    foreach (var key in dList.Keys)
                    {
                        var value1 = dList[key];
                        foreach (var item in value1)
                        {
                            MovieTheatrePlaceTemplateDetails nItem = new MovieTheatrePlaceTemplateDetails();
                            nItem.MovieTheatrePlaceTemplateId = temp.MovieTheatrePlaceTemplateId;
                            nItem.RowIndex = item.RowIndex;
                            nItem.ColumnIndex = item.ColumnIndex;
                            nItem.Prefix = item.Prefix;
                            nItem.Suffix = item.Suffix;
                            nItem.SeatCode = item.SeatCode;
                            nItem.MovieSeatTypeId = item.MovieSeatTypeId;
                            nItem.Block = key;
                            database.MovieTheatrePlaceTemplateDetails.Add(nItem);
                            database.SaveChanges();
                        }
                    }

                    MovieTheatrePlace place = new MovieTheatrePlace();
                    place.MovieTheaterId = 1;
                    place.MovieTheatrePlaceName = "Deneme";
                    place.SgmSaloonFormat = "IMAX";
                    place.MovieTheatrePlaceTemplateId = temp.MovieTheatrePlaceTemplateId;
                    database.MovieTheatrePlace.Add(place);
                    database.SaveChanges();


                }
                //RefreshMovieTypeList();
                //GeneralCheck();
            }
            catch (Exception exception)
            {
                StaticClass.ShowError(exception.ToString());
            }
        }


        private void getTemplateFromDb()
        {

            //if (cmbSaloons.SelectedItem == null) return;

            int _seatWidth = (int)(30 + 3 * 1);
            int _seatHeight = (int)(35 + 3 * 1);
            int _seatFontSize = (int)(8 + 1 * 2.5);

            //if (dataGridViewMovieSession.SelectedRows.Count == 0) return;
            //var itemSession = dataGridViewMovieSession.SelectedRows[0].DataBoundItem as MovieSession;
            foreach (Control c in this.tabSaloon.Controls)
            {
                TableLayoutPanel tblSaloonDetail = new TableLayoutPanel();

                tblSaloonDetail.Visible = false;
                tblSaloonDetail.ColumnStyles.Clear();
                tblSaloonDetail.RowStyles.Clear();
                tblSaloonDetail.Controls.Clear();
                tblSaloonDetail.Visible = true;
                using (var database = new CineBookEntities())
                {

                    var placeTemplate = database.MovieTheatrePlaceTemplate.Where(o => o.MovieTheatrePlaceTemplateId == ((MovieTheatrePlaceTemplate)cmbTemp.SelectedItem).MovieTheatrePlaceTemplateId).FirstOrDefault();

                    var details = placeTemplate.MovieTheatrePlaceTemplateDetails.ToArray();
                    //var details = placeTemplate.MovieTheatrePlaceTemplateDetails.Where(o => o.MovieTheatrePlaceTemplateId == placeTemplate.MovieTheatrePlaceTemplateId).ToArray();
                    //var details = database.MovieTheatrePlaceTemplateDetails.Where(o => o.MovieTheatrePlaceTemplateId == ((MovieTheatrePlace)cmbSaloons.SelectedItem).MovieTheatrePlaceTemplateId).ToArray();

                    var ColumnCount = details.Max(item => item.ColumnIndex) + 1;
                    var RowCount = details.Max(item => item.RowIndex) + 1;

                    tblSaloonDetail.ColumnCount = ColumnCount + 1;
                    for (var i = 0; i < ColumnCount; i++) tblSaloonDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _seatWidth));

                    tblSaloonDetail.RowCount = RowCount + 1;
                    for (var i = 0; i < RowCount; i++) tblSaloonDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, _seatHeight));

                    tblSaloonDetail.SuspendLayout();
                    foreach (var item in details)
                    {
                        var detail = details.FirstOrDefault(o => o.Id == item.Id);
                        var button = new SeatItem(detail, null) { Font = new Font("Arial Narrow", 7, FontStyle.Bold) };
                        button.Status = SeatItem.SeatStatus.Available;
                        button.SetBorder();
                        button.ContextMenuStrip = menuSeats;
                        button.MouseDown += SeatItem_OnClick;
                        tblSaloonDetail.Controls.Add(button, item.ColumnIndex, item.RowIndex);
                    }

                    // Separator Control
                    for (var i = 0; i < ColumnCount; i++)
                    {
                        var separator = true;
                        foreach (var item in details.Where(o => o.ColumnIndex == i)) { if ((item.MovieSeatTypeId > 3) || (item.MovieSeatTypeId <= 3 && !string.IsNullOrEmpty(item.Prefix))) { separator = false; } }
                        if (separator) tblSaloonDetail.ColumnStyles[i].Width = (int)(_seatWidth / 5d);
                    }



                    tblSaloonDetail.ResumeLayout(true);
                }
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (cmbTemp.SelectedIndex > -1)
                getTemplateFromDb();
        }

        private void toolStripAddHall_Click(object sender, EventArgs e)
        {

            tempRow[tabSaloon.SelectedIndex]++;
            int say = 1;
            for (int i = 0; i < 100; i++)
                if (tempColumns[tabSaloon.SelectedIndex, tempRow[tabSaloon.SelectedIndex], i] != 0) say++;
            int rowFirst = 0;
            if (_seatItem == null) rowFirst = 1; else rowFirst = _seatItem.Detail.RowIndex;
            getTemplate(tempRow[tabSaloon.SelectedIndex], 1, true);

        }

        private void menuSaloonCreate_Opening(object sender, CancelEventArgs e)
        {
            //MessageBox.Show(_seatItem.Detail.RowIndex.ToString());
            //if (tempRow[tabSaloon.SelectedIndex]!=0)
            TableLayoutPanel tblSaloonDetail = this.Controls.Find("tblSaloonDetail" + tabSaloon.SelectedIndex.ToString(), true).FirstOrDefault() as TableLayoutPanel;
            if (tblSaloonDetail == null) return;

            //TableLayoutPanel tblSaloonDetail = new TableLayoutPanel();

            for (int i = 0; i < tempRow[tabSaloon.SelectedIndex] - 1; i++)
                tblSaloonDetail.GetControlFromPosition(0, i + 1).BackColor = ColorTranslator.FromHtml("#666666");

            tblSaloonDetail.GetControlFromPosition(0, _seatItem.Detail.RowIndex).BackColor = Color.Red;

        }

        private void tblSaloonDetail_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            //if ((e.Column + e.Row) % 2 == 1)
            //    e.Graphics.FillRectangle(Brushes.Black, e.CellBounds);
            //else
            //    e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
        }

        private void chkBlock_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBlock.Checked)
            {
                txtBlockCount.Value = 3;
                tabSaloon.ImageList = imageList1;
                //this.tabSaloon.Size = new System.Drawing.Size(834, 274);
                //pnlBlock.Visible = true;
                txtBlockCount.Visible = true;
                //txtBlockCount.Controls[0].Visible = true;
                //txtBlockCount.Controls[1].Visible = true;
                txtBlockCount_ValueChanged(null, null);
            }
            else
            {

                txtBlockCount.Value = 0;
                //this.tabSaloon.Size = new System.Drawing.Size(834, 0);
                txtBlockCount.Visible = false;
                tabSaloon.Controls.Clear();
                TabPage tabpage = new TabPage();
                TableLayoutPanel tlp1 = new TableLayoutPanel();
                tlp1.Dock = System.Windows.Forms.DockStyle.Fill;
                tlp1.Name = "tblSaloonDetail" + 0.ToString();
                tabpage.Text = "1";
                tabpage.Controls.Add(tlp1);
                tabSaloon.Controls.Add(tabpage);
                tabSaloon.ImageList = null;
                tabSaloon.Size = new System.Drawing.Size(834, 0);
                getTemplate(2, 4, false);


            }


        }

        void AddSep(int count)
        {
            for (int k = 0; k < count; k++)
            {
                int say = 1;
                for (int i = 0; i < 100; i++)
                {
                    if (tempColumns[tabSaloon.SelectedIndex, _seatItem.Detail.RowIndex, i] != 0) say++;
                }

                say++;

                if (tempCols[tabSaloon.SelectedIndex] < say) tempCols[tabSaloon.SelectedIndex] = say;
                tempColumns[tabSaloon.SelectedIndex, _seatItem.Detail.RowIndex, say] = 2;
                getTemplate(tempRow[tabSaloon.SelectedIndex], 4, false);
            }
        }

        private void toolStripAddSep1_Click(object sender, EventArgs e) { AddSep(1); }

        private void toolStripAddSep5_Click(object sender, EventArgs e) { AddSep(5); }

        private void toolStripAddSep10_Click(object sender, EventArgs e) { AddSep(10); }

        private void toolStripAddSep20_Click(object sender, EventArgs e) { AddSep(20); }

        void AddRow(int count)
        {
            for (int k = 0; k < count; k++)
            {
                tempRow[tabSaloon.SelectedIndex]++;
                int say = 1;
                for (int i = 0; i < 100; i++)
                    if (tempColumns[tabSaloon.SelectedIndex, tempRow[tabSaloon.SelectedIndex], i] != 0) say++;
                int rowFirst = 0;
                if (_seatItem == null) rowFirst = 1; else rowFirst = _seatItem.Detail.RowIndex;
                getTemplate(tempRow[tabSaloon.SelectedIndex], 4, false);
            }
        }

        private void toolStripAddRow1_Click(object sender, EventArgs e) { AddRow(1); }

        private void toolStripAddRow5_Click(object sender, EventArgs e) { AddRow(5); }

        private void toolStripAddRow10_Click(object sender, EventArgs e) { AddRow(10); }

        private void toolStripAddRow20_Click(object sender, EventArgs e) { AddRow(20); }

        void AddCol(int count)
        {
            for (int k = 0; k < count; k++)
            {
                int say = 1;
                for (int i = 0; i < 100; i++)
                {
                    if (tempColumns[tabSaloon.SelectedIndex, _seatItem.Detail.RowIndex, i] != 0) say++;
                }

                say++;

                if (tempCols[tabSaloon.SelectedIndex] < say) tempCols[tabSaloon.SelectedIndex] = say;
                tempColumns[tabSaloon.SelectedIndex, _seatItem.Detail.RowIndex, say] = 1;
                getTemplate(tempRow[tabSaloon.SelectedIndex], 4, false);
            }
        }

        private void toolStripAddCol1_Click(object sender, EventArgs e) { AddCol(1); }

        private void toolStripAddCol5_Click(object sender, EventArgs e) { AddCol(5); }

        private void toolStripAddCol10_Click(object sender, EventArgs e) { AddCol(10); }

        private void toolStripAddCol20_Click(object sender, EventArgs e) { AddCol(20); }

        private void btnClear_Click(object sender, EventArgs e)
        {

            //int[,,][] tempColumns = new int[100, 100, 100][];
            ////foreach (int[] subArray in tempColumns)
            //    Array.Clear(subArray, 0, subArray.GetLength(0));
            //TempColumns _tempColumns = new TempColumns(0,string.Empty);
            //Array.Clear(tempColumns, 0, tempColumns.GetLength(0) * tempColumns.GetLength(1) * tempColumns.GetLength(2));

            var array = Enumerable.Range(0, 10)
                      .Select(x => Enumerable.Repeat('x', 10).ToArray())
                      .ToArray();

            Array.Clear(tempRow, 0, tempRow.GetLength(0));
            Array.Clear(tempCols, 0, tempCols.GetLength(0));
            for (int i = 0; i < 100; i++)
                tempRow[i] = 2;
            chkBlock.Checked = false;
            txtBlockCount.Value = 1;
            cmbTemp.SelectedIndex = -1;
            tempRow[tabSaloon.SelectedIndex] = 2;
            getTemplate(tempRow[tabSaloon.SelectedIndex], 4, false);
        }


        void createTheaterBlockTemp(TabControl tab, MovieTheatrePlaceTemplate movieTheatrePlaceTemplate, int? blocks)
        {

            using (var entities = new CineBookEntities())
            {
                blockArray = entities.MovieTheatrePlaceTemplateBlock.Where(o => o.MovieTheatrePlaceTemplateId
                == movieTheatrePlaceTemplate.MovieTheatrePlaceTemplateId).ToArray();
            }


            if (blocks == 0)
            {
                panel2.Controls.Clear();
                TableLayoutPanel tlp1 = new TableLayoutPanel();
                tlp1.Dock = System.Windows.Forms.DockStyle.Fill;
                tlp1.Name = "tblSessionDetail0";
                tlp1.AutoScroll = true;
                panel2.Controls.Add(tlp1);
                GetSessionTemplate();
            }
            else
            {
                panel2.Controls.Clear();
                tab.Controls.Clear();

                for (int i = 0; i < blocks; i++)
                {
                    TabPage tabpage = new TabPage();
                    tabpage.TabIndex = i;
                    tabpage.ImageIndex = 0;

                    if (i == 0)
                        tabpage.ImageIndex = 0;
                    else if (i == 1)
                        tabpage.ImageIndex = 1;
                    else if (i == blocks - 1)
                        tabpage.ImageIndex = 3;
                    else
                        tabpage.ImageIndex = 2;
                    TableLayoutPanel tlp1 = new TableLayoutPanel();
                    tlp1.Dock = System.Windows.Forms.DockStyle.Fill;
                    if (tab.Name == "tabSaloon")
                        tlp1.Name = "tblSaloonDetail" + i.ToString();
                    else
                        tlp1.Name = "tblSessionDetail" + i.ToString();
                    tlp1.AutoScroll = true;
                    tabpage.Text = blockArray[i].MovieTheaterBlockName.ToString();
                    tabpage.Controls.Add(tlp1);
                    tab.Controls.Add(tabpage);
                    tab.ImageList = this.imageList1;
                }

                panel2.Controls.Add(tab);
            }
        }

        private void txtBlockCount_ValueChanged(object sender, EventArgs e)
        {

            //if (txtBlockCount.Value < 2) return;

            if (chkBlock.Checked)
            {

                //pnlSaloon.Controls.Clear();
                tabSaloon.Controls.Clear();
                createTheaterBlockTemp(tabSaloon, null, Convert.ToInt32(txtBlockCount.Value));
            }

        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            //foreach (Control c in this.pnlSaloon.Controls)
            //{
            //    c.BackColor = Color.FromArgb(0, 127, 124, 127);
            //    c.ForeColor = Color.FromArgb(0, 127, 124, 127);
            //}

            //var item = (Button)sender;
            //item.ForeColor = Color.Red; item.BackColor = System.Drawing.SystemColors.Control;
            //tabSaloon.SelectedIndex = Convert.ToInt32(item.Text) - 1;
            //getTemplate(tempRow[tabSaloon.SelectedIndex], 4, false);

        }


        private void btnBlock2_Click(object sender, EventArgs e)
        {
            //foreach (Control c in this.pnlSession.Controls)
            //{
            //    c.BackColor = Color.FromArgb(0, 127, 124, 127);
            //    c.ForeColor = Color.FromArgb(0, 127, 124, 127);
            //}

            //var item = (Button)sender;
            //item.ForeColor = Color.Red; item.BackColor = System.Drawing.SystemColors.Control;
            //tabSession.SelectedIndex = Convert.ToInt32(item.Text) - 1;

            //GetSessionTemplate();

        }

        public void getTemplate(int RowCount, int type, bool ishall)
        {

            int _seatWidth = (int)(30 + 1 * 1);
            int _seatHeight = (int)(35 + 1 * 1);
            int _seatFontSize = (int)(8 + 1 * 2.5);

            //MessageBox.Show(tabSaloon.SelectedIndex.ToString());
            TableLayoutPanel tblSaloonDetail;
            if (chkBlock.Checked)
            {
                tblSaloonDetail = this.Controls.Find("tblSaloonDetail" + tabSaloon.SelectedIndex.ToString(), true).FirstOrDefault() as TableLayoutPanel;
                if (tblSaloonDetail == null) return;
            }
            else
            {
                tabSaloon.Controls.Clear();
                TabPage tabpage = new TabPage();
                tblSaloonDetail = new TableLayoutPanel();
                tblSaloonDetail.Dock = System.Windows.Forms.DockStyle.Fill;
                tblSaloonDetail.Name = "tblSaloonDetail" + 0.ToString();
                tabpage.Text = "1";
                tabpage.Controls.Add(tblSaloonDetail);
                tabSaloon.Controls.Add(tabpage);
                tabSaloon.ImageList = null;
                tabSaloon.Size = new System.Drawing.Size(1084, 0);
            }

            //TableLayoutPanel tblSaloonDetail = new TableLayoutPanel();
            tblSaloonDetail.Visible = false;
            tblSaloonDetail.ColumnStyles.Clear();
            tblSaloonDetail.RowStyles.Clear();
            tblSaloonDetail.Controls.Clear();
            tblSaloonDetail.Visible = true;
            using (var database = new CineBookEntities())
            {
                var placeTemplate = database.MovieTheatrePlaceTemplate.FirstOrDefault();
                var itemSession = database.MovieSession.FirstOrDefault();

                var details = placeTemplate.MovieTheatrePlaceTemplateDetails.Where(o => o.SeatCode == null && o.RowIndex == 0 && o.MovieTheatrePlaceTemplateId == 1).ToArray();
                var ColumnCount = 99;
                tblSaloonDetail.ColumnCount = ColumnCount + 1;
                for (var i = 0; i < ColumnCount; i++) tblSaloonDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _seatWidth));

                tblSaloonDetail.RowCount = RowCount + 1;
                list = new List<MovieTheatrePlaceTemplateDetails>();
                MovieTheatrePlaceTemplateDetails sitem = new MovieTheatrePlaceTemplateDetails();
                list = details.ToList();
                for (var i = 1; i < RowCount; i++)
                {
                    if (RowCount > 1)
                    {
                        if (tempCols[tabSaloon.SelectedIndex] != 0)
                        {
                            for (int j = 0; j < 99; j++)
                            {
                                if (j == 0)
                                {
                                    tempColumnsNames[tabSaloon.SelectedIndex, 0] = _seatItem.Text;
                                    sitem = new MovieTheatrePlaceTemplateDetails();
                                    MovieSeatType iType = new MovieSeatType();
                                    sitem.RowIndex = i;
                                    sitem.Id = j;
                                    sitem.MovieTheatrePlaceTemplateId = 1;
                                    if (!ishall)
                                        sitem.Prefix = GetAlphabets(i);
                                    //_seatItem == null ? GetAlphabets(i) : _seatItem.Text; // GetAlphabets(i);
                                    sitem.ColumnIndex = j;

                                    sitem.Suffix = null;
                                    sitem.SeatCode = null;

                                    sitem.MovieSeatTypeId = 1;
                                    iType.MovieSeatTypeBackground = "#666666";
                                    iType.MovieSeatTypeForeground = "#ffffff";
                                    iType.MovieSeatTypeName = "Marker";
                                    iType.MovieSeatTypeId = 1;
                                    sitem.MovieSeatType = iType;
                                    sitem.Block = tabSaloon.SelectedIndex;
                                    list.Add(sitem);
                                }
                                else
                                {
                                    if (tempColumns[tabSaloon.SelectedIndex, i, j + 1] != 0)
                                    {

                                        if (type == 4 && tempColumns[tabSaloon.SelectedIndex, i, j + 1] == 1)
                                        {

                                            int abc = 1;
                                            for (int m = 0; m < j + 1; m++)
                                            {
                                                if (tempColumns[tabSaloon.SelectedIndex, i, m] == 1)
                                                {
                                                    if (tempColumns[tabSaloon.SelectedIndex, i, m] == 2) break;
                                                    abc++;
                                                }
                                            }

                                            sitem = new MovieTheatrePlaceTemplateDetails();
                                            MovieSeatType iType = new MovieSeatType();

                                            sitem.RowIndex = i;
                                            sitem.MovieTheatrePlaceTemplateId = 1;
                                            sitem.MovieSeatTypeId = type;
                                            sitem.Id = j;
                                            sitem.ColumnIndex = j;
                                            sitem.Prefix = GetAlphabets(i);
                                            //_seatItem == null ? GetAlphabets(i) : _seatItem.Text; // GetAlphabets(i);
                                            sitem.Suffix = abc.ToString();
                                            sitem.SeatCode = GetAlphabets(i) + abc.ToString();
                                            //GetAlphabets(i).TrimEnd() + abc.ToString();
                                            iType.MovieSeatTypeBackground = "#ffffff";
                                            iType.MovieSeatTypeForeground = "#000000";
                                            iType.MovieSeatTypeName = "Standard Koltuk";
                                            iType.MovieSeatTypeId = type;
                                            sitem.MovieSeatType = iType;
                                            sitem.Block = tabSaloon.SelectedIndex;
                                            list.Add(sitem);
                                        }

                                    }
                                }

                            }

                            MovieTheatrePlaceTemplateDetails item = new MovieTheatrePlaceTemplateDetails();
                            item.Suffix = null;
                            item.SeatCode = null;
                            item.MovieSeatTypeId = 1;

                            MovieSeatType iiType = new MovieSeatType();
                            iiType.MovieSeatTypeBackground = "#666666";
                            iiType.MovieSeatTypeForeground = "#ffffff";
                            iiType.MovieSeatTypeName = "Marker";
                            iiType.MovieSeatTypeId = 1;

                            item.RowIndex = i;
                            item.Id = i;
                            item.MovieTheatrePlaceTemplateId = 1;
                            item.Prefix = GetAlphabets(i);
                            //_seatItem == null ? GetAlphabets(i) : _seatItem.Text;//GetAlphabets(i);
                            item.ColumnIndex = tempCols[tabSaloon.SelectedIndex];
                            item.Suffix = null;
                            item.SeatCode = null;
                            item.MovieSeatTypeId = 1;
                            item.MovieSeatType = iiType;
                            item.Block = tabSaloon.SelectedIndex;
                            list.Add(item);

                        }
                        else
                        {


                            //tempColumns[tabSaloon.SelectedIndex, i, 0].Name = "A";
                            //_seatItem ==null?"A": _seatItem.Text;
                            MovieTheatrePlaceTemplateDetails item = new MovieTheatrePlaceTemplateDetails();
                            item.RowIndex = i;
                            item.Id = i;
                            item.MovieTheatrePlaceTemplateId = 1;
                            item.Prefix = GetAlphabets(i);
                            //_seatItem == null ? GetAlphabets(i) : _seatItem.Text;
                            item.ColumnIndex = 0;
                            item.Suffix = null;
                            item.SeatCode = null;
                            item.Block = tabSaloon.SelectedIndex;
                            item.MovieSeatTypeId = 1;

                            MovieSeatType iType = new MovieSeatType();
                            iType.MovieSeatTypeBackground = "#666666";
                            iType.MovieSeatTypeForeground = "#ffffff";
                            iType.MovieSeatTypeName = "Marker";
                            iType.MovieSeatTypeId = 1;
                            item.MovieSeatType = iType;
                            list.Add(item);

                            item = new MovieTheatrePlaceTemplateDetails();
                            item.Suffix = null;
                            item.SeatCode = null;
                            item.MovieSeatTypeId = 1;
                            item.Block = tabSaloon.SelectedIndex;

                            MovieSeatType iiType = new MovieSeatType();
                            iiType.MovieSeatTypeBackground = "#666666";
                            iiType.MovieSeatTypeForeground = "#ffffff";
                            iiType.MovieSeatTypeName = "Marker";
                            iiType.MovieSeatTypeId = 1;

                            item.RowIndex = i;
                            item.Id = i;
                            item.MovieTheatrePlaceTemplateId = 1;
                            item.Prefix = GetAlphabets(i);
                            item.ColumnIndex = tempCols[tabSaloon.SelectedIndex];
                            item.Suffix = null;
                            item.SeatCode = null;
                            item.MovieSeatTypeId = 1;
                            item.MovieSeatType = iiType;
                            list.Add(item);
                        }
                    }

                }

                if (dList.ContainsKey(tabSaloon.SelectedIndex))
                    dList.Remove(tabSaloon.SelectedIndex);

                dList.Add(tabSaloon.SelectedIndex, list);
                details = list.ToArray();
                tblSaloonDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, _seatHeight));
                tblSaloonDetail.SuspendLayout();
                foreach (var item in details)
                {
                    var button = new SeatItem(item, itemSession) { Font = new Font("Arial Narrow", 7, FontStyle.Bold) };
                    button.Status = SeatItem.SeatStatus.Available;
                    button.SetBorder();
                    //button.Width = 500;
                    if (item.ColumnIndex == 0)
                        button.ContextMenuStrip = menuSaloonCreate;
                    else
                        button.ContextMenuStrip = menuSaloonCreateSeat;
                    button.MouseDown += SeatItemC_OnClick;
                    tblSaloonDetail.Controls.Add(button, item.ColumnIndex, item.RowIndex);
                }

                // Separator Control
                for (var i = 0; i < ColumnCount; i++)
                {
                    var separator = true;
                    foreach (var item in details.Where(o => o.ColumnIndex == i)) { if ((item.MovieSeatTypeId > 3) || (item.MovieSeatTypeId <= 3 && !string.IsNullOrEmpty(item.Prefix))) { separator = false; } }
                    if (separator) tblSaloonDetail.ColumnStyles[i].Width = (int)(_seatWidth / 5d);
                }

                tblSaloonDetail.ResumeLayout(true);
            }

        }


        void CreateSessionTemplate()
        {
            using (var database = new CineBookEntities())
            {
                MovieTheatrePlaceTemplate placeTemplate = database.MovieTheatrePlaceTemplate.Where(o => o.MovieTheatrePlaceTemplateId == SelectedMovieSession.MovieTheatrePlace.MovieTheatrePlaceTemplateId).FirstOrDefault();


                if (placeTemplate.Block > 0)
                {
                    //tabSession.Visible = true;
                    //tabSession.Controls.Clear();
                    createTheaterBlockTemp(tabSession, placeTemplate, placeTemplate.Block);
                    this.tabSession.SelectedIndex = -1;
                }
                else
                {
                    //tabSession.Visible = false;
                    //tabSession.Height = 0;
                    tabSession.ImageList = null;
                    createTheaterBlockTemp(tabSession, placeTemplate, placeTemplate.Block);
                    this.tabSession.Size = new System.Drawing.Size(834, 0);
                    this.tabSession.SelectedIndex = 0;

                }

            }

            //GetSessionTemplate();
        }

        void GetSessionTemplate()
        {
            int _seatWidth = (int)(30 + 3 * 1);
            int _seatHeight = (int)(35 + 3 * 1);
            int _seatFontSize = (int)(8 + 1 * 2.5);


            if (dataGridViewMovieSession.SelectedRows.Count == 0) return;
            var itemSession = dataGridViewMovieSession.SelectedRows[0].DataBoundItem as MovieSession;


            using (var database = new CineBookEntities())
            {

                var placeTemplate = database.MovieTheatrePlaceTemplate.Where(o => o.MovieTheatrePlaceTemplateId == SelectedMovieSession.MovieTheatrePlace.MovieTheatrePlaceTemplateId).FirstOrDefault();

                TableLayoutPanel tblSessionDetail = this.Controls.Find("tblSessionDetail" + tabSession.SelectedIndex.ToString(), true).FirstOrDefault() as TableLayoutPanel;
                if (tblSessionDetail == null) return;


                tblSessionDetail.Visible = false;
                tblSessionDetail.ColumnStyles.Clear();
                tblSessionDetail.RowStyles.Clear();
                tblSessionDetail.Controls.Clear();
                tblSessionDetail.Visible = true;

                List<MovieTheatrePlaceTemplateDetails> details;
                if (placeTemplate.Block == 0)
                    details = placeTemplate.MovieTheatrePlaceTemplateDetails.ToList();
                else
                    details = placeTemplate.MovieTheatrePlaceTemplateDetails.Where(o => o.Block == tabSession.SelectedIndex).ToList();

                if (details.Count == 0) return;

                var ColumnCount = details.Max(item => item.ColumnIndex) + 1;
                var RowCount = details.Max(item => item.RowIndex) + 1;

                tblSessionDetail.ColumnCount = ColumnCount + 1;
                for (var i = 0; i < ColumnCount; i++)
                {
                    if (i == 0 || i == ColumnCount - 1)
                        tblSessionDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 44));
                    else
                        tblSessionDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _seatWidth));
                }
                tblSessionDetail.RowCount = RowCount + 1;
                for (var i = 0; i < RowCount; i++) tblSessionDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, _seatHeight));

                tblSessionDetail.SuspendLayout();
                foreach (var item in details)
                {
                    var detail = details.FirstOrDefault(o => o.Id == item.Id);
                    int say = detail.Suffix == null ? 0 : Convert.ToInt32(detail.Suffix);
                    int fontSize = 7;
                    if (say >= 100) fontSize = 6;
                    var button = new SeatItem(detail, itemSession) { Font = new Font("Arial Narrow", fontSize, FontStyle.Bold) };
                    button.Status = SeatItem.SeatStatus.Available;

                    button.ContextMenuStrip = menuSeats;
                    button.MouseDown += SeatItem_OnClick;
                    tblSessionDetail.Controls.Add(button, item.ColumnIndex, item.RowIndex);
                }

                // Separator Control
                for (var i = 0; i < ColumnCount; i++)
                {
                    var separator = true;
                    foreach (var item in details.Where(o => o.ColumnIndex == i)) { if ((item.MovieSeatTypeId > 3) || (item.MovieSeatTypeId <= 3 && !string.IsNullOrEmpty(item.Prefix))) { separator = false; } }
                    if (separator) tblSessionDetail.ColumnStyles[i].Width = (int)(_seatWidth / 5d);
                }

                tblSessionDetail.ResumeLayout(true);
            }


        }

        private void tabSaloon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSaloon.SelectedIndex == -1) return;
            getTemplate(tempRow[tabSaloon.SelectedIndex], 4, false);
        }

        private void tabSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSession.SelectedIndex == -1) return;
            GetSessionTemplate();
        }

        private void koltukAdıToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void tabSession_DrawItem(object sender, DrawItemEventArgs e)
        {
            var CloseImage = (e.Index == 0 ? imageList1.Images[0] : (e.Index == (this.tabSession.TabCount - 1) ? imageList1.Images[3] : imageList1.Images[2]));
            Bitmap myBitmap = new Bitmap(CloseImage); // @"C:\Temp\imgSwacaa.jpg");  

            Color backColor = myBitmap.GetPixel(1, 1); // GetPixel(1, 1); 
            Color backColorGray = Color.Gray;
            //Color backColorGrayLight = Color.LightGray;
            //Color backColorWhiteSmoke = Color.WhiteSmoke;
            Color backColorWhite = Color.White;
            Color backColorWheat = Color.Wheat;
            myBitmap.MakeTransparent(backColor);
            myBitmap.MakeTransparent(backColorGray);
            //myBitmap.MakeTransparent(backColorGrayLight);
            //myBitmap.MakeTransparent(backColorWhiteSmoke);

            var tabRect = this.tabSession.GetTabRect(e.Index);
            tabRect.Inflate(-2, -2);
            var imageRect = new Rectangle(tabRect.Right - CloseImage.Width,
                              tabRect.Top + (tabRect.Height - CloseImage.Height) / 2,
                              CloseImage.Width,
                              CloseImage.Height);
            string tabName = tabSession.TabPages[e.Index].Text;
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            //Find if it is selected, this one will be hightlighted...
            if (e.Index == tabSession.SelectedIndex)
                e.Graphics.FillRectangle(Brushes.PaleTurquoise, e.Bounds);
            e.Graphics.DrawImage(myBitmap, imageRect.Location);
            e.Graphics.DrawString(tabName, new Font("Arial Black", 22), Brushes.DarkSlateGray, tabSession.GetTabRect(e.Index), stringFormat);

        }
    }
}
