using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaBooking
{
    public partial class AmountSelection : Form
    {
        public decimal LeftAmount;
        public decimal? ResultObject = null;
        private string TextValue = "";
        public static AmountSelection Instance;
        public AmountSelection(decimal leftAmount, decimal totalAmountCurrent)
        {
            InitializeComponent();
            Instance = this;
            LeftAmount = leftAmount;
            TextValue = ((int)(totalAmountCurrent * 100)).ToString(CultureInfo.InvariantCulture);
            if (LeftAmount > 0)
                ButtonTotal.Text = String.Format("Kalan Tutarın Tamamı ({0:C})".ChangeLng(), LeftAmount);
            else
            { ButtonTotal.Text = ""; ButtonTotal.Enabled = false; }
            ShowValue();
        }
        protected override void OnClosed(EventArgs e) { base.OnClosed(e); Instance = null; }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ButtonOkay_Click(object sender, EventArgs e)
        {
            int intValue;
            int.TryParse(TextValue, out intValue);
            ResultObject = (intValue / 100M);
            DialogResult = DialogResult.OK;
        }

        private void ButtonTotal_Click(object sender, EventArgs e)
        {
            ResultObject = LeftAmount;
            DialogResult = DialogResult.OK;
        }

        private void ButtonNumeric_Click(object sender, EventArgs e)
        {
            int value;
            int.TryParse(TextValue, out value);
            if (value.ToString(CultureInfo.InvariantCulture).Length >= 6) return;
            TextValue += ((Button)sender).Text;
            ShowValue();
        }

        private void ButtonNumericShortcut_Click(object sender, EventArgs e)
        {
            TextValue = (int.Parse(((Button)sender).Text) * 100).ToString(CultureInfo.InvariantCulture);
            ShowValue();
        }

        private void ButtonDel_OnClick(object sender, EventArgs e)
        {
            if (TextValue.Length > 0) TextValue = TextValue.Substring(0, TextValue.Length - 1);
            ShowValue();
        }

        private void ButtonClear_OnClick(object sender, EventArgs e) { TextValue = ""; ShowValue(); }

        private void ShowValue()
        {
            int intValue;
            int.TryParse(TextValue, out intValue);
            TextBlockTotal.Text = (intValue / 100d).ToString("0.00");
            //TouchDown += delegate { IdleClass.ResetIdleTimer(); };
        }
        public static decimal? GetSelection(decimal leftAmount, decimal totalAmountCurrent)
        {
            var window = new AmountSelection(leftAmount, totalAmountCurrent);
            window.Owner = MainForm.Instance;
            window.ShowDialog();
            return window.ResultObject;
        }

    }
}
