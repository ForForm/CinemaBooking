using System;
using System.Windows.Forms;

namespace CineBookManager.Forms
{
    public partial class MovieSessionForm : Form
    {
        public static MovieSessionForm Instance;
        public MovieSessionForm() { InitializeComponent(); Instance = this; MdiParent = Main.Instance; }
        protected override void OnClosed(EventArgs e) { Instance = null; base.OnClosed(e); }
        //protected override void OnLoad(EventArgs e) { base.OnLoad(e); }
        public static void ShowForm() { if (Instance == null) Instance = new MovieSessionForm(); Instance.WindowState = FormWindowState.Maximized; Instance.Show(); }
        public static void CloseForm() { Instance?.Close(); }

    }
}
