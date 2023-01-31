using System;
using System.Windows.Forms;

namespace CinemaBooking
{
    public partial class InfoForm : Form
    {
        public static InfoForm Instance;
        public InfoForm(string info)
        {
            InitializeComponent();
            Instance = this;
            labelInfo.Text = info;
        }
        protected override void OnClosed(EventArgs e) { base.OnClosed(e); Instance = null; }
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        public static void ShowInfo(string info)
        {
            var window = new InfoForm(info) { Owner = MainForm.Instance };
            window.ShowDialog();
        }

    }
}
