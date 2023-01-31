using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace CinemaBooking
{
    public partial class LoginForm : Form
    {
        public static LoginForm Instance;
        private enum EditModes { Username, Password }
        private EditModes EditMode;
        public LoginForm()
        {
            InitializeComponent();
            Instance = this;
            Owner = MainForm.Instance;
            Location = Owner.Location;
            Size = Owner.Size;
            WindowState = Owner.WindowState;

            buttonUserName.Click += delegate { EditMode = EditModes.Username; RefreshButtonBorders(); };
            buttonPassword.Click += delegate { EditMode = EditModes.Password; RefreshButtonBorders(); };
            buttonPassword.Tag = "";
            RefreshButtonBorders();

        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (char.IsDigit(e.KeyChar))
            {
                if (EditMode == EditModes.Username)
                {
                    if (buttonUserName.Text.Length >= 8) return;
                    buttonUserName.Text += e.KeyChar.ToString();
                }
                else if (EditMode == EditModes.Password)
                {
                    if (buttonPassword.Tag.ToString().Length >= 8) return;
                    buttonPassword.Tag += e.KeyChar.ToString();
                    buttonPassword.Text = new string('●', (buttonPassword.Tag.ToString().Length));
                }
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Enter)
            {
                if (EditMode == EditModes.Username)
                {
                    EditMode = EditModes.Password;
                    RefreshButtonBorders();
                }
                else
                {
                    DoLogin();
                }
            }
            else if (e.KeyCode == Keys.Back)
            {
                ButtonDel_Click(null, null);
            }
        }

        private void RefreshButtonBorders()
        {
            buttonUserName.FlatAppearance.BorderSize = (EditMode == EditModes.Username ? 3 : 1);
            buttonPassword.FlatAppearance.BorderSize = (EditMode == EditModes.Password ? 3 : 1);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoginUser.LoggedUser = null;
            LoginUser.SessionId = null;
            MainForm.Instance.CheckAuthorizations();
            Class.PrinterTemplates.RefreshTemplates(null);

            using (var entity = new CinemaBookingEntities())
            {
                cmbLng.DataSource = entity.Languages.ToList();
                cmbLng.DisplayMember = "Name";
                cmbLng.SelectedItem = entity.Languages.Where(o => o.Active == true).FirstOrDefault();

            }

            buttonUserName.Focus();


            //if(Debugger.IsAttached) DoLogin();
        }
        protected override void OnClosed(EventArgs e) { base.OnClosed(e); Instance = null; if (!LoginUser.UserLogged) Environment.Exit(0); }
        private void buttonLogin_Click(object sender, EventArgs e) { DoLogin(); }

        private void DoLogin()
        {
            var userName = buttonUserName.Text.ToLower();
            var password = buttonPassword.Tag.ToString();

            //if (Debugger.IsAttached)
            //{
            //    userName = "0129";
            //    password = "101112";
            //}

            //if (Debugger.IsAttached)
            //{
            //    userName = "0000";
            //    password = "4422062";
            //}

            if (Debugger.IsAttached)
            {
                userName = "0000";
                password = "1";
            }

            if (string.IsNullOrEmpty(userName)) { return; }
            if (string.IsNullOrEmpty(password)) { return; }
            //if (string.IsNullOrEmpty(userName)) { errorProvider.SetError(textBoxUserName, "Zorunlu alan"); return; }
            //if (string.IsNullOrEmpty(password)) { errorProvider.SetError(textBoxPassword, "Zorunlu alan"); return; }
            using (var entity = new CinemaBookingEntities())
            {
                var user = entity.User.FirstOrDefault(item => item.UserCode == userName);                
                
                if (user == null)
                {
                    labelWarning.Text = @"Hatalı kullanıcı!".ChangeLng();
                    //StaticClass.ShowWarning("Hatalı kullanıcı!");
                }
                else
                {
                    if (user.Password == password.ComputeHash())
                    {
                        //if (user.UserCode == "0000" && !Debugger.IsAttached)
                        //{
                        //    if (new ConfirmForm("Explorer başlatılsın mı?".ChangeLng()).ShowDialog() == DialogResult.Yes)
                        //    {
                        //        //MainForm.Instance.WindowState = FormWindowState.Minimized;
                        //        Process.Start("Explorer.exe");
                        //    }
                        //}
                        user.LanguagesId = cmbLng.SelectedItem == null ? 0 : ((Languages)cmbLng.SelectedItem).Id;
                        LoginUser.LoggedUser = user;
                        LoginUser.SessionId = Guid.NewGuid().ToString().Replace("-", "");
                        var session = new UserSession()
                        {
                            SessionId = LoginUser.SessionId,
                            UserId = user.UserId,
                            LoginTime = entity.GetDate(),
                            //Lng=cmbLng.SelectedIndex
                        };

                        entity.Entry(session).State = EntityState.Added;
                        entity.SaveChanges();
                        MainForm.Instance.CheckAuthorizations();
                        Close();
                    }
                    else
                    {
                        //StaticClass.ShowWarning("Hatalı şifre!");
                        labelWarning.Text = @"Hatalı şifre!".ChangeLng();
                    }
                }
            }
        }
        public static void ShowForm()
        {
            if (Instance == null) Instance = new LoginForm { /*MdiParent = MainForm.Instance*/ };
            Instance.Show();
            Instance.BringToFront();
        }
        private void ButtonNumeric_Click(object sender, EventArgs e)
        {
            if (EditMode == EditModes.Username)
            {
                if (buttonUserName.Text.Length >= 8) return;
                buttonUserName.Text += ((Button)sender).Text;
            }
            else if (EditMode == EditModes.Password)
            {
                if (buttonPassword.Tag.ToString().Length >= 8) return;
                buttonPassword.Tag += ((Button)sender).Text;
                buttonPassword.Text = new string('●', (buttonPassword.Tag.ToString().Length));
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (EditMode == EditModes.Username)
            {
                if (buttonUserName.Text.Length > 0) buttonUserName.Text = buttonUserName.Text.Substring(0, buttonUserName.Text.Length - 1);
            }
            else if (EditMode == EditModes.Password)
            {
                if (buttonPassword.Text.Length > 0)
                {
                    buttonPassword.Tag = buttonPassword.Tag.ToString().Substring(0, buttonPassword.Tag.ToString().Length - 1);
                    buttonPassword.Text = new string('●', (buttonPassword.Tag.ToString().Length));
                }
            }
        }
        private void ButtonOkay_Click(object sender, EventArgs e)
        {
            DoLogin();
        }
    }
}
