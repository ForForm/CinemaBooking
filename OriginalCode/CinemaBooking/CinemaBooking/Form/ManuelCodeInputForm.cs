using System;
using System.Windows.Forms;

namespace CinemaBooking
{
    public partial class ManuelCodeInputForm : Form
    {
        private string _result = "";
        private const int MaxLength = 12;
        public static ManuelCodeInputForm Instance;
        public ManuelCodeInputForm()
        {
            InitializeComponent();
            Instance = this;
            Check();
        }
        protected override void OnClosed(EventArgs e) { base.OnClosed(e); Instance = null; }
        public static string GetConfirm()
        {
            var window = new ManuelCodeInputForm { Owner = MainForm.Instance };
            window.ShowDialog();
            return window.DialogResult == DialogResult.OK ? window._result : null;
        }
        private void buttonCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; }
        private void buttonNumber_Click(object sender, EventArgs e) { AddChar(((Button)sender).Text); }
        private void buttonBackspace_Click(object sender, EventArgs e) { DelChar(); }
        private void buttonOkay_Click(object sender, EventArgs e) { DialogResult = DialogResult.OK; }
        private void AddChar(string value)
        {
            _result += value;
            Check();
        }
        private void DelChar()
        {
            if (_result.Length > 0) _result = _result.Substring(0, _result.Length - 1);
            Check();
        }
        private void Check()
        {
            labelTitle.Text = new string('0', MaxLength - _result.Length) + _result;
            button0.Enabled = _result != "" && _result.Length < MaxLength;
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = _result.Length < MaxLength;
            buttonOkay.Enabled = _result != "";
        }
    }
}
