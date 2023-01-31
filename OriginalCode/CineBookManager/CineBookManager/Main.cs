using System;
using System.Windows.Forms;
using CineBookManager.Classes;
using CineBookManager.Forms;
using CineBookManager.Models;

namespace CineBookManager
{
    public partial class Main : Form
    {
        public static Main Instance;
        public Main() { InitializeComponent(); Instance = this; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = StringConsts.Main_Title;
            RefreshMenu();
        }
        public void RefreshMenu()
        {
            //menuStrip.Visible = LoginUser.UserLogged;
            menuStrip.Visible = false;
            if (LoginUser.UserLogged)
            {
                LoginForm.CloseForm();
                MovieForm.ShowForm();
            }
            else
            {
                MovieForm.CloseForm();
                LoginForm.ShowForm();
            };
        }

        private void moviesStripMovies_Click(object sender, EventArgs e)
        {
            MovieForm.ShowForm();
        }
        private void moviesStripSessions_Click(object sender, EventArgs e)
        {

        }
        private void moviesStripChangeMyPass_Click(object sender, EventArgs e)
        {

        }
        private void moviesStripLogout_Click(object sender, EventArgs e)
        {
            LoginUser.CurrentUser = null;
            LoginUser.CurrentUserSession = null;
            RefreshMenu();
        }
    }
}
