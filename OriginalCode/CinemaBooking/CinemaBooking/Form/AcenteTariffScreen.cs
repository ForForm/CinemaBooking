using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows.Forms;
using System.Linq;

namespace CinemaBooking
{



    public partial class AcenteTariffScreen : Form
    {
        private string _result = "";
        public int _kotaId = 0;
        private const int MaxLength = 12;
        public static AcenteTariffScreen Instance;
        List<AcenteTipi> acenteTipi;
        public BiletTarifeSale biletTarifeSale;
        public AcenteTariffScreen(List<AcenteTipi> _acenteTipi)
        {
            acenteTipi = _acenteTipi;
            InitializeComponent();
            Instance = this;
            Check();
        }
        protected override void OnClosed(EventArgs e) { base.OnClosed(e); Instance = null; }
        //public static string GetConfirm()
        //{
        //    var window = new AcenteTariffScreen { Owner = MainForm.Instance };
        //    window.ShowDialog();
        //    return window.DialogResult == DialogResult.OK ? window._result : null;
        //}
        private void buttonCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; }



        private void biletTariff_Click(object sender, EventArgs e)
        {
            var button = ((BiletTariffItem)sender);
            biletTarifeSale = button.biletTarifeSale;
            DialogResult = DialogResult.OK;
            //MessageBox.Show(button.biletTarife.Tutar.ToString());
        }


        private void acente_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(((TariffItem)sender).acenteTipi.AcenteTipiAdi);
            var button = ((TariffItem)sender);
            using (var entities = new FFSaleEntities())
            {
                var acenteId = entities.Acente.Where(o => o.KisaAdi == button.Text).ToArray()[0].AcenteId;
                var sozlesmes = entities.Sozlesme.Where(o => o.AcenteId == acenteId).ToArray();
                var biletKota = entities.BiletKota;

                List<BiletKota> listBiletKota = new List<BiletKota>();
                foreach (var sitem in sozlesmes)
                    foreach (var bitem in biletKota.Where(o => o.SozlesmeId == sitem.SozlesmeId))
                        listBiletKota.Add(bitem);


                var biletTariff = entities.BiletTarife;
                tableLayoutPanel1.Controls.Clear();

                int say = 0;
                foreach (var item in biletTariff)
                {

                    foreach (var bitem in listBiletKota)
                    {
                        if (bitem.TarifeId == item.TarifeId)
                        {
                            //&& o.Kullanildi == true
                            
                            var biletKotaKodKullanilan= entities.BiletKotaKod.Where(o => o.KotaId== bitem.KotaId && o.Kullanildi==true).Count();
                            //MessageBox.Show(biletKotaKodKullanilan.ToString());
                            //MessageBox.Show(bitem.Tutar.ToString());
                            
                            BiletTarifeSale biletTarifeSale = new BiletTarifeSale();
                            biletTarifeSale.biletTarife = item;
                            BiletTariffItem aa = new BiletTariffItem(biletTarifeSale);
                            //MessageBox.Show(bitem.Kota.ToString());
                            aa.Text = item.TarifeAdi + " ("+"Tutar: ".ChangeLng() + bitem.Tutar + ") ("+"Kalan: ".ChangeLng() + (bitem.Kota-biletKotaKodKullanilan).ToString()+")";
                            aa.biletTarifeSale.biletTarife.Tutar = bitem.Tutar;
                            aa.biletTarifeSale.KotaId = bitem.KotaId;
                            aa.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                            aa.Dock = System.Windows.Forms.DockStyle.Fill;
                            aa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                            aa.Click += new System.EventHandler(this.biletTariff_Click);
                            this.tableLayoutPanel1.Controls.Add(aa, 0, say);
                            say++;
                            tableLayoutPanel1.RowCount = say;
                            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, (this.Size.Height - 60) / (say + 1)));

                        }
                    }
                }
                //say++;

                Button btnCancel = new Button();
                btnCancel.Text = "İptal".ChangeLng();
                btnCancel.ForeColor = System.Drawing.Color.White;
                //this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                btnCancel.BackColor = System.Drawing.Color.DarkRed;
                btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
                btnCancel.Height = 50;
                btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnCancel.Click += new System.EventHandler(this.buttonTariffCancel_Click);
                tableLayoutPanel1.Controls.Add(btnCancel, 0, say);
                tableLayoutPanel1.AutoScroll = true;
                tableLayoutPanel1.RowCount = say;
                tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));

                //Button btnCancel = new Button();
                //btnCancel.Text = "İptal".ChangeLng();
                //btnCancel.ForeColor = System.Drawing.Color.White;
                //btnCancel.BackColor = System.Drawing.Color.DarkRed;
                //btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
                //btnCancel.Height = (this.Size.Height - 60) / (say + 1);
                //btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                //btnCancel.Click += new System.EventHandler(this.buttonTariffCancel_Click);
                ////tableLayoutPanel1.MaximumSize = new System.Drawing.Size(tableLayoutPanel1.Width, 500);
                ////tableLayoutPanel1.AutoSize = true;
                //tableLayoutPanel1.AutoScroll = true;
                //tableLayoutPanel1.Controls.Add(btnCancel, 0, say);
                ////this.AutoScroll = true;
                //tableLayoutPanel1.RowCount = say;
                //tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, (this.Size.Height - 60) / (say + 1)));
            }
        }


        private void buttonTariffCancel_Click(object sender, EventArgs e)
        {

            Check();
        }


        private void buttonAcenteCancel_Click(object sender, EventArgs e)
        {

            Check();
        }


        private void acenteType_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(((TariffItem)sender).acenteTipi.AcenteTipiAdi);
            var button = ((TariffItem)sender);
            using (var entities = new FFSaleEntities())
            {
                var acente = entities.Acente.ToList().Where(o => o.AcenteTipiId == button.acenteTipi.AcenteTipiId);
                tableLayoutPanel1.Controls.Clear();
                int say = 0;
                foreach (var item in acente)
                {
                    TariffItem aa = new TariffItem(item);
                    aa.Text = item.KisaAdi;
                    aa.Dock = System.Windows.Forms.DockStyle.Fill;
                    aa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    //this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    aa.Click += new System.EventHandler(this.acente_Click);
                    this.tableLayoutPanel1.Controls.Add(aa, 0, say);
                    say++;
                    tableLayoutPanel1.RowCount = say;
                    tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, (this.Size.Height - 60) / (acenteTipi.Count + 1)));
                }
                //say++;
                Button btnCancel = new Button();
                btnCancel.Text = "İptal".ChangeLng();
                btnCancel.ForeColor = System.Drawing.Color.White;
                //this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                btnCancel.BackColor = System.Drawing.Color.DarkRed;
                btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
                btnCancel.Height = 50;
                //btnCancel.Height = (this.Size.Height - 60) / (acenteTipi.Count + 1);
                btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnCancel.Click += new System.EventHandler(this.buttonAcenteCancel_Click);
                tableLayoutPanel1.Controls.Add(btnCancel, 0, say);
                tableLayoutPanel1.AutoScroll = true;
                tableLayoutPanel1.RowCount = say;
                //tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, (this.Size.Height - 60) / (acenteTipi.Count + 1)));
                tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));

            }

            //foreach (var item in acenteTipi)
            //{
            //    TariffItem aa = new TariffItem(item);
            //    aa.Text = item.AcenteTipiAdi;
            //    aa.Dock = System.Windows.Forms.DockStyle.Fill;
            //    aa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //    aa.Click += new System.EventHandler(this.buttonNumber_Click);
            //    this.tableLayoutPanel1.Controls.Add(aa, 0, say);
            //    say++;
            //    tableLayoutPanel1.RowCount = say;
            //    tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            //}
            ////say++;
            //Button btnCancel = new Button();
            //btnCancel.Text = "İptal";
            //btnCancel.ForeColor = System.Drawing.Color.White;
            //btnCancel.BackColor = System.Drawing.Color.DarkRed;
            //btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            //btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //btnCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            //this.tableLayoutPanel1.Controls.Add(btnCancel, 0, say);
            //tableLayoutPanel1.RowCount = say;
            //tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));



        }
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
            int say = 0;
            tableLayoutPanel1.Controls.Clear();
            foreach (var item in acenteTipi)
            {
                TariffItem aa = new TariffItem(item);
                aa.Text = item.AcenteTipiAdi;

                this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                aa.Dock = System.Windows.Forms.DockStyle.Fill;
                aa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                aa.Click += new System.EventHandler(this.acenteType_Click);
                this.tableLayoutPanel1.Controls.Add(aa, 0, say);
                //MessageBox.Show((this.Size.Height/(acenteTipi.Count+1)).ToString());
                say++;
                tableLayoutPanel1.RowCount = say;
                tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, (this.Size.Height - 60) / (acenteTipi.Count + 1)));
            }
            //say++;
            Button btnCancel = new Button();
            //btnCancel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            btnCancel.Text = "İptal".ChangeLng();
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.BackColor = System.Drawing.Color.DarkRed;
            btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
            //btnCancel.Height = (this.Size.Height - 60) / (acenteTipi.Count + 1);
            btnCancel.Height = 50;
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            this.tableLayoutPanel1.Controls.Add(btnCancel, 0, say);
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.RowCount = say;
            //tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, (this.Size.Height - 60) / (acenteTipi.Count + 1)));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));

        }





    }

    public sealed class TariffItem : Button
    {

        public readonly AcenteTipi acenteTipi;
        public readonly Acente acente;

        public TariffItem(AcenteTipi _acenteTipi)
        {
            acenteTipi = _acenteTipi;
        }


        public TariffItem(Acente _acente)
        {
            acente = _acente;
        }
    }


    public sealed class BiletTariffItem : Button
    {

        public readonly BiletTarifeSale biletTarifeSale;


        public BiletTariffItem(BiletTarifeSale _biletTarifeSale)
        {
            biletTarifeSale = _biletTarifeSale;
        }


    }
}
