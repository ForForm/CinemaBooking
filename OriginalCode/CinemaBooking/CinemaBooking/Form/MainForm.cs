using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaBooking
{
    public partial class MainForm : Form
    {
        public static MainForm Instance;
        public MainForm()
        {
            InitializeComponent();
            Instance = this;
            AppDomain.CurrentDomain.UnhandledException += AppDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CustomerScreenDefault.ShowForm();
            LoginForm.ShowForm();
            //var tagId = TapYourCardForm.GetConfirm();
            //if (!string.IsNullOrEmpty(tagId)) InfoForm.ShowInfo("TagId: " + tagId);
            //InfoForm.ShowInfo("Bu kart ile yakın zamanda bilet alınmış.\n(Son satış: 2017-12-17 23:00:00)\n115 dk sonra tekrar deneyiniz.");
        }
        //protected override void OnShown(EventArgs e)
        //{
        //    base.OnShown(e);
        //}

        public void CheckAuthorizations()
        {
            if (LoginUser.UserLogged)
            {
                //statusStrip.Visible = true;
                MovieSelection.ShowForm();
            }
            else
            {
                //statusStrip.Visible = false;
            }
        }

        void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var Error = e.ExceptionObject.ToString();
                StaticClass.WriteToLog(Error, "AppDomain_UnhandledException", true, true, true);
                InfoForm.ShowInfo(Error);
            }
            catch (Exception)
            {
            }
        }
        void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            try
            {
                var Error = e.Exception.ToString();
                StaticClass.WriteToLog(Error, "TaskScheduler_UnobservedTaskException", true, true, true);
                InfoForm.ShowInfo(Error);
            }
            catch (Exception)
            {
            }
        }
        private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                var Error = e.Exception.ToString();
                StaticClass.WriteToLog(Error, "Application_ThreadException", true, true, true);
                InfoForm.ShowInfo(Error);
            }
            catch (Exception)
            {
            }
        }

    }
}
