using System;
using System.Windows.Forms;

namespace CinemaBooking
{
    public partial class ConfirmForm : Form
    {
        public static ConfirmForm Instance;

        protected static void getNames()
        {
            var c = StaticClass.GetAll(Instance);
            foreach (var item in c) StaticClass.ChangeNames(item);

        }


        public ConfirmForm(string question)
        {
            InitializeComponent();
            Instance = this;
            labelQuestion.Text = question;
            getNames();
        }
        protected override void OnClosed(EventArgs e) { base.OnClosed(e); Instance = null; }
        private void ButtonNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
        private void ButtonYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }
        public static bool GetConfirm(string question)
        {
            var window = new ConfirmForm(question) { Owner = MainForm.Instance };
            window.ShowDialog();
            return window.DialogResult == DialogResult.Yes;
        }

    }
}
