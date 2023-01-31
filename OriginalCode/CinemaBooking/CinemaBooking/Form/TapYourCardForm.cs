using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CinemaBooking.Model;
using FsmTagReaderLite;

namespace CinemaBooking
{
    public partial class TapYourCardForm : Form
    {
        private string _result;
        private Thread thread;
        public static TapYourCardForm Instance;
        public TapYourCardForm()
        {
            InitializeComponent();
            Instance = this;
            CheckForIllegalCrossThreadCalls = false;
        }
        protected override void OnClosed(EventArgs e) { base.OnClosed(e); Instance = null; }
        protected override void OnClosing(CancelEventArgs e) { StopThread(); base.OnClosing(e); }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            labelTitle.Text = @"Kart okuyucu bekleniyor...".ChangeLng();
            StartThread();
        }
        public static string GetConfirm()
        {
            var window = new TapYourCardForm { Owner = MainForm.Instance };
            window.ShowDialog();
            return window.DialogResult == DialogResult.OK ? window._result : null;
        }
        private void buttonCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; }
        private void buttonManuel_Click(object sender, EventArgs e)
        {
            StopThread();
            //var seriNo = ManuelCodeInputForm.GetConfirm();
            var seriNo = ManuelCodeInputForm2.GetConfirm(true);
            if (!string.IsNullOrEmpty(seriNo))
            {
                var tagResult = CustomerAuthorizationFindTagIdViewModel.Get(seriNo);
                if (tagResult != null)
                {
                    if (tagResult.Result)
                    {
                        _result = tagResult.Content;
                        DialogResult = DialogResult.OK;
                        return;
                    }
                    InfoForm.ShowInfo(tagResult.Description);
                }
                else
                {
                    InfoForm.ShowInfo("Bir hata meydana geldi.");
                }
            }
            StartThread();
        }
        private void StartThread()
        {
            if (thread != null) return;
            thread = new Thread(new ThreadStart(delegate
            {
                try
                {
                    while (true)
                    {
                        string tagId;
                        var result = TagReader.GetTagID(out tagId);
                        string message;
                        switch (result)
                        {
                            case TagReader.ReturnValues.TagReady:
                                _result = tagId;
                                message = "Kart tespit edildi.";
                                break;
                            case TagReader.ReturnValues.DeviceNotFound:
                                message = "Kart okuyucu bekleniyor...".ChangeLng();
                                break;
                            case TagReader.ReturnValues.TagNotFound:
                                message = "Kartı okuyucunun üzerine koyunuz.";
                                break;
                            default:
                                message = "İşlem başarısız. (" + result + ")";
                                break;
                        }
                        labelTitle.Text = message;
                        if (!string.IsNullOrEmpty(_result)) { DialogResult = DialogResult.OK; }
                    }
                }
                catch (ThreadAbortException)
                {
                    //labelTitle.Text = @"İşlem iptal edildi.";
                }
                catch (Exception)
                {
                    labelTitle.Text = @"Exception occured.";
                }
            }));
            thread.Start();
        }
        private void StopThread()
        {
            thread?.Abort();
            thread = null;
        }
    }
}
