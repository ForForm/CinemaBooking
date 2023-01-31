using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using CineBookManager.Classes;
using CineBookManager.Models;

namespace CineBookManager.Forms
{
    public partial class LoginForm : Form
    {
        public static LoginForm Instance;
        public LoginForm() { InitializeComponent(); Instance = this; Instance.MdiParent = Main.Instance; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RefreshResources();
            textBoxUserCode.KeyDown += delegate (object sender, KeyEventArgs args) { if (args.KeyCode == Keys.Enter) textBoxPassword.Focus(); };
            textBoxPassword.KeyDown += delegate (object sender, KeyEventArgs args) { if (args.KeyCode == Keys.Enter) LoginOperation(); };
            buttonLogin.Click += delegate { LoginOperation(); };

            using (var entity = new CineBookEntities())
            {
                cmbLng.DataSource = entity.Languages.ToList();
                cmbLng.DisplayMember = "Name";
                cmbLng.SelectedItem = entity.Languages.Where(o => o.Active == true).FirstOrDefault();

            }

            //if (System.Diagnostics.Debugger.IsAttached) { textBoxUserCode.Text = @"0000"; textBoxPassword.Text = @"4422062"; BeginInvoke((MethodInvoker)LoginOperation); }

            if (System.Diagnostics.Debugger.IsAttached) { textBoxUserCode.Text = @"0000"; textBoxPassword.Text = @"1"; BeginInvoke((MethodInvoker)LoginOperation); }
        }
        protected override void OnClosed(EventArgs e) { Instance = null; base.OnClosed(e); }
        private void LoginOperation()
        {
            try
            {
                var code = textBoxUserCode.Text;
                var pass = textBoxPassword.Text;
                if (string.IsNullOrEmpty(code)) { MessageBox.Show(StringConsts.Login_Invalidusercodename); textBoxUserCode.Focus(); return; }
                if (string.IsNullOrEmpty(pass)) { MessageBox.Show(StringConsts.Login_Invalidpassword); textBoxPassword.Focus(); return; }
                var passHash = pass.ComputeHash();
                using (var database = CineBookEntitiesExt.New())
                {
                    var user = database.User.FirstOrDefault(o => o.UserCode == code && o.Password == passHash);
                    if (user != null)
                    {
                        user.LanguagesId = cmbLng.SelectedItem == null ? 0 : ((Languages)cmbLng.SelectedItem).Id;
                        user.SessionId = Guid.NewGuid().ToString().Replace("-", "");
                        var session = new UserSession { SessionId = user.SessionId, UserId = user.UserId, LoginTime = DateTime.Now };
                        database.Entry(session).State = EntityState.Added;
                        database.SaveChanges();
                        LoginUser.CurrentUser = user;
                        LoginUser.CurrentUserSession = session;
                        LoginForm.CloseForm();
                        Main.Instance.RefreshMenu();
                    }
                    else
                    {
                        MessageBox.Show(StringConsts.Login_Loginfailed);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static void ShowForm()
        {
            if (Instance == null) Instance = new LoginForm();
            Instance.WindowState = FormWindowState.Maximized;
            Instance.Show();
        }
        public static void CloseForm()
        {
            Instance?.Close();
        }
        private void RefreshResources()
        {
            Text = StringConsts.Login_Title;
            labelUserCode.Text = StringConsts.Login_Usercodename;
            labelPassword.Text = StringConsts.Login_Password;
            buttonLogin.Text = StringConsts.Login_Login;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
