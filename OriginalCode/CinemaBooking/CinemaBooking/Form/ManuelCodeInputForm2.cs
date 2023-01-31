using System;
using System.Windows.Forms;
using System.Linq;

namespace CinemaBooking
{

    //public class BiletKotaItem : BiletKota
    //{
    //    public string Status { get; set; }
    //}


    public partial class ManuelCodeInputForm2 : Form
    {
        public string _result = "";
        public int _kotaId = 0;
        private const int MaxLength = 12;
        public static ManuelCodeInputForm2 Instance;
        public BiletKota biletKota;
        public static bool Rezervasyon;

        public ManuelCodeInputForm2()
        {
            InitializeComponent();
            Instance = this;
            Check();
        }

        
        protected override void OnClosed(EventArgs e) { base.OnClosed(e); Instance = null; }
        public static string GetConfirm()
        {
            var window = new ManuelCodeInputForm2 { Owner = MainForm.Instance };
            window.ShowDialog();
            return window.DialogResult == DialogResult.OK ? window._result : null;
        }

        public static string GetConfirm(bool _Rezervasyon)
        {
            Rezervasyon = _Rezervasyon;
            var window = new ManuelCodeInputForm2 { Owner = MainForm.Instance };
            window.ShowDialog();
            return window.DialogResult == DialogResult.OK ? window._result : null;
        }
        
        private void buttonCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; }
        private void buttonNumber_Click(object sender, EventArgs e) { AddChar(((Button)sender).Text); }
        private void buttonBackspace_Click(object sender, EventArgs e) { DelChar(); }
        private void buttonOkay_Click(object sender, EventArgs e)
        {

            //var item = (Button)sender;
            //MessageBox.Show(labelTitle.Text);


            if (Rezervasyon)
            {
                _result = labelTitle.Text;
                DialogResult = DialogResult.OK;

            }
            else
            {

                using (var entities = new FFSaleEntities())
                {
                    var biletKotaKod = entities.BiletKotaKod.Where(o => o.Kod == labelTitle.Text.Substring(2, labelTitle.Text.Length - 2) && o.Kullanildi == false).FirstOrDefault();
                    if (biletKotaKod == null)
                    {
                        InfoForm.ShowInfo(labelTitle.Text + " Kod geçersiz.".ChangeLng());
                    }
                    else
                    {

                        if (!(DateTime.Today >= biletKotaKod.BiletKota.GecerlilikBaslangic && DateTime.Today <= biletKotaKod.BiletKota.GecerlilikBitis
                            && biletKotaKod.BiletKota.Aktif))
                            InfoForm.ShowInfo("Tarife tarihi geçersiz veya aktif değil.".ChangeLng());
                        else
                        {
                            biletKota = biletKotaKod.BiletKota;
                            _kotaId = biletKotaKod.KotaId;
                        }

                        //biletKodKod.Kullanildi = true;
                        //entities.SaveChanges();
                    }


                }
            }

            DialogResult = DialogResult.OK;
        }
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
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = buttonA.Enabled = buttonB.Enabled = buttonC.Enabled = buttonD.Enabled = buttonE.Enabled = buttonF.Enabled = _result.Length < MaxLength;
            //buttonOkay.Enabled = _result != "";
            labelTitle.Focus();
        }
    }
}
