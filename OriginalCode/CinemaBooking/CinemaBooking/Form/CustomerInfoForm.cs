using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CinemaBooking
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public partial class CustomerInfoForm : Form
    {
        private enum Selection { Phone, Name, Email }
        private Selection CurrentSelection;
        private string _resultPhone, _resultName, _resultEmail;
        public CustomerInfoForm()
        {
            InitializeComponent();
            _resultPhone = _resultName = _resultEmail = string.Empty;
            Owner = MainForm.Instance;
            Location = Owner.Location;
            Size = Owner.Size;
            WindowState = Owner.WindowState;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            labelPhone.Click += delegate { CurrentSelection = Selection.Phone; RefreshMe(); };
            labelName.Click += delegate { CurrentSelection = Selection.Name; RefreshMe(); };
            labelEmail.Click += delegate { CurrentSelection = Selection.Email; RefreshMe(); };
            RefreshMe();
        }

        private void button_Click(object sender, EventArgs e)
        {
            var button = sender as Button; if (button == null) return;
            var text = button.Text;
            switch (CurrentSelection)
            {
                case Selection.Phone:
                    if (Regex.IsMatch(text, "[0-9]")) _resultPhone += text;
                    break;
                case Selection.Name:
                    _resultName += text;
                    break;
                case Selection.Email:
                    _resultEmail += text;
                    break;
            }
            RefreshMe();
        }
        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            switch (CurrentSelection)
            {
                case Selection.Phone:
                    if (_resultPhone.Length > 0) _resultPhone = _resultPhone.Substring(0, _resultPhone.Length - 1);
                    break;
                case Selection.Name:
                    if (_resultName.Length > 0) _resultName = _resultName.Substring(0, _resultName.Length - 1);
                    break;
                case Selection.Email:
                    if (_resultEmail.Length > 0) _resultEmail = _resultEmail.Substring(0, _resultEmail.Length - 1);
                    break;
            }
            RefreshMe();
        }
        private void buttonSpace_Click(object sender, EventArgs e)
        {
            switch (CurrentSelection)
            {
                case Selection.Phone:
                    break;
                case Selection.Name:
                    if (_resultName != string.Empty && !_resultName.EndsWith(" ")) _resultName += " ";
                    break;
                case Selection.Email:
                    break;
            }
            RefreshMe();
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (CurrentSelection == Selection.Phone) CurrentSelection = Selection.Name;
            else if (CurrentSelection == Selection.Name) CurrentSelection = Selection.Email;
            else if (CurrentSelection == Selection.Email) CurrentSelection = Selection.Phone;
            RefreshMe();
        }
        private void buttonCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; }
        private void buttonOkay_Click(object sender, EventArgs e) { DialogResult = DialogResult.OK; }

        public static bool GetPrompt(out string resultPhone, out string resultName, out string resultEmail)
        {
            resultPhone = resultName = resultEmail = string.Empty;
            var window = new CustomerInfoForm { Owner = MainForm.Instance };
            window.ShowDialog();
            var result = window.DialogResult == DialogResult.OK;
            if (result)
            {
                resultPhone = window._resultPhone.Trim();
                resultName = window._resultName.Trim();
                resultEmail = window._resultEmail.Trim();
            }
            return result;
        }
        private void RefreshMe()
        {
            if (_resultPhone.Length >= 32) _resultPhone = _resultPhone.Substring(0, 32);
            if (_resultName.Length >= 32) _resultName = _resultName.Substring(0, 32);
            if (_resultEmail.Length >= 32) _resultEmail = _resultEmail.Substring(0, 32);

            labelPhone.Text = _resultPhone == string.Empty ? "(Cep Telefonu)" : _resultPhone;
            labelName.Text = _resultName == string.Empty ? "(İsim / Soyisim)" : _resultName;
            labelEmail.Text = _resultEmail == string.Empty ? "(Eposta Adresi)" : _resultEmail;
            if (_resultPhone == string.Empty) labelPhone.ForeColor = Color.DimGray; else labelPhone.ResetForeColor();
            if (_resultName == string.Empty) labelName.ForeColor = Color.DimGray; else labelName.ResetForeColor();
            if (_resultEmail == string.Empty) labelEmail.ForeColor = Color.DimGray; else labelEmail.ResetForeColor();

            pictureBoxPhone.Visible = CurrentSelection == Selection.Phone;
            pictureBoxName.Visible = CurrentSelection == Selection.Name;
            pictureBoxEmail.Visible = CurrentSelection == Selection.Email;
            switch (CurrentSelection)
            {
                case Selection.Phone:
                    button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = button0.Enabled = true;
                    buttonDash.Enabled = buttonUnderline.Enabled = false;
                    buttonQ.Enabled = buttonW.Enabled = buttonE.Enabled = buttonR.Enabled = buttonT.Enabled = buttonY.Enabled = buttonU.Enabled = buttonO.Enabled = buttonP.Enabled = buttonA.Enabled = buttonS.Enabled = buttonD.Enabled = buttonF.Enabled = buttonG.Enabled = buttonH.Enabled = buttonJ.Enabled = buttonK.Enabled = buttonL.Enabled = buttonZ.Enabled = buttonX.Enabled = buttonC.Enabled = buttonV.Enabled = buttonB.Enabled = buttonN.Enabled = buttonM.Enabled = false;
                    buttonI.Enabled = buttonĞ.Enabled = buttonÜ.Enabled = buttonŞ.Enabled = buttonİ.Enabled = buttonÖ.Enabled = buttonÇ.Enabled = false;
                    buttonDot.Enabled = buttonAt.Enabled = false;
                    buttonSpace.Enabled = false;
                    buttonBackspace.Enabled = _resultPhone != string.Empty;
                    break;
                case Selection.Name:
                    button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = button0.Enabled = false;
                    buttonDash.Enabled = buttonUnderline.Enabled = false;
                    buttonQ.Enabled = buttonW.Enabled = buttonE.Enabled = buttonR.Enabled = buttonT.Enabled = buttonY.Enabled = buttonU.Enabled = buttonO.Enabled = buttonP.Enabled = buttonA.Enabled = buttonS.Enabled = buttonD.Enabled = buttonF.Enabled = buttonG.Enabled = buttonH.Enabled = buttonJ.Enabled = buttonK.Enabled = buttonL.Enabled = buttonZ.Enabled = buttonX.Enabled = buttonC.Enabled = buttonV.Enabled = buttonB.Enabled = buttonN.Enabled = buttonM.Enabled = true;
                    buttonI.Enabled = buttonĞ.Enabled = buttonÜ.Enabled = buttonŞ.Enabled = buttonİ.Enabled = buttonÖ.Enabled = buttonÇ.Enabled = true;
                    buttonDot.Enabled = buttonAt.Enabled = false;
                    buttonSpace.Enabled = _resultName != string.Empty && !_resultName.EndsWith(" ");
                    buttonBackspace.Enabled = _resultName != string.Empty;
                    break;
                case Selection.Email:
                    button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = button0.Enabled = true;
                    buttonDash.Enabled = buttonUnderline.Enabled = true;
                    buttonQ.Enabled = buttonW.Enabled = buttonE.Enabled = buttonR.Enabled = buttonT.Enabled = buttonY.Enabled = buttonU.Enabled = buttonO.Enabled = buttonP.Enabled = buttonA.Enabled = buttonS.Enabled = buttonD.Enabled = buttonF.Enabled = buttonG.Enabled = buttonH.Enabled = buttonJ.Enabled = buttonK.Enabled = buttonL.Enabled = buttonZ.Enabled = buttonX.Enabled = buttonC.Enabled = buttonV.Enabled = buttonB.Enabled = buttonN.Enabled = buttonM.Enabled = true;
                    buttonI.Enabled = buttonĞ.Enabled = buttonÜ.Enabled = buttonŞ.Enabled = buttonÖ.Enabled = buttonÇ.Enabled = false; buttonİ.Enabled = true;
                    buttonDot.Enabled = _resultEmail != string.Empty && !_resultEmail.EndsWith("."); buttonAt.Enabled = _resultEmail != string.Empty && !_resultEmail.Contains("@") && !_resultEmail.EndsWith(".");
                    buttonSpace.Enabled = false;
                    buttonBackspace.Enabled = _resultEmail != string.Empty;
                    break;
            }
            buttonBackspace.ImageIndex = buttonBackspace.Enabled ? 0 : -1;
            buttonSpace.ImageIndex = buttonSpace.Enabled ? 1 : -1;
            RefreshButtons();
            //buttonOkay.Enabled = _resultPhone != string.Empty && _resultName != string.Empty && _resultEmail != string.Empty;
            buttonOkay.Enabled = true;
        }
        private void RefreshButtons()
        {
            if (CurrentSelection == Selection.Email)
            {
                buttonQ.Text = @"q";
                buttonW.Text = @"w";
                buttonE.Text = @"e";
                buttonR.Text = @"r";
                buttonT.Text = @"t";
                buttonY.Text = @"y";
                buttonU.Text = @"u";
                buttonI.Text = @"ı";
                buttonO.Text = @"o";
                buttonP.Text = @"p";
                buttonĞ.Text = @"ğ";
                buttonÜ.Text = @"ü";

                buttonA.Text = @"a";
                buttonS.Text = @"s";
                buttonD.Text = @"d";
                buttonF.Text = @"f";
                buttonG.Text = @"g";
                buttonH.Text = @"h";
                buttonJ.Text = @"j";
                buttonK.Text = @"k";
                buttonL.Text = @"l";
                buttonŞ.Text = @"ş";
                buttonİ.Text = @"i";

                buttonZ.Text = @"z";
                buttonX.Text = @"x";
                buttonC.Text = @"c";
                buttonV.Text = @"v";
                buttonB.Text = @"b";
                buttonN.Text = @"n";
                buttonM.Text = @"m";
                buttonÖ.Text = @"ö";
                buttonÇ.Text = @"ç";
            }
            else
            {
                buttonQ.Text = @"Q";
                buttonW.Text = @"W";
                buttonE.Text = @"E";
                buttonR.Text = @"R";
                buttonT.Text = @"T";
                buttonY.Text = @"Y";
                buttonU.Text = @"U";
                buttonI.Text = @"I";
                buttonO.Text = @"O";
                buttonP.Text = @"P";
                buttonĞ.Text = @"Ğ";
                buttonÜ.Text = @"Ü";

                buttonA.Text = @"A";
                buttonS.Text = @"S";
                buttonD.Text = @"D";
                buttonF.Text = @"F";
                buttonG.Text = @"G";
                buttonH.Text = @"H";
                buttonJ.Text = @"J";
                buttonK.Text = @"K";
                buttonL.Text = @"L";
                buttonŞ.Text = @"Ş";
                buttonİ.Text = @"İ";

                buttonZ.Text = @"Z";
                buttonX.Text = @"X";
                buttonC.Text = @"C";
                buttonV.Text = @"V";
                buttonB.Text = @"B";
                buttonN.Text = @"N";
                buttonM.Text = @"M";
                buttonÖ.Text = @"Ö";
                buttonÇ.Text = @"Ç";
            }
        }
    }
}
