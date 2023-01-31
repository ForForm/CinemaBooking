using System;
using System.Windows.Forms;
using CineBookManager.Classes;
using CineBookManager.Models;

namespace CineBookManager.Forms
{
    public partial class UserEditForm : Form
    {
        private readonly User _user;
        public UserEditForm(User user) { InitializeComponent(); Owner = Main.Instance; _user = user; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            checkBoxDeleted.CheckedChanged += delegate { checkBoxDeleted.Text = checkBoxDeleted.Checked ? "Yes" : "No"; };
            textBoxUserCode.Text = _user.UserCode;
            textBoxUserName.Text = _user.UserName;
            textBoxMailAddress.Text = _user.MailAddress;
            textBoxNewPassword.Text = "";
            checkBoxDeleted.Checked = _user.Deleted == true;
        }
        public static bool ShowForm(User user)
        {
            return new UserEditForm(user).ShowDialog() == DialogResult.OK;
        }
        private void buttonCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; }
        private void buttonOkay_Click(object sender, EventArgs e)
        {
            if (textBoxUserCode.Text == "") return;
            _user.UserCode = textBoxUserCode.Text ;
            _user.UserName = textBoxUserName.Text ;
            _user.MailAddress = textBoxMailAddress.Text;
            if (textBoxNewPassword.Text != "") _user.Password = textBoxNewPassword.Text.ComputeHash();
            _user.Deleted = checkBoxDeleted.Checked;
            DialogResult = DialogResult.OK;
        }
        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) buttonOkay_Click(null, null);
            else if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
