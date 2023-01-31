using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace CinemaBooking
{
    public partial class CustomerScreenDefault : Form
    {
        public static CustomerScreenDefault Instance;
        public CustomerScreenDefault()
        {
            InitializeComponent();
            Instance = this;
            Owner = MainForm.Instance;
            this.MaximizeToSecondaryMonitor();
        }
        public static void ShowForm()
        {
            if (Debugger.IsAttached) return;
            if (Screen.AllScreens.All(o => o.Primary)) return;
            if (Instance == null) Instance = new CustomerScreenDefault();
            Instance.Show();
            Instance.BringToFront();

 

        }
        public static void CloseForm() { if (Instance != null) Instance.Close(); }
        protected override void OnClosed(EventArgs e) { base.OnClosed(e); Instance = null; }

    }
}
