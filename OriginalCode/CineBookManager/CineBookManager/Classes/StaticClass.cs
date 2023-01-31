using CineBookManager.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CineBookManager.Classes
{
    public static class StaticClass
    {
        public const int LinqTopRowsCount = 20;

        public static void ShowInfo(string text, string caption = StringConsts.MessageBox_Info)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowWarning(string text, string caption = StringConsts.MessageBox_Warning)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void ShowError(string text, string caption = StringConsts.MessageBox_Error)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static bool ShowQuestion(string text = StringConsts.Areyousure, string caption = StringConsts.MessageBox_Question)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }
        public static bool InputBox(string title, string promptText, ref string value, bool passwordInput = false, string btnOkText = StringConsts.MessageBox_OK, string btnCancelText = StringConsts.MessageBox_Cancel)
        {
            var form = new Form();
            var label = new Label();
            var textBox = new TextBox();
            var buttonOk = new Button();
            var buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            if (passwordInput) textBox.PasswordChar = '●';

            buttonOk.Text = btnOkText;
            buttonCancel.Text = btnCancelText;
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 10, 372, 13);
            textBox.SetBounds(12, 32, 372, 20);
            buttonOk.SetBounds(228, 60, 75, 23); buttonCancel.SetBounds(309, 60, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 90);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.ControlBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            var dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult == DialogResult.OK;
        }
        public static string BindProperty(object property, string propertyName)
        {
            var retValue = "";
            if (propertyName.Contains("."))
            {
                var leftPropertyName = propertyName.Substring(0, propertyName.IndexOf(".", StringComparison.Ordinal));
                var arrayProperties = property.GetType().GetProperties();
                foreach (var propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name != leftPropertyName) continue;
                    retValue = BindProperty(propertyInfo.GetValue(property, null), propertyName.Substring(propertyName.IndexOf(".", StringComparison.Ordinal) + 1));
                    break;
                }
            }
            else
            {
                var propertyType = property.GetType();
                var propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }
            return retValue;
        }

        public static IEnumerable<Control> GetAll(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAll(ctrl))
                                      .Concat(controls);
        }


        public static void ChangeNames(object item)
        {
            using (var entities = new CineBookEntities())
            {


                try
                {
                    var toolstrips = ((ToolStrip)item);
                    foreach (ToolStripItem tsi in toolstrips.Items)
                    {
                        if (tsi is ToolStripButton)
                        {
                            ToolStripButton tb = tsi as ToolStripButton;
                            var aa = entities.LabelDictionary.Where(o => o.Label == tb.Text && o.LanguagesId == LoginUser.LoggedLanguagesId).FirstOrDefault();
                            if (aa != null) tb.Text = aa.LabelLng;
                        }
                    }

                }
                catch { };

                try
                {
                    MessageBox.Show(((ToolStripButton)item).Text);
                    var aa = entities.LabelDictionary.Where(o => o.Label == ((ToolStripButton)item).Text && o.LanguagesId == LoginUser.LoggedLanguagesId).FirstOrDefault();
                    if (aa != null) ((ToolStripButton)item).Text = aa.LabelLng;
                }
                catch { };

                try
                {
                    var aa = entities.LabelDictionary.Where(o => o.Label == ((TextBox)item).Text && o.LanguagesId == LoginUser.LoggedLanguagesId).FirstOrDefault();
                    if (aa != null) ((TextBox)item).Text = aa.LabelLng;
                }
                catch { };

                try
                {
                    var aa = entities.LabelDictionary.Where(o => o.Label == ((RadioButton)item).Text && o.LanguagesId == LoginUser.LoggedLanguagesId).FirstOrDefault();
                    if (aa != null) ((RadioButton)item).Text = aa.LabelLng;
                }
                catch { };

                try
                {
                    //MessageBox.Show(((Label)item).Text);
                    var aa = entities.LabelDictionary.Where(o => o.Label == ((Label)item).Text && o.LanguagesId == LoginUser.LoggedLanguagesId).FirstOrDefault();
                    if (aa != null) ((Label)item).Text = aa.LabelLng;
                }
                catch { };

                try
                {
                    //MessageBox.Show(((Button)item).Text);
                    var aa = entities.LabelDictionary.Where(o => o.Label == ((Button)item).Text && o.LanguagesId == LoginUser.LoggedLanguagesId).FirstOrDefault();
                    if (aa != null) ((Button)item).Text = aa.LabelLng;
                }
                catch { };



                try
                {
                    //MessageBox.Show(((TabPage)item).Text);
                    var aa = entities.LabelDictionary.Where(o => o.Label == ((TabPage)item).Text && o.LanguagesId == LoginUser.LoggedLanguagesId).FirstOrDefault();
                    if (aa != null) ((TabPage)item).Text = aa.LabelLng;
                }
                catch { };
            }

        }
    }
}
